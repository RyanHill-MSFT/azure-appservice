namespace LCARS.Database.Logs
{
    public class Personal : Log
    {
        public Personal()
        {
            AccessLevel = AccessLevel.Personal;
        }

        public string Entry { get; private set; }

        public string Officer { get; private set; }

        public static Personal Supplemental(string entry, string officer)
        {
            return new Personal
            {
                Entry = entry,
                Officer = officer,
                AccessLevel = AccessLevel.Supplemental
            };
        }

        public static Personal CaptainsLog(string entry)
        {
            return new Personal
            {
                Entry = entry,
                AccessLevel = AccessLevel.Captain
            };
        }
    }
}
