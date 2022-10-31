using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class FieldService
{
    public List<FieldModel> GetFieldInfos(Type type)
    {
        return type.GetFields().Select(field => new FieldModel {Name = field.Name, Type = field.FieldType.Name})
            .ToList();
    }

    public List<FieldModel> GetFieldInfos(ParameterInfo[] parameterInfos)
    {
        return parameterInfos.
            Select(parameterInfo => new FieldModel {Name = parameterInfo.Name, Type = parameterInfo.ParameterType.Name})
            .ToList();
    }
}