# power-readout

Project that can read out digital electricity meters from a P1 port using the `DSMR 5.0.2` standard.  

## Usage

There are 2 ways to use this project, scrape the data from a web endpoint or read directly from `/dev/ttyUSB0`.  

### Reading directly from the serial port

The port on the meter follows the `RS422` standard.