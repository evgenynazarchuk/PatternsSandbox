using System;

namespace PatternsBasic
{
    public class Dog : PetAnimal
    {
        public Dog(string name, 
            PetBreed petBreed = null, 
            PetCharacteristics petCharacteristics = null)
            : base(name, petBreed, petCharacteristics)
        { }

        public virtual void Woof()
        {
            Console.WriteLine("Woof");
        }

        public override void Vote() => Woof();
    }
}
