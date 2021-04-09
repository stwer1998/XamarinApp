namespace XamarinToDoApp.Attribute
{
    public class XamarinFormComponentAttribute : System.Attribute
    {
        public string ComponentName { get; set; }

        public bool IsPassword { get; set; }

        public XamarinFormComponentAttribute(string componentName, bool isPassword = false)
        {
            ComponentName = componentName;
            IsPassword = isPassword;
        }
    }
}
