namespace AssemblyBrowserApplication.Model.impl;

public class TypeModel : IModel
{
    public List<FieldModel> Fields
    {
        get; set;
    }

    public List<PropertyModel> Properties
    {
        get; set;
    }

    public List<MethodModel> Methods
    {
        get; set;
    }
}