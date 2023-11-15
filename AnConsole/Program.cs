﻿using System;
using AnConsole;
// the ourAnimals array will store the following: 

public class Program
{
    public static void Main(String[] args)
    {
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";

        // variables that support data entry
        int maxPets = 20;
        string? readResult;
        string menuSelection = "";

        // array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 6];
        
        do
        {
            // display the top-level menu options

            Console.Clear();
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Console PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Get your animal information");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal’s age");
            Console.WriteLine(" 6. Edit an animal’s personality description");
            Console.WriteLine(" 7. Display all cats with a specified characteristic");
            Console.WriteLine(" 8. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
                // NOTE: We could put a do statement around the menuSelection entry to ensure a valid entry, but we
                //  use a conditional statement below that only processes the valid entry values, so the do statement 
                //  is not required here. 
            }

            // use switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // List all of our current pet information

                    DB.GetAll();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // Add a new animal friend to the ourAnimals array
                    string anotherPet = "y";
                    int petCount = 0;

                    /*for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            petCount += 1;
                        }
                    }*/

                    if (petCount > maxPets)
                    {
                        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                    }

                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        bool validEntry = false;

                        // get species (cat or dog) - string animalSpecies is a required field 
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.ToLower();
                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    //Console.WriteLine($"You entered: {animalSpecies}.");
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        // get the pet's age. can be ? at initial entry.
                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        } while (animalPhysicalDescription == "");

                        // get a description of the pet's personality - animalPersonalityDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (animalPersonalityDescription == "")
                                {
                                    animalPersonalityDescription = "tbd";
                                }
                            }
                        } while (animalPersonalityDescription == "");

                        // get the pet's nickname. animalNickname can be blank.
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }
                        } while (animalNickname == "");

                        // store the pet information in the ourAnimals array (zero based)           

                        // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                        petCount = petCount + 1;
                        // save data
                        Console.WriteLine("Would you love to save it? (y/n");
                        readResult = Console.ReadLine();
                        if (readResult == "y")
                        {
                            //int animalId = Int32.Parse(animalID);
                            Pet pet = new Pet(animalSpecies, animalAge, animalPhysicalDescription, animalPersonalityDescription, animalNickname);
                            DB.AddPet(pet);
                        }
                        // check maxPet limit
                        if (petCount < maxPets)
                        {
                            // another pet?
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            do
                            {
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    anotherPet = readResult.ToLower();
                                }

                            } while (anotherPet != "y" && anotherPet != "n");
                        }
                    }

                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                    }

                    break;

                case "3":
                    // Ensure animal ages and physical descriptions are complete
                    string petNickName;
                    string userInput;
                    Console.WriteLine("Enter your pet's NickName: ");
                    userInput = Console.ReadLine();
                    if (userInput != null)
                    {
                        petNickName = userInput.ToString();
                        DB.getPet(petNickName);
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "4":
                    // Ensure animal nicknames and personality descriptions are complete
                    Console.WriteLine("Challenge Project - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "5":
                    // Edit an animal’s age");
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "6":
                    // Edit an animal’s personality description");
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "7":
                    // Display all cats with a specified characteristic
                    string specie = Console.ReadLine();
                    DB.getCats(specie);
                    readResult = Console.ReadLine();
                    break;

                case "8":
                    // Display all dogs with a specified characteristic
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");
    }
}

