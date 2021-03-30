using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LCARS.Core.Data.Crew;

namespace LCARS.Core.Data.Logs
{
    /*
     * https://memory-alpha.fandom.com/wiki/Log
     */
    public abstract class Starlog
    {
        protected Starlog()
        {
            Startdate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public LogEntryType LogType { get; protected set; }

        public bool Deleted { get; set; }

        public DateTime Startdate { get; protected set; }

        public string Vessel { get; set; }
    }

    public enum LogEntryType
    {
        Positional,
        Ship,
        Station
    }
}
