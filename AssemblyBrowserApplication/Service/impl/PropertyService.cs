using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class PropertyService
{
    public List<PropertyModel> GetPropertyInfos(Type type)
    {
        return type.GetProperties().
            Select(property => new PropertyModel {Name = property.Name, Type = property.PropertyType.Name}).
            ToList();
    }
}