namespace CustomAttributesStudy
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class MyAttribute : Attribute
    {
        public MyAttribute(string friendlyName)
        {
            this.FriendlyName = friendlyName;
        }

        public string FriendlyName { get; }

        public string? Abbreviation { get; set; }
    }
}
