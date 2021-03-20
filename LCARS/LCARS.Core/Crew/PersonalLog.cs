using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Logs;

namespace LCARS.Core.Crew
{
    public class PersonalLog : Starlog
    {
        public PersonalLog()
        {
            LogType = LogEntryType.Positional;
        }

        public string Title { get; set; }

        public string Entry { get; set; }

        public static PersonalLog CaptainsLog(string entry, PersonalLogType type) => new PersonalLog
        {
            Title = $"Captain's Log, {type}",
            Entry = entry
        };
    }

    public enum PersonalLogType
    {
        Personal,
        Supplemental
    }
}
