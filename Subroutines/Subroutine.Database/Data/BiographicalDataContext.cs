using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LCARS.Core.Data;
using LCARS.Core.Data.Federation;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Subroutine.Database.Services;

namespace Subroutine.Database.Data
{
    public class BiographicalDataContext
    {
        private readonly StorageManager _storageManager;

        public BiographicalDataContext(IOptions<AzureStorageConfig> config)
        {
            var azureStorageConfig = config.Value;
            _storageManager = new StorageManager(azureStorageConfig.AccountName, azureStorageConfig.ContainerName);
        }

        public async Task CreateBiographicalDataProfile(BiographicalData biography)
        {
            var contents = JsonConvert.SerializeObject(biography);
            await _storageManager.UploadBlob(biography.Name, contents);
        }

        public async Task<IList<BiographicalData>> GetBiographicalDataProfileAsync()
        {
            var dict = await _storageManager.GetBlobsAsync();
            var biographicalProfiles = new List<BiographicalData>();
            foreach (var item in dict)
            {
                var biographicalProfile = JsonConvert.DeserializeObject<BiographicalData>(item.Value);
                biographicalProfiles.Add(biographicalProfile);
            }

            return biographicalProfiles;
        }
    }
}
