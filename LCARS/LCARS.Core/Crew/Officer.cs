using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LCARS.Core.Logs;

namespace LCARS.Core.Crew
{
    public class Officer
    {
        public string SerialNo { get; set; }

        public StarfleetRank Rank { get; set; }

        public string FirstName {get;set;}

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Assignment { get; set; }

        public string Station { get; set; }

        public DepartmentArea Department { get; set; }

        public void Promote()
        {
            if (Rank < StarfleetRank.Admiral)
            {
                Rank += 1;
            }
        }

        public void Demote() 
        {
            if(Rank > StarfleetRank.Crewman)
            {
                Rank -= 1;
            }
        }
    }

    public enum StarfleetRank
    {
        Crewman,
        [Description("Ens.")]
        Ensign,
        [Description("Lt")]
        Lieutenant,
        [Description("Lt. Cmdr.")]
        LieutenantCommander,
        [Description("Cmdr.")]
        Commander,
        [Description("Capt.")]
        Captain,
        [Description("Admr.")]
        Admiral
    }

    public enum DepartmentArea
    {
        Science,
        Operations,
        Command,
        Sciences
    }
}
