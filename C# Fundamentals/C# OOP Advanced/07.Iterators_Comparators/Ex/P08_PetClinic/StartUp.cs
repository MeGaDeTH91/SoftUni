using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Clinic> clinics = new List<Clinic>();
        List<Pet> pets = new List<Pet>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentLine = Console.ReadLine().Split();

            string currentCommand = currentLine[0];

            try
            {
                switch (currentCommand)
                {
                    case "Create":
                        string itemToCreate = currentLine[1];
                        string name = currentLine[2];
                        
                        if (itemToCreate.Equals("Pet"))
                        {
                            int age = int.Parse(currentLine[3]);
                            string kind = currentLine[4];

                            Pet petToAdd = new Pet(name, age, kind);
                            pets.Add(petToAdd);
                        }
                        else
                        {
                            int roomNumber = int.Parse(currentLine[3]);

                            Clinic clinicToAdd = new Clinic(name, roomNumber);
                            clinics.Add(clinicToAdd);
                        }
                        break;
                    case "Add":
                        string addPetName = currentLine[1];
                        string addClinicName = currentLine[2];

                        Pet accomodatePet = pets.FirstOrDefault(x => x.Name == addPetName);
                        Clinic accomodateClinic = clinics.FirstOrDefault(x => x.Name == addClinicName);

                        bool isAccomodateSuccess = accomodateClinic.Accomodate(accomodatePet);

                        Console.WriteLine(isAccomodateSuccess);
                        break;
                    case "Release":
                        string releaseAnimalClinic = currentLine[1];
                        Clinic releaseClinic = clinics.FirstOrDefault(x => x.Name == releaseAnimalClinic);
                        bool isAnimalReleased = releaseClinic.Release();

                        Console.WriteLine(isAnimalReleased);
                        break;
                    case "HasEmptyRooms":
                        string hasClinicEmptyRooms = currentLine[1];
                        Clinic freeRoomClinic = clinics.FirstOrDefault(x => x.Name == hasClinicEmptyRooms);

                        bool hasEmptyRooms = freeRoomClinic.HasEmptyRooms();

                        Console.WriteLine(hasEmptyRooms);
                        break;
                    case "Print":
                        string printClinicName = currentLine[1];
                        Clinic printClinic = clinics.FirstOrDefault(x => x.Name == printClinicName);

                        if(currentLine.Length == 2)
                        {
                            printClinic.Print();
                        }
                        else
                        {
                            int roomNumber = int.Parse(currentLine[2]);
                            printClinic.Print(roomNumber);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
