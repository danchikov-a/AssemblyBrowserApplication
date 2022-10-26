using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class MethodService
{
    public FieldService FieldService { get; }

    public MethodService()
    {
        FieldService = new FieldService();
    }
    
    public List<MethodModel> GetMethodInfos(Type type)
    {
        List<MethodModel> methodInfos = new();
        var methods = type.GetMethods();
        
        foreach (var method in methods)
        {
            var methodModel = new MethodModel();
            methodModel.Name = method.Name;
            methodModel.Type = method.ReturnType.Name;
            methodModel.Fields = FieldService.GetFieldInfos(method.GetParameters());
            methodInfos.Add(methodModel);
        }
            
        return methodInfos;
    }
}