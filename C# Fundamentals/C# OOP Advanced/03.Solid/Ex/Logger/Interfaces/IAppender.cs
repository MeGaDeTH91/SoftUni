using LoggerLibrary.Enums;

namespace LoggerLibrary.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(IError error);

        ReportLevel ReportLevel { get; }
    }
}
