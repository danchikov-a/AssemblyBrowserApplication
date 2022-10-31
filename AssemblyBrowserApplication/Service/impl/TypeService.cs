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
        var types = assembly.GetTypes().Where(type => namespaceTitle == type.Namespace);

        return types.Select(type => new TypeModel
            {
                Fields = _fieldService.GetFieldInfos(type),
                Properties = _propertyService.GetPropertyInfos(type),
                Methods = _methodService.GetMethodInfos(type),
                Name = type.Name,
                Type = ChooseType(type)
            })
            .ToList();
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