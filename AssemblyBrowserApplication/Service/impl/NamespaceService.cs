using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class NamespaceService
{
    public TypeService TypeService { get; }
    public NamespaceService()
    {
        TypeService = new TypeService();
    }
    public List<NamespaceModel> GetNamespaceInfo(Assembly assembly)
    {
        List<NamespaceModel> namespaceInfos = new();
        IEnumerable<string> namespaces = GetNamespaces(assembly);
            
        foreach (var namespaceTitle in namespaces)
        {
            NamespaceModel namespaceModel = new NamespaceModel();
            namespaceModel.Name = namespaceTitle;
            namespaceModel.Types = TypeService.GetTypeInfo(assembly, namespaceTitle);
            namespaceInfos.Add(namespaceModel);
        }
            
        return namespaceInfos;
    }

    private IEnumerable<string?> GetNamespaces(Assembly assembly)
    {
        return assembly.GetTypes().Select(type => type.Namespace).Distinct();
    }
}