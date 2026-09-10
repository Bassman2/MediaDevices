rem install usbipd with
rem winget install usbipd
rem https://github.com/dorssel/usbipd-win

rem show all your USB devices
usbipd list

rem bind your device with the BUSID
rem usbipd bind --busid 1-13
usbipd attach --wsl --busid 5-1
