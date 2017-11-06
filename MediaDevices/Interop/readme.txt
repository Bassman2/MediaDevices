Once you've built your project, this generates the interop assemblies that do the magic allowing the COM APIs to be called from .Net. However, in this case, some of the marshalling information is incorrect so we have to fix that.

Copy the generated Interop.PortableDeviceApiLib.dll from obj\Debug to another folder (I created one called Interop), and disassemble it using:

ildasm Interop.PortableDeviceApiLib.dll /out:pdapi.il

Open pdapi.il in your favourite text editor and make the following changes:

Replace all instances of


GetDevices([in][out] string&  marshal( lpwstr) pPnPDeviceIDs,

with

GetDevices([in][out] string[]  marshal( lpwstr[]) pPnPDeviceIDs,

Then for all instances of GetDeviceFriendlyName, GetDeviceDescription and GetDeviceManufacturer we need to fix the marshalling for the unicode strings they return by changing

[in][out] uint16&

to

[in][out] uint16[] marshal([])

[Note that these are the only changes I have had to make so far, but there may be others if you are using more of the API than us]

Now rename the original interop dll and reassemble the fixed one using

ilasm pdapi.il /dll /output=Interop.PortableDeviceApiLib.dll

Make sure you use the correct version of ilasm, eg. if you are building a .net 4.0 project use the one in


C:\Windows\Microsoft.NET\Framework64\v4.0.30319

Finally, remove the original reference to PortableDeviceApiLib and add a reference to your new Interop.PortableDeviceApiLib.dll assembly.
