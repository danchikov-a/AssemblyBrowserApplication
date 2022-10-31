using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class MethodService
{
    private FieldService _fieldService = new();
    
    public List<MethodModel> GetMethodInfos(Type type)
    {
        return type.GetMethods().
            Select(method => new MethodModel {Name = method.Name, 
                Type = method.ReturnType.Name, Fields = _fieldService.GetFieldInfos(method.GetParameters())}).
            ToList();
    }
}