namespace FactoryMethodPattern
{
    public class AirplanFactory : Factory
    {
        public override Transport Create() => new Airplan();
    }
}
