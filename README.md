# MediaDevices

Media Devices is a API to interact with MTP (Media Transfer Protocol), PTP (Picture Transport Protocol) and MSC (Mass Storage Class) devices like cell phones, tablets and cameras.

Version 2 has been completely rewritten to support the following features:

* Thread-safe: The library can now be used across multiple threads.

* Trimmable

* AOT-compatible

* Uses generated COM and LibraryImport

* Async support

Older .NET versions prior to 8.0 are no longer supported, as they do not support these new features.

## Future Development

I currently see two directions for further development.

1. Implementation of manufacturer-specific features, such as camera control.

2. Support for Linux and MacOS. This would mean implementing a custom MTP/PTP stack for Linux and MacOS.

According to my current research, using a custom MTP/PTP stack under Windows is not possible because Windows Portable Devices block access to the USB MTP interface.

Please give me feedback on which of the two options you prefer.

If anyone knows of a way to use the COM interface, please let me know.
I don't want to use tools like Zadig or external libraries.

## Download

[NuGet Package](https://www.nuget.org/packages/MediaDevices/)

## Documentation

[Pages](https://bassman2.github.io/MediaDevices/)

## Donate

You are welcome to support this project. 

[![Donate](https://raw.githubusercontent.com/Bassman2/MediaDevices/master/.github/images/donate.gif)](https://www.paypal.me/GBassman)
