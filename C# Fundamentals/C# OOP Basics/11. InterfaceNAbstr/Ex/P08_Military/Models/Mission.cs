using System;

public class Mission : IMission
{
    private string codeName;
    private StateType state;

    public Mission(string codeName, StateType state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName
    {
        get
        {
            return this.codeName;
        }
        private set
        {
            this.codeName = value;
        }
    }
    public StateType State
    {
        get
        {
            return this.state;
        }
        set
        {
            this.state = value;
        }
    }
    public override string ToString()
    {
        return $"  Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}
