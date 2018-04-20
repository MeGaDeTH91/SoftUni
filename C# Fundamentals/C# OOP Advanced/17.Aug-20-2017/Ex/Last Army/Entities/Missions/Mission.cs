using System;

public abstract class Mission : IMission
{
    public string Name { get; protected set; }

    private double scoreToComplete;

    public Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public double EnduranceRequired { get; protected set; }

    public double ScoreToComplete
    {
        get { return this.scoreToComplete; }
        private set { this.scoreToComplete = value; }
    }

    public double WearLevelDecrement { get; protected set; }
}
