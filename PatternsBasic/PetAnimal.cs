namespace PatternsBasic
{
    public abstract class PetAnimal : IPetAnimal
    {
        public readonly string Name;
        public PetCharacteristics PetCharacteristics { get; private set; }
        public PetBreed PetBreed { get; private set; }

        public PetAnimal(string name = "Unknow", 
            PetBreed petBreed = null,
            PetCharacteristics petCharacteristics = null)
        {
            Name = name;
            PetCharacteristics = petCharacteristics ?? new();
            PetBreed = petBreed ?? new(DefaultPetBreed.Id);
        }

        public abstract void Vote();

        public void UpdateCharacteristics(PetCharacteristics petCharacteristics)
        {
            PetCharacteristics = petCharacteristics;
        }
    }
}
