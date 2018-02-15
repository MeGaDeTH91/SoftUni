using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> hospital = new List<Department>();

            string input;
            while((input = Console.ReadLine()) != "Output")
            {
                string[] currentTokens = input
                                         .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

                string currDepartmentName = currentTokens[0];
                string currDoctorNames = $"{currentTokens[1]} {currentTokens[2]}";
                string currPatient = currentTokens[3];

                if(!hospital.Any(x => x.DepartmentName == currDepartmentName))
                {
                    Department newDepartment = new Department
                    {
                        DepartmentName = currDepartmentName,
                        Doctors = new List<Doctor>(),
                        DepartmentRooms = new List<Room>()
                    };
                    Room firstRoom = new Room
                    {
                        Number = 1,
                        FreeBeds = 2,
                        Patients = new List<string>()
                    };
                    newDepartment.DepartmentRooms.Add(firstRoom);
                    newDepartment.DepartmentRooms[0].Patients.Add(currPatient);
                    newDepartment.FreeBeds--;

                    Doctor currDoc = new Doctor
                    {
                        FullName = currDoctorNames,
                        Patients = new List<string>()
                    };
                    currDoc.Patients.Add(currPatient);
                    newDepartment.Doctors.Add(currDoc);
                    hospital.Add(newDepartment);
                }
                else
                {
                    Department currDepartment = hospital.FirstOrDefault(x => x.DepartmentName == currDepartmentName);
                    if(!currDepartment.Doctors.Any(x => x.FullName == currDoctorNames) && currDepartment.FreeBeds > 0)
                    {
                        Doctor currDoc = new Doctor
                        {
                            FullName = currDoctorNames,
                            Patients = new List<string>()
                        };
                        currDoc.Patients.Add(currPatient);
                        currDepartment.Doctors.Add(currDoc);

                        var neededRoom = currDepartment.DepartmentRooms.Last();
                        int oldRoomNumber = neededRoom.Number;

                        if (neededRoom.FreeBeds == 0)
                        {
                            Room newRoom = new Room
                            {
                                FreeBeds = 3,
                                Number = oldRoomNumber + 1,
                                Patients = new List<string>()
                            };
                            newRoom.Patients.Add(currPatient);
                            newRoom.FreeBeds--;
                            currDepartment.FreeBeds--;
                            currDepartment.DepartmentRooms.Add(newRoom);
                        }
                        else
                        {
                            neededRoom.Patients.Add(currPatient);
                            neededRoom.FreeBeds--;
                            currDepartment.FreeBeds--;
                        }
                    }
                    else if(currDepartment.FreeBeds > 0)
                    {
                        var desiredDoc = currDepartment.Doctors.FirstOrDefault(x => x.FullName == currDoctorNames);

                        desiredDoc.Patients.Add(currPatient);

                        var neededRoom = currDepartment.DepartmentRooms.Last();
                        int oldRoomNumber = neededRoom.Number;

                        if(neededRoom.FreeBeds == 0)
                        {
                            Room newRoom = new Room
                            {
                                FreeBeds = 3,
                                Number = oldRoomNumber + 1,
                                Patients = new List<string>()
                            };
                            newRoom.Patients.Add(currPatient);
                            newRoom.FreeBeds--;
                            currDepartment.FreeBeds--;
                            currDepartment.DepartmentRooms.Add(newRoom);
                        }
                        else
                        {
                            neededRoom.Patients.Add(currPatient);
                            neededRoom.FreeBeds--;
                            currDepartment.FreeBeds--;
                        }
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

                switch (tokens.Length)
                {
                    case 1:
                        string seekDep = tokens[0];

                        Department seekDepartment = hospital.FirstOrDefault(x => x.DepartmentName == seekDep);

                        foreach (var room in seekDepartment.DepartmentRooms)
                        {
                            foreach (var patient in room.Patients)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                        break;
                    case 2:
                        string firstArg = tokens[0];

                        int roomNum;
                        bool isItRoomNum = int.TryParse(tokens[1], out roomNum);
                        if (isItRoomNum)
                        {
                            string printDep = firstArg;
                            Department desiredDep = hospital.FirstOrDefault(x => x.DepartmentName == printDep);
                            Room desiredRoom = desiredDep.DepartmentRooms.FirstOrDefault(x => x.Number == roomNum);

                            foreach (var patient in desiredRoom.Patients.OrderBy(x => x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                        else
                        {
                            string doctorName = $"{firstArg} {tokens[1]}";

                            List<string> patients = new List<string>();
                            foreach (var dep in hospital)
                            {
                                Doctor curr = dep.Doctors.FirstOrDefault(x => x.FullName == doctorName);

                                if(curr != null)
                                {
                                    patients.AddRange(curr.Patients);
                                }
                                
                            }

                            patients = patients.OrderBy(x => x).ToList();
                            Console.WriteLine(string.Join(Environment.NewLine, patients));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public class Department
    {
        public string DepartmentName { get; set; }

        public List<Doctor> Doctors { get; set; }

        public List<Room> DepartmentRooms { get; set; } = new List<Room>();

        public int FreeBeds { get; set; } = 60;
    }
    public class Doctor
    {
        public string FullName { get; set; }

        public List<string> Patients { get; set; }
    }
    public class Room
    {
        public int Number { get; set; }
        public List<string> Patients { get; set; }
        public int FreeBeds { get; set; } = 3;
    }
}
