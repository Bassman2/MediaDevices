using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WPDGenerator
{
    internal partial class Program
    {
        static void Main(string[] args) => new Program().Run();

        private readonly Dictionary<string, string> guidDict = [];
        private int lineNum = 0;

        bool test = false;
        private void Run()
        {
            Create(@"D:\_Data\MediaDevices\Header\PortableDevice.h", @"D:\_Data\MediaDevices\Header\WPD.cs", 3, true);
            Create(@"D:\_Data\MediaDevices\Header\deviceservices.h", @"D:\_Data\MediaDevices\Header\WPD.DeviceServices.cs", 8);
            Create(@"D:\_Data\MediaDevices\Header\statusdeviceservice.h", @"D:\_Data\MediaDevices\Header\WPD.StatusDeviceServices.cs", 8);
            Create(@"D:\_Data\MediaDevices\Header\WpdMtpExtensions.h", @"D:\_Data\MediaDevices\Header\WPD.WpdMtpExtensions.cs", 8);
        }
        private void Create(string source, string destination, int ignorLines, bool main = false)
        { 
            using var reader = File.OpenText(source);
            using var writer = File.CreateText(destination);
            lineNum = 0;

            if (main)
            {
                writer.WriteLine(
                    """
                namespace MediaDevices.Internal;

                [FindFieldsGeneratorAttribute]
                internal static partial class WPD
                {
                """);
            }
            else
            {
                writer.WriteLine(
                    """
                namespace MediaDevices.Internal;

                partial class WPD
                {
                """);
            }

            string comment = string.Empty;
            string? line;
            
            for (int i = 0; i < ignorLines; i++)
            {
                reader.ReadLine();
                lineNum++;
            }
            while ((line = reader.ReadLine()) != null)
            {
                lineNum++;

                if (test && lineNum > 178)
                {

                }

                // multi line comment
                if (line.TrimStart().StartsWith("/*"))
                {
                    while (!line!.TrimEnd().EndsWith("*/"))
                    {
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                        lineNum++;
                    }
                    writer.WriteLine(line);
                }
                else if (line!.StartsWith("//"))
                {
                    comment += $"    {line}\r\n";
                }

                ///////////////////////////////////////////////////////////////
                // Guid
                ///////////////////////////////////////////////////////////////

                else if (line!.StartsWith("DEFINE_GUID"))
                {
                    CreateGuid("DEFINE_GUID", line, comment, "", reader, writer);
                    comment = string.Empty; 
                }
                else if (line!.StartsWith("DEFINE_DEVSVCGUID"))
                {
                    CreateGuid("DEFINE_DEVSVCGUID", line, comment, "DEVSVC_", reader, writer);
                    comment = string.Empty; 
                }

                ///////////////////////////////////////////////////////////////
                // PropertyKey
                ///////////////////////////////////////////////////////////////

                else if (line!.StartsWith("DEFINE_PROPERTYKEY"))
                {
                    CreatePropertykey("DEFINE_PROPERTYKEY", line, comment, "", reader, writer);
                    comment = string.Empty;
                }
                else if (line!.StartsWith("DEFINE_DEVSVCPROPKEY"))
                {
                    CreatePropertykey("DEFINE_DEVSVCPROPKEY", line, comment, "DEVSVC_", reader, writer);
                    comment = string.Empty;
                }
                
                else
                {
                    comment = string.Empty;
                }
            }

            writer.WriteLine(
                """
                }
                """);

        }

        private string GetLine(StreamReader reader, string line, string define)
        {
            line = line.Substring(define.Length);
            while (!line.Contains(';'))
            {
                line += reader.ReadLine();
                lineNum++;
            }
            return line;
        }

        [GeneratedRegex(@"\(\s*([A-Za-z_][A-Za-z0-9_]*)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*\)")]
        private static partial Regex DefineGuidRegex();

        private void CreateGuid(string define, string line, string comment, string prefix, StreamReader reader, StreamWriter writer)
        {
            line = GetLine(reader, line,  define);
            var match = DefineGuidRegex().Match(line);
            if (match.Success)
            {
                string name = prefix + FixName(match.Groups[1].Value);
                string guid = $"{match.Groups[2]}, {match.Groups[3]}, {match.Groups[4]}, {match.Groups[5]}, {match.Groups[6]}, {match.Groups[7]}, {match.Groups[8]}, {match.Groups[9]}, {match.Groups[10]}, {match.Groups[11]}, {match.Groups[12]}";
                guidDict.TryAdd(guid.ToLower(), name);

                writer.Write(comment);
                writer.Write(
                    $$"""
                        public static Guid {{name}} = new({{guid}});


                    """);
            }
            else Console.Error.WriteLine($"Regex Error in line ({lineNum}): {line}");
        }

        

        [GeneratedRegex(@"\(\s*([A-Za-z_][A-Za-z0-9_]*)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*(0[xX][A-Fa-f0-9]+)\s*,\s*([0-9)]+)\s*\)")]
        private static partial Regex DefinePropertykeyRegex();

        private void CreatePropertykey(string define, string line, string comment, string prefix, StreamReader reader, StreamWriter writer)
        {
            line = GetLine(reader, line, define);
            var match = DefinePropertykeyRegex().Match(line);
            if (match.Success)
            {
                string name = prefix + FixName(match.Groups[1].Value);
                string guid = $"{match.Groups[2]}, {match.Groups[3]}, {match.Groups[4]}, {match.Groups[5]}, {match.Groups[6]}, {match.Groups[7]}, {match.Groups[8]}, {match.Groups[9]}, {match.Groups[10]}, {match.Groups[11]}, {match.Groups[12]}";
                string pid = match.Groups[13].Value;

                if (guidDict.TryGetValue(guid.ToLower(), out string? guidName))
                {
                    writer.Write(comment);
                    writer.Write(
                    $$"""
                                public static PropertyKey {{name}} = new()
                                {
                                    fmtid = {{guidName}},
                                    pid = {{pid}}
                                };


                            """);
                }
                else
                {
                    writer.Write(comment);
                    writer.Write(
                    $$"""
                                public static PropertyKey {{name}} = new()
                                {
                                    fmtid = new({{guid}}),
                                    pid = {{pid}}
                                };


                            """);
                    Console.Error.WriteLine($"Error in line ({lineNum}): Guid for {name} not found in dictionary.");
                }
            }
            else Console.Error.WriteLine($"Regex Error in line ({lineNum}): {line}");
        }

        private static string FixName(string name)
        {
            return name.StartsWith("WPD_") ? name.Substring(4) : name;
        }
    }
}
