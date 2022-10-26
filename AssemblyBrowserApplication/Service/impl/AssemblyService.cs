using System.Reflection;
using AssemblyBrowserApplication.Model;

namespace AssemblyBrowserApplication.Service.impl;

public class AssemblyServiceImpl : IService
{
    private const string ASSEMBLY_ERROR_MESSAGE = "There isn't such assembly";
    
    public string AssemblyPath
    {
        get;
    }

    public NamespaceService NamespaceService
    {
        get;
    }

    public AssemblyServiceImpl(string assemblyPath)
    {
        AssemblyPath = assemblyPath;
        NamespaceService = new NamespaceService();
    }

    private Assembly GetAssembly()
    {
        Assembly assembly;
        
        try
        {
            assembly = Assembly.LoadFrom(AssemblyPath);
        }
        catch (Exception)
        {
            throw new Exception(ASSEMBLY_ERROR_MESSAGE);
        }

        return assembly;
    }

    public AssemblyModel GetAssemblyInfo()
    {
        var assemblyModel = new AssemblyModel();
        var assembly = GetAssembly();
        
        assemblyModel.Namespacies = NamespaceService.GetNamespaceInfo(assembly);
        
        return assemblyModel;
    }
}