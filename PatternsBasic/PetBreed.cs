using System;

namespace PatternsBasic
{
    public class PetBreed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PetBreed(Guid? id = null, string name = "default")
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
        }
    }

    public static class DefaultPetBreed
    {
        public static Guid Id = Guid.Parse("6F9619FF-8B86-D011-B42D-00CF4FC964FF");
    }
}
