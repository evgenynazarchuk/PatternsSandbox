namespace FactoryMethodPattern
{
    public class CarFactory : Factory
    {
        public override Transport Create() => new Car();
    }
}
