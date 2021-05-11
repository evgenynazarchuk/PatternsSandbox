namespace PatternsBasic
{
    public interface IPetAnimal
    {
        PetCharacteristics PetCharacteristics { get; }
        PetBreed PetBreed { get; }
        void Vote();
        void UpdateCharacteristics(PetCharacteristics petCharacteristics);
    }
}
