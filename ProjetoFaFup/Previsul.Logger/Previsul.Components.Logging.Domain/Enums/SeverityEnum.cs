namespace Previsul.Components.Logging.Domain.Enums
{
    public enum SeverityEnum : short
    {
        Verbose = 1,
        Information = 2,
        Warning = Information | Verbose,
        Error = 4,
        Critical = Error | Verbose,
    }
}