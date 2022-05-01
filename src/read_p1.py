#!/usr/bin/python3

# This script will read data from serial connected to the digital meter P1 port and save it to a file
#
# Created by Nico van Laerebeke 
#
# Based on script by Jens Depuydt
# https://www.jensd.be
# https://github.com/jensdepuydt

import os
import serial

# Change your serial port here:
serialport = '/dev/ttyUSB0'
file_path = "/var/www/readout"

def main():
    ser = serial.Serial(serialport, 115200, xonxoff=1)
    p1telegram = bytearray()
    while True:
        try:
            # read input from serial port
            p1line = ser.readline()

            # P1 telegram starts with /
            # We need to create a new empty telegram
            if "/" in p1line.decode('ascii'):
                p1telegram = bytearray()

            # add line to complete telegram
            p1telegram.extend(p1line)

            # P1 telegram ends with ! + CRC16 checksum
            if "!" in p1line.decode('ascii'):
                #add telegram to file
                with open(file_path, 'w') as file:                    
                    for line in p1telegram.split(b'\r\n'):
                        file.write(f"{line.decode('ascii')}\n")
        except KeyboardInterrupt:
            ser.close()
            break
        except:
            ser.close()

        ser.flush()

if __name__ == '__main__':
    main()
