using System;
namespace Lab1
{
    public class Immutable
    {
        public Immutable()
        {
        }
        public Immutable(string name, int age)
        {
            instance = new();
            instance.name = name;
            instance.age = age;
        }

        private Immutable instance;

        private string name;
        private int age;

        public string Name {
            get => instance.name;
            set => instance = new Immutable(value, instance?.age ?? 0);
        }

        public int Age {
            get => instance.age;
            set => instance = new Immutable(instance?.name ?? "", value);
        }

        //for check
        public int? InstanceHash {get => instance?.GetHashCode();}
    }
}
