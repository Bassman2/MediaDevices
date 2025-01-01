//using System;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Runtime.InteropServices.Marshalling;
//using Microsoft.Windows.Widgets.Providers;
//using WinRT;

//// AOT: declare we disable runtime marshalling to enable early compilation errors
////[assembly: DisableRuntimeMarshalling]

//namespace ConsoleApp;

//// AOT, COM Source wrapper generator: don't use implicit root class or face unexpected ERROR_BAD_FORMAT exceptions
//internal partial class ProgramDemo1
//{
//    // AOT: use LibraryImport
//    [LibraryImport("kernel32")]
//    public static partial IntPtr GetConsoleWindow();

//    [PreserveSig, LibraryImport("ole32")]
//    public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);

//    // AOT: don't use 'object' for IUnknown parameters
//    [LibraryImport("ole32")]
//    public static partial int CoRegisterClassObject(in Guid rclsid, IntPtr pUnk, uint dwClsContext, uint flags, out uint lpdwRegister);

//    [LibraryImport("ole32")]
//    public static partial int CoRevokeClassObject(uint dwRegister);

//    static void Main()
//    {
//        Console.WriteLine("Registering Widget Provider");

//        // ask for the widget provider's IUnknown pointer
//        var provider = new WidgetProviderFactory<WidgetProvider>();
//        var comWrappers = new StrategyBasedComWrappers();
//        var unk = comWrappers.GetOrCreateComInterfaceForObject(provider, CreateComInterfaceFlags.None);

//        Guid CLSID_Factory = Guid.Parse("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
//        CoRegisterClassObject(CLSID_Factory, unk, 0x4, 0x1, out var cookie);
//        Console.WriteLine("Registered successfully. Press ENTER to exit.");
//        Console.ReadLine();

//        if (GetConsoleWindow() != IntPtr.Zero)
//        {
//            Console.WriteLine("Registered successfully. Press ENTER to exit.");
//            Console.ReadLine();
//        }
//        else
//        {
//            // Wait until the manager has disposed of the last widget provider.
//            using (var emptyWidgetListEvent = WidgetProvider.GetEmptyWidgetListEvent())
//            {
//                emptyWidgetListEvent.WaitOne();
//            }

//            _ = CoRevokeClassObject(cookie);
//        }
//    }

//    // AOT: use GeneratedComInterface
//    [GeneratedComInterface, Guid(Guids.IClassFactory)]
//    public partial interface IClassFactory
//    {
//        [PreserveSig]
//        int CreateInstance(IntPtr pUnkOuter, in Guid riid, out IntPtr ppvObject);

//        // AOT: mark .NET's bool as UnmanagedType.Bool (Win32 BOOL)
//        [PreserveSig]
//        int LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
//    }

//    // AOT: use GeneratedComClass
//    [GeneratedComClass]
//    public partial class WidgetProviderFactory<T> : IClassFactory where T : IWidgetProvider, new()
//    {
//        public int CreateInstance(IntPtr pUnkOuter, in Guid riid, out IntPtr ppvObject)
//        {
//            ppvObject = IntPtr.Zero;
//            if (pUnkOuter != IntPtr.Zero)
//            {
//                Marshal.ThrowExceptionForHR(CLASS_E_NOAGGREGATION);
//            }

//            if (riid == typeof(T).GUID || riid == Guid.Parse(Guids.IUnknown))
//            {
//                // Create the instance of the .NET object
//                ppvObject = MarshalInspectable<IWidgetProvider>.FromManaged(new T());
//            }
//            else
//            {
//                // The object that ppvObject points to does not support the interface identified by riid.
//                Marshal.ThrowExceptionForHR(E_NOINTERFACE);
//            }
//            return 0;
//        }

//        int IClassFactory.LockServer(bool fLock) => 0;

//        private const int CLASS_E_NOAGGREGATION = -2147221232;
//        private const int E_NOINTERFACE = -2147467262;

//    }

//    static class Guids
//    {
//        public const string IClassFactory = "00000001-0000-0000-C000-000000000046";
//        public const string IUnknown = "00000000-0000-0000-C000-000000000046";
//    }
//}