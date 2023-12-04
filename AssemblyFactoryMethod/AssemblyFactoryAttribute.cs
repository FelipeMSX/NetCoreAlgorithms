namespace AssemblyFactoryMethod
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AssemblyFactoryAttribute : Attribute
    {
        public Type EnumType { get; private set; }
        public string Name { get; private set; }

        public AssemblyFactoryAttribute(Type enumType, string name)
        {
            EnumType = enumType;
            Name = name;
        }
    }
}
