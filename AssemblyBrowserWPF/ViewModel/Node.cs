using System.Collections.Generic;

namespace AssemblyBrowserWPF.ViewModel;

public class Node
{
    public string Title { get; set; }
    public List<Node> Nodes { get; set; } = new();
}