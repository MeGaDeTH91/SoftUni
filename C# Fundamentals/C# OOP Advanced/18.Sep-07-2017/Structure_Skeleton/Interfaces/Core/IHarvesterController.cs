using System.Collections.Generic;

public interface IHarvesterController : IController
{
    double TotalOreProduced { get; }

    string ChangeMode(string mode);

    IReadOnlyCollection<IEntity> Entities { get; }
}