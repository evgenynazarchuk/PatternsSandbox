using System;

namespace PatternsBasic
{
    public class Cat : PetAnimal
    {
        public Cat(string name,
            PetBreed petBreed = null,
            PetCharacteristics petCharacteristics = null)
            : base(name, petBreed, petCharacteristics)
        { }

        public virtual void Meow()
        {
            Console.WriteLine("Meow");
        }

        public override void Vote() => Meow();
    }
}
