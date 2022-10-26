using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class TypeService
{
    public FieldService FieldService { get; set; }
    public PropertyService PropertyService { get; set; }
    public MethodService MethodService { get; set; }

    public TypeService()
    {
        FieldService = new FieldService();
        PropertyService = new PropertyService();
        MethodService = new MethodService();
    }

    public List<TypeModel> GetTypeInfo(Assembly assembly, string namespaceTitle)
    {
        List<TypeModel> typeInfos = new();
        var types = assembly.GetTypes().Where(type => namespaceTitle == type.Namespace);

        foreach (var type in types)
        {
            var typeModel = new TypeModel();

            typeModel.Fields = FieldService.GetFieldInfos(type);
            typeModel.Properties = PropertyService.GetPropertyInfos(type);
            typeModel.Methods = MethodService.GetMethodInfos(type);
            typeModel.Name = type.Name;
            typeModel.Type = ChooseType(type);

            typeInfos.Add(typeModel);
        }

        return typeInfos;
    }

    private String ChooseType(Type type)
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