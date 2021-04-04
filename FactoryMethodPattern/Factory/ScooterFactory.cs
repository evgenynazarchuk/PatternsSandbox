namespace FactoryMethodPattern
{
    public class ScooterFactory : Factory
    {
        public override Transport Create() => new Scooter();
    }
}
