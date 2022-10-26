using AssemblyBrowserApplication.Model.impl;

namespace AssemblyBrowserApplication.Service.impl;

public class PropertyService
{
    public List<PropertyModel> GetPropertyInfos(Type type)
    {
        List<PropertyModel> propertyInfos = new();
        var properties = type.GetProperties();
        
        foreach (var property in properties)
        {
            var propertyModel = new PropertyModel();
            
            propertyModel.Name = property.Name;
            propertyModel.Type = property.PropertyType.Name;
            
            propertyInfos.Add(propertyModel);
        }
            
        return propertyInfos;
    }
}