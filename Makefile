.PHONY: build run

PROJECT="power-readout"
PROJECT_LOWER=$(shell echo $(PROJECT) | tr A-Z a-z)
PWD=$(shell pwd)

REGISTRY:=harbor.crazyzone.be/crazyzone
VERSION:=$(shell cat VERSION | tr --delete '/n')
#ARCH:=linux-x64
#ARCH:=linux-arm64
ARCH:=linux-arm
PORT:=8080

REGISTRY_HELM:=harbor.crazyzone.be/crazyzone-helm


clean:
	rm -rf build

build:
	mkdir -p "${PWD}/build/"
	dotnet restore "${PWD}/src/PowerReadOut" && \
	dotnet publish -c Release -o "${PWD}/build" -r ${ARCH} --self-contained true -p:PublishTrimmed=true /p:DebugSymbols=false /p:DebugType=None "${PWD}/src/PowerReadOut/PowerReadOut.csproj"

container:
	docker build -t "${REGISTRY}/${PROJECT_LOWER}:${VERSION}" .

run: container
	docker run -ti --rm \
		--name "${PROJECT_LOWER}" \
		-p 8080:80 \
		${REGISTRY}/${PROJECT_LOWER}:${VERSION}

push: container
	docker push ${REGISTRY}/${PROJECT_LOWER}:${VERSION}
	docker tag ${REGISTRY}/${PROJECT_LOWER}:${VERSION} ${REGISTRY}/${PROJECT_LOWER}:latest
	docker push ${REGISTRY}/${PROJECT_LOWER}:latest

#
# Helm Chart
#
chartversion:
		sed -i '3 s/version:.*/version: "'${VERSION}'"/' "./chart/Chart.yaml"
		sed -i '4 s/appVersion:.*/appVersion: "'${VERSION}'"/' "./chart/Chart.yaml"
		yq e '.global.tag = "${VERSION}"' -i ./chart/values.yaml

package: clean chartversion
		mkdir -p dist && helm package chart -d ./dist

push-package: package
		helm push ./dist/*.tgz oci://${REGISTRY_HELM}