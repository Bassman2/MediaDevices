using System.Runtime.InteropServices.Marshalling;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: DisableRuntimeMarshalling]

namespace ComWrappersSourceGenerationConsole
{
    internal partial class Program
    {
        private const int CLSCTX_ALL = 23;

        private static readonly Guid CLSID_PortableDeviceManager = new("0AF10CEC-2ECD-4B92-9581-34F6AE0637F3");

        static void Main()
        {
            new Program().Run();
        }

        [PreserveSig, LibraryImport("ole32")]
        public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);


        //[LibraryImport("MyComObjectProvider")]
        //private static partial nint GetPointerToComInterface(); // C definition - IUnknown* GetPointerToComInterface();

        //[LibraryImport("MyComObjectProvider")]
        //private static partial void GivePointerToComInterface(nint comObject); // C definition - void GivePointerToComInterface(IUnknown* pUnk);

        //// AOT: don't use 'object' for IUnknown parameters
        //[LibraryImport("ole32")]
        //public static partial int CoRegisterClassObject(in Guid rclsid, IntPtr pUnk, uint dwClsContext, uint flags, out uint lpdwRegister);

        //[LibraryImport("ole32")]
        //public static partial int CoRevokeClassObject(uint dwRegister);

        public void Run()
        {
            int res = CoCreateInstance(CLSID_PortableDeviceManager, 0, CLSCTX_ALL, typeof(IPortableDeviceManager).GUID, out var factory);

            IPortableDeviceManager portableDeviceManager = (IPortableDeviceManager)factory;

            // Use the ComWrappers API to create a Runtime Callable Wrapper to use in managed code
            //ComWrappers cw = new StrategyBasedComWrappers();
            //nint ptr = GetPointerToComInterface();
            //IPortableDeviceManager manager = (IPortableDeviceManager)cw.GetOrCreateObjectForComInstance(ptr, CreateObjectFlags.None);
            //manager.RefreshDeviceList();

//// Use the system to create a COM Callable Wrapper to pass to unmanaged code
//ComWrappers cw = new StrategyBasedComWrappers();
//        Foo foo = new();
//        nint ptr = cw.GetOrCreateComInterfaceForObject(foo, CreateComInterfaceFlags.None);
//        GivePointerToComInterface(ptr);

//        IPortableDeviceManager manager = new PortableDeviceManager();
//            manager.RefreshDeviceList();

            uint count = 0;
            portableDeviceManager.GetDevices(null, ref count);

            var deviceIds = new string[count];
            portableDeviceManager.GetDevices(deviceIds, ref count);


            string deviceId = deviceIds[0];

            count = 256;
            var sb = new StringBuilder((int)count);

            string desc = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            portableDeviceManager.GetDeviceDescription(deviceId, ref sb, ref count);
            string description = sb.ToString(); //new string(buffer, 0, (int)count - 1);


        }

        //[LibraryImport("MyComObjectProvider")]
        //private static partial nint GetPointerToComInterface(); // C definition - IUnknown* GetPointerToComInterface();

        //[LibraryImport("MyComObjectProvider")]
        //private static partial void GivePointerToComInterface(nint comObject); // C definition - void GivePointerToComInterface(IUnknown* pUnk);

    }
}
