using System;
using System.Linq;

public class Clinic
{
    private bool AccomodateRightOfCenter = false;
    private bool ReleaseRightOfCenter = true;
    private const string emptyRoomMessage = "Room empty";
    private int indexDiff = 1;

    private string name;
    private Pet[] rooms;
    private int capacity;

    private int StartIndex => (this.Capacity / 2);
    private int currentIndex;

    public Clinic(string name, int capacity)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.rooms = new Pet[Capacity];
        this.currentIndex = this.StartIndex;
    }

    public bool Accomodate(Pet pet)
    {
        if (IsIndexValid(this.currentIndex))
        {
            if (IsThisRoomFree(this.currentIndex))
            {
                this.rooms[this.currentIndex] = pet;
                
                if (this.AccomodateRightOfCenter)
                {
                    this.currentIndex = this.StartIndex + indexDiff;
                    this.AccomodateRightOfCenter = false;
                    this.indexDiff++;
                }
                else
                {
                    this.currentIndex = this.StartIndex - indexDiff;
                    this.AccomodateRightOfCenter = true;
                }
                return true;
            }
        }
        return false;
    }
    public bool Release()
    {
        bool isPetFound = false;
        bool loopIsFinished = false;

        int releaseIndex = this.StartIndex;
        if(this.rooms.Length == 1)
        {
            if(this.rooms[0] == default(Pet))
            {
                return false;
            }
            return true;
        }

        while (!loopIsFinished && !isPetFound)
        {
            if (IsIndexValid(releaseIndex) && ReleaseRightOfCenter)
            {
                CheckForPetAndRelease(ref isPetFound, ref releaseIndex);
            }
            else if(releaseIndex < this.StartIndex && !ReleaseRightOfCenter)
            {
                if (releaseIndex == this.StartIndex - 1)
                {
                    loopIsFinished = true;
                }
                CheckForPetAndRelease(ref isPetFound, ref releaseIndex);
            }
            else
            {
                releaseIndex = 0;
                ReleaseRightOfCenter = false;
            }
        }

        return isPetFound;
    }
    public void Print()
    {
        foreach (var room in this.rooms)
        {
            if (ThereIsNoPetInRoom(room))
            {
                Console.WriteLine(emptyRoomMessage);
            }
            else
            {
                Console.WriteLine(room);
            }
        }
    }
    
    public void Print(int room)
    {
        Pet pet = this.rooms[room - 1];
        if (ThereIsNoPetInRoom(pet))
        {
            Console.WriteLine(emptyRoomMessage);
        }
        else
        {
            Console.WriteLine(pet);
        }
    }
    
    public bool HasEmptyRooms()
    {
        return this.rooms.Any(x => x == default(Pet));
    }

    private static bool ThereIsNoPetInRoom(Pet pet)
    {
        return pet == default(Pet);
    }

    private void CheckForPetAndRelease(ref bool isPetFound, ref int releaseIndex)
    {
        if (!IsThisRoomFree(releaseIndex))
        {
            this.rooms[releaseIndex] = default(Pet);
            isPetFound = true;
        }
        else
        {
            releaseIndex++;
        }
    }

    private bool IsThisRoomFree(int index)
    {
        return this.rooms[index] == default(Pet);
    }


    private bool IsIndexValid(int index)
    {
        return index >= 0 && index < this.rooms.Length;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        private set
        {
            if(value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            capacity = value;
        }
    }
}
