namespace CustomAttributesStudy
{
    [MyAttribute("MyClass", Abbreviation = "MyCls")]
    public class MyClass
    {
        [MyAttribute("MyValue", Abbreviation = "MV")]
        public string? Value { get; set; }
    }
}
