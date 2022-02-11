1. Создайте свой иммутабельный (immutable) тип. При изменении какого-либо из полей создается новый объект. В качестве примера можете взять тип `String`.
2. Попробуйте симитировать наследование и переопределение виртуального метода в структурах.
```c#
class Base
{
  public virtual string GetInfo()
  {
    return "Base class";
  }
}
class A : Base
{
  public override string GetInfo()
  {
    return "A class";
  }
}
...
Base b = new A(); b.GetInfo();
```
