using GeneratorLibrary;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Text;

namespace FindGenerator;

[Generator]
public partial class FinderGenerator : Generator
{
    public override void Excecute()
    {
        //Debugger.Launch();

        // for debug only
        CreateDebug();

        // get all enums with [FindFieldsGeneratorAttribute] 
        foreach (var en in GetAllEnumsWithAttribute("MediaDevices.Internal.FindFieldsGeneratorAttribute"))
        {
            CreateFindEnumFieldsFile(en);
        }

        // get all classes with [FindFieldsGeneratorAttribute] 
        foreach (var cl in GetAllClassesWithAttribute("MediaDevices.Internal.FindFieldsGeneratorAttribute"))
        {
            CreateFindClassFieldsFile(cl);
        }
       
    }
   
}
