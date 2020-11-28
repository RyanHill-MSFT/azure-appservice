namespace LCARS.Database.Logs
{
    public class PersonalLog : Log
    {
        public PersonalLog()
        {
            AccessLevel = AccessLevel.Personal;
        }

        public string Entry { get; private set; }

        public string Officer { get; private set; }

        public static PersonalLog Supplemental(string entry, string officer)
        {
            return new PersonalLog
            {
                Entry = entry,
                Officer = officer,
                AccessLevel = AccessLevel.Supplemental
            };
        }

        public static PersonalLog CaptainsLog(string entry)
        {
            return new PersonalLog
            {
                Entry = entry,
                AccessLevel = AccessLevel.Captain
            };
        }
    }
}
