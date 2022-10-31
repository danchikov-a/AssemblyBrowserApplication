using AssemblyBrowserApplication.Model;
using AssemblyBrowserApplication.Service.impl;
using NUnit.Framework;

namespace AssemblyBrowserTest;

public class AssemblyBrowserTests
{
    private readonly AssemblyServiceImpl _assemblyService = new("AssemblyBrowserApplication.dll");
    private AssemblyModel _assemblyInfo = new ();
    private const int MODEL_NAMESPACE = 4;
    private const int ASSEMBLY_MODEL_CLASS = 0;
    
    [SetUp]
    public void Setup()
    {
        _assemblyInfo = _assemblyService.GetAssemblyInfo();
    }

    [Test]
    public void NamespaceAmountTest()
    {
        Assert.AreEqual(6, _assemblyInfo.Namespacies.Count);
    }

    [Test]
    public void NamespaceNameTest()
    {
        Assert.AreEqual("AssemblyBrowserApplication.Model", _assemblyInfo.Namespacies[MODEL_NAMESPACE].Name);
    }

    [Test]
    public void TypesAmountTest()
    {
        Assert.AreEqual(2, _assemblyInfo.Namespacies[MODEL_NAMESPACE].Types.Count);
    }
    
    [Test]
    public void PropertiesAmountTest()
    {
        Assert.AreEqual(1, _assemblyInfo.Namespacies[MODEL_NAMESPACE].Types[ASSEMBLY_MODEL_CLASS].Properties.Count);
    }

    [Test]
    public void MethodInformationMethodCountTest()
    {
        Assert.AreEqual(6, _assemblyInfo.Namespacies[MODEL_NAMESPACE].Types[ASSEMBLY_MODEL_CLASS].Methods.Count);
    }
}