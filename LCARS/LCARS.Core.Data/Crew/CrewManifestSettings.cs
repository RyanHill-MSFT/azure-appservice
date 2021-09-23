using System;
using System.Collections.Generic;
using System.Text;

namespace LCARS.Core.Data.Crew
{
    public interface ICrewManifestSettings
    {
        string ConnectionString { get; set; }
        string CrewCollectionName { get; set; }
        string DatabaseName { get; set; }
    }

    public class CrewManifestSettings : ICrewManifestSettings
    {
        public string CrewCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
