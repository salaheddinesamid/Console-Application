using System;
namespace AnConsole
{
    public class Pet
    {

        public string Species { get; set; }
        public string Age { get; set; }
        public string Physic { get; set; }
        public string Personal { get; set; }
        public string NickName { get; set; }

        public Pet(string species, string age, string physicalDesc,
            string personalDesc, string nickName)
        {

            Species = species;
            Age = age;
            Physic = physicalDesc;
            Personal = personalDesc;
            NickName = nickName;
        }
        public void getPetInfo()
        {
            Console.WriteLine($"NickName: {NickName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Species : {Species}");
            Console.WriteLine($"Pyhsical Condition : {Physic}");
            Console.WriteLine($"Personality: {Personal}");
        }
    }
}

