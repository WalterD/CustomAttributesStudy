using CustomAttributesStudy;
using System.Linq.Expressions;
using System.Reflection;

// 1. Get MyAttribute attribute for MyClass - no class instance needed.
var myAttribute = (MyAttribute?)Attribute.GetCustomAttribute(typeof(MyClass), typeof(MyAttribute));
Console.WriteLine($"FriendlyName 1 = {myAttribute?.FriendlyName}");
Console.WriteLine($"Abbreviation 1 = {myAttribute?.Abbreviation}");

// 2. Get MyAttribute attribute for MyClass  - get attribute having an instance of MyClass class.
var myClass = new MyClass();
myAttribute = (MyAttribute?)Attribute.GetCustomAttribute(myClass.GetType(), typeof(MyAttribute));
Console.WriteLine($"FriendlyName 2 = {myAttribute?.FriendlyName}");
Console.WriteLine($"Abbreviation 2 = {myAttribute?.Abbreviation}");

// 3. Get MyAttribute attribute for property "Value"
myAttribute = typeof(MyClass).GetProperty(nameof(MyClass.Value))
                            ?.GetCustomAttribute<MyAttribute>();
Console.WriteLine($"FriendlyName 3 = {myAttribute?.FriendlyName}");
Console.WriteLine($"Abbreviation 3 = {myAttribute?.Abbreviation}");


// 4. List attributes.
var attributes = GetPropertyAttributes<MyClass, MyAttribute>(x => x.Value)?.ToList();
Console.WriteLine($"\n\nAttributes listing, count={attributes?.Count}");
foreach (var item in attributes ?? new())
{
    Console.WriteLine($"FriendlyName = {item.FriendlyName}, Abbreviation = {item.Abbreviation}");
}

return;



/// <summary>
/// Get property's attributes. There could be multiple attributes of the same type decorating a property.
/// </summary>
/// <param name="expression">Property.</param>
static TAttributeType[]? GetPropertyAttributes<TClassType, TAttributeType>
    (
    Expression<Func<TClassType, object?>> expression
    )
    where TClassType : class 
    where TAttributeType : Attribute
{
    if (expression?.Body is MemberExpression memberExpression)
    {
        //var propertyInfo = (PropertyInfo)memberExpression.Member;
        //return propertyInfo?.GetCustomAttribute<TAttributeType>();
        //return memberExpression.Member.GetCustomAttribute<TAttributeType>();
        return memberExpression.Member.GetCustomAttributes<TAttributeType>().ToArray();
    }

    return default;
}
