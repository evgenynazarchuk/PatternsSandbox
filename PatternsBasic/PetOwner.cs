using System;
using System.Collections.Generic;

namespace PatternsBasic
{
    public class PetOwner
    {
        public readonly Guid Id;
        public readonly string FullName;
        public readonly List<PetAnimal> Pets;

        public PetOwner(string fullName)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Pets = new List<PetAnimal>();
        }

        public void Add(PetAnimal petAnimal)
        {
            Pets.Add(petAnimal);
        }
    }
}
