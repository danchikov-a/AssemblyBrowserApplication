using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyBrowserApplication.Service.impl;
using AssemblyBrowserWPF.Annotations;
using Microsoft.Win32;

namespace AssemblyBrowserWPF.ViewModel;

public class AssemblyViewModel: INotifyPropertyChanged
{
    private string _filePath;
    private NodeConverter _nodeConverter = new();
    public List<Node> Nodes
    {
        get;
        set;
    }
    public ICommand OpenFileCommand => new OpenFileCommand(_ => OpenAssembly());

    private void OpenAssembly()
    {
        var fileDialog = new OpenFileDialog
        {
            Filter = "Assemblies|*.dll",
            Title = "Select assembly",
            Multiselect = false
        };

        var isOpen = fileDialog.ShowDialog() ;

        if (isOpen == null || !isOpen.Value)
        {
            return;
        }

        _filePath = fileDialog.FileName;
        OnPropertyChanged(nameof(_filePath));
        CheckNodes();
    }

    private void CheckNodes()
    {
        AssemblyServiceImpl assemblyService = new(_filePath); 
        Nodes = _nodeConverter.Convert(assemblyService.GetAssemblyInfo());
        
        OnPropertyChanged(nameof(Nodes));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}