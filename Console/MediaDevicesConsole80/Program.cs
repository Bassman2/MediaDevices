using MediaDevices;

namespace MediaDevicesConsole80
{

    // https://learn.microsoft.com/en-us/dotnet/standard/native-interop/comwrappers-source-generation
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            using (var mdm = MediaDeviceManager.Instance)
            {
                var list = mdm.GetDevices();
            }

        }
    }
}
