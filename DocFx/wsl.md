# MediaDevices on WSL

## Installation

WSL does not automatically mirror your physical USB hardware. 
You must use the usbipd tool on Windows to bind and attach your device. 

> winget install dorssel.usbipd-win

In your admin Windows terminal, find your target device and note its BUSID.

> usbipd list

Share the device with the hypervisor. 

> usbipd bind --busid <BUSID>

Connect the device into your active WSL distribution.

> usbipd attach --wsl --busid <BUSID>

Open your WSL terminal and check if the directory now exists and lists your hardware.

> lsusb

Bus 001 Device 001: ID 1d6b:0002 Linux Foundation 2.0 root hub
Bus 001 Device 002: ID 04e8:6860 Samsung Electronics Co., Ltd Galaxy series, misc. (MTP mode)
Bus 002 Device 001: ID 1d6b:0003 Linux Foundation 3.0 root hub

## Run Unit Tests

Install the " .NET Debugging with WSL" package in Visual Studio Installer

> mkdir /usr/local/.vsdbg

> sudo curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /usr/local/.vsdbg

### Errors

Wsl/Service/WSL_E_DISTRO_NOT_FOUND

Run "wsl --list --verbose" to find the exact distibution name.