using System.Runtime.InteropServices.Marshalling;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using ComWrappersSourceGenerationConsole.Interfaces;


namespace ComWrappersSourceGenerationConsole
{
    internal partial class Program
    {
        private const int CLSCTX_ALL = 23;

        private static readonly Guid CLSID_PortableDeviceManager = new("0AF10CEC-2ECD-4B92-9581-34F6AE0637F3");

        static void Main()
        {
            try
            {
                new Program().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debugger.Break();
            }
        }

        #region LibraryImport

        [PreserveSig, LibraryImport("ole32")]
        public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);

        #endregion

        public void Run()
        {

            var state = System.Threading.Thread.CurrentThread.GetApartmentState(); // ..SetApartmentState(ApartmentState.STA);

            int res = CoCreateInstance(CLSID_PortableDeviceManager, 0, CLSCTX_ALL, typeof(IPortableDeviceManager).GUID, out var factory);

            IPortableDeviceManager portableDeviceManager = (IPortableDeviceManager)factory;
            IPortableDeviceServiceManager portableDeviceServiceManager = (IPortableDeviceServiceManager)portableDeviceManager;

            int count = 0;
            portableDeviceManager.GetDevices(null, ref count);

            
            var deviceIds = new string[count];
            portableDeviceManager.GetDevices(deviceIds, ref count);


            string deviceId = deviceIds[0];

            string? friendlyName = GetDeviceFriendlyName(portableDeviceManager, deviceId);
            string? description = GetDeviceDescription(portableDeviceManager, deviceId);
            string? manufacturer = GetDeviceManufacturer(portableDeviceManager, deviceId);

            Console.WriteLine(description);
        }

        private static string? GetDeviceFriendlyName(IPortableDeviceManager portableDeviceManager, string deviceId)
        {
            int size = 256;
            nint mem = Marshal.AllocHGlobal(size);
            portableDeviceManager.GetDeviceFriendlyName(deviceId, mem, ref size);
            string? str = Marshal.PtrToStringUni(mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }

        private static string? GetDeviceDescription(IPortableDeviceManager portableDeviceManager, string deviceId)
        {
            int size = 256;
            nint mem = Marshal.AllocHGlobal(size);
            portableDeviceManager.GetDeviceDescription(deviceId, mem, ref size);
            string? str = Marshal.PtrToStringUni(mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }

        private static string? GetDeviceManufacturer(IPortableDeviceManager portableDeviceManager, string deviceId)
        {
            int size = 256;
            nint mem = Marshal.AllocHGlobal(size);
            portableDeviceManager.GetDeviceManufacturer(deviceId, mem, ref size);
            string? str = Marshal.PtrToStringUni(mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }

    }
}
