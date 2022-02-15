namespace Lab1_3_LINQ
{
    public interface INamed
    {
        string Name { get; set; }
    }

    class Person : INamed
    {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
