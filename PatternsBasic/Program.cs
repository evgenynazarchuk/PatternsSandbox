namespace PatternsBasic
{
    class Program
    {
        static void Main()
        {
            var cat1 = new Cat("cat 1");
            var cat2 = new Cat("cat 2");
            var dog1 = new Dog("dog 1");
            var owner = new PetOwner("owner 1");

            owner.Add(cat1);
            owner.Add(cat2);
            owner.Add(dog1);

            foreach (var pet in owner.Pets)
            {
                pet.Vote();
            }
        }
    }
}
