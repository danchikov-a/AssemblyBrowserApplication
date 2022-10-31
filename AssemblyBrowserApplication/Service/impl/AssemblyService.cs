using System.Reflection;
using AssemblyBrowserApplication.Model;

namespace AssemblyBrowserApplication.Service.impl;

public class AssemblyServiceImpl : IService
{
    private const string ASSEMBLY_ERROR_MESSAGE = "There isn't such assembly";
    private string _assemblyPath;
    private NamespaceService _namespaceService = new();
    
    public AssemblyServiceImpl(string assemblyPath)
    {
        _assemblyPath = assemblyPath;
    }

    public AssemblyModel GetAssemblyInfo()
    {
        try
        {
            var assemblyModel = new AssemblyModel();
            var assembly = Assembly.LoadFrom(_assemblyPath);
            assemblyModel.Namespacies = _namespaceService.GetNamespaceInfo(assembly);
            
            return assemblyModel;
        }
        catch (Exception)
        {
            throw new Exception(ASSEMBLY_ERROR_MESSAGE);
        }
    }
}