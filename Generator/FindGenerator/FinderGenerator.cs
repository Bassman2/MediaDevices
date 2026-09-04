using GeneratorLibrary;
using Microsoft.CodeAnalysis;

namespace FindGenerator;

[Generator]
public partial class FinderGenerator : Generator
{
    private const string FindFieldsGeneratorAttribute = "MediaDevices.FindFieldsGeneratorAttribute";
    private const string EnumGuidAttribute = "MediaDevices.EnumGuidAttribute";
    private const string KeyAttribute = "MediaDevices.KeyAttribute";

    public override void Excecute()
    {
        //Debugger.Launch();

        // for debug only
        //CreateDebug();

        // get all enums with [FindFieldsGeneratorAttribute] 
        foreach (var en in GetAllEnumsWithAttribute(FindFieldsGeneratorAttribute))
        {
            CreateFindEnumFieldsFile(en);
        }

        // get all classes with [FindFieldsGeneratorAttribute] 
        foreach (var cl in GetAllClassesWithAttribute(FindFieldsGeneratorAttribute))
        {
            CreateFindClassFieldsFile(cl);
        }
       
    }
   
}
