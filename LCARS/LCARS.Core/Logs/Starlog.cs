using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LCARS.Core.Crew;

namespace LCARS.Core.Logs
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

        public long StarlogId { get; set; }

        public DateTime Startdate { get; protected set; }

        public LogEntryType LogType { get; protected set;  }

        public bool? IsDeleted { get; set; }

        public Officer Officer { get; set; }

        public string Vessel { get; set; }
    }

    public enum LogEntryType
    {
        Positional,
        Ship,
        Station
    }
}
