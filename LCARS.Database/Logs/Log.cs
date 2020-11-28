using System;

namespace LCARS.Database.Logs
{
    public abstract class Log
    {
        public int Id { get; set; }

        public DateTime Stardate { get; set; } = DateTime.Now;

        public AccessLevel AccessLevel { get; set; }
    }

    public enum AccessLevel
    {
        Supplemental,
        Personal,
        Command,
        Captain
    }
}