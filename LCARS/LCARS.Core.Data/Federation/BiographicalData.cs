﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LCARS.Core.Data.Federation
{
    public class BiographicalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Occupation { get; set; }
    }
}
