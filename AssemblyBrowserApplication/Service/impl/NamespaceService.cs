using System.Reflection;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class NamespaceService
{
    private TypeService _typeService = new ();
    
    public List<NamespaceModel> GetNamespaceInfo(Assembly assembly)
    {
        IEnumerable<string> namespaces = assembly.GetTypes().Select(type => type.Namespace).Distinct();

        return namespaces.
            Select(namespaceTitle =>
                new NamespaceModel {Name = namespaceTitle, Types = _typeService.GetTypeInfo(assembly, namespaceTitle)})
            .ToList();
    }
}