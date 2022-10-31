using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class TypeService
{
    private FieldService _fieldService = new ();
    private PropertyService _propertyService = new ();
    private MethodService _methodService = new ();
    
    public List<TypeModel> GetTypeInfo(Assembly assembly, string namespaceTitle)
    {
        List<TypeModel> typeInfos = new();
        var types = assembly.GetTypes().Where(type => namespaceTitle == type.Namespace);

        foreach (var type in types)
        {
            var typeModel = new TypeModel();

            typeModel.Fields = _fieldService.GetFieldInfos(type);
            typeModel.Properties = _propertyService.GetPropertyInfos(type);
            typeModel.Methods = _methodService.GetMethodInfos(type);
            typeModel.Name = type.Name;
            typeModel.Type = ChooseType(type);

            typeInfos.Add(typeModel);
        }

        return typeInfos;
    }

    private string ChooseType(Type type)
    {
        if (type.IsClass)
        {
            return "Class";
        }

        if (type.IsInterface)
        {
            return "Interface";
        }

        if (type.IsEnum)
        {
            return "Enum";
        }

        throw new Exception();
    }
}