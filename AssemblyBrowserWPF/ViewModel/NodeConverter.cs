using System.Collections.Generic;
using System.Linq;
using AssemblyBrowserApplication.Model;
using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserWPF.ViewModel;

public class NodeConverter
{
    public List<Node> Convert(AssemblyModel assemblyInfo)
    {
        return assemblyInfo.Namespacies.
            Select(namespaceInfo => 
                new Node {Title = $"Namespace: {namespaceInfo.Name}", Nodes = GetTypeNodes(namespaceInfo.Types)})
            .ToList();
    }

    private List<Node> GetTypeNodes(List<TypeModel> types)
    {
        return types.Select(typeInfo => new Node {Title = $"{typeInfo.Type} {typeInfo.Name}", 
            Nodes = GetTypeElementsNodes(typeInfo)})
            .ToList();
    }

    private List<Node> GetTypeElementsNodes(TypeModel type)
    {
        var nodes = type.Fields.Select(fieldInfo => 
            new Node {Title = $"Field: {fieldInfo.Type} {fieldInfo.Name}"})
            .ToList();
        
        nodes.AddRange(type.Properties.Select(propertyInfo =>
            new Node {Title = $"Property: {propertyInfo.Type} {propertyInfo.Name}"}));

        nodes.AddRange(type.Methods.Select(methodInfo => 
            new Node {Title = $"Method: {methodInfo.Type} {methodInfo.Name}()", Nodes = GetParamNodesForMethodNode(methodInfo)}));

        return nodes;     
    }

    private List<Node> GetParamNodesForMethodNode(MethodModel method)
    {
        return method.Fields
            .Select(fieldInfo => new Node {Title = $"Param: {fieldInfo.Type} {fieldInfo.Name}"})
            .ToList();
    }
}