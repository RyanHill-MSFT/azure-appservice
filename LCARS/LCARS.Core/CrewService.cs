using System;
using System.Collections.Generic;
using LCARS.Core.Data.Crew;
using MongoDB.Driver;

namespace LCARS.Core
{
    public class CrewService
    {
        private readonly IMongoCollection<Officer> _crew;

        public CrewService(ICrewManifestSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _crew = database.GetCollection<Officer>(settings.CrewCollectionName);
        }

        public IList<Officer> Get() => _crew.Find(officer => true).ToList();

        public Officer Get(string serialNo) => _crew.Find(officer=> officer.SerialNo == serialNo).FirstOrDefault();

        public Officer Create(Officer officer)
        {
            _crew.InsertOneAsync(officer);
            return officer;
        }

        public void Update(string serialNo, Officer officerToUpdate) => _crew.ReplaceOne(officer => officer.SerialNo == serialNo, officerToUpdate);

        public void Remove(Officer officer) => Remove(officer.SerialNo);
        
        public void Remove(string serialNo) => _crew.DeleteOne(officer=> officer.SerialNo == serialNo);
    }
}
