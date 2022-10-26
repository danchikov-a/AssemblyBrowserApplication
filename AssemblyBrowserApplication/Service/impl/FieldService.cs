using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class FieldService
{
    public List<FieldModel> GetFieldInfos(Type type)
    {
        List<FieldModel> fieldInfos = new();
        var fields = type.GetFields();

        foreach (var field in fields)
        {
            var fieldModel = new FieldModel();
            fieldModel.Name = field.Name;
            fieldModel.Type = field.FieldType.Name;
            
            fieldInfos.Add(fieldModel);
        }

        return fieldInfos;
    }

    public List<FieldModel> GetFieldInfos(ParameterInfo[] parameterInfos)
    {
        List<FieldModel> fieldInfos = new();
        
        foreach (var parameterInfo in parameterInfos)
        {
            var fieldModel = new FieldModel();
            
            fieldModel.Name = parameterInfo.Name;
            fieldModel.Type = parameterInfo.ParameterType.Name;
            
            fieldInfos.Add(fieldModel);
        }

        return fieldInfos;
    }
}