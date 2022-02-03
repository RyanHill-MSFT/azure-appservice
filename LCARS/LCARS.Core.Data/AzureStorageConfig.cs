using System;
using System.Collections.Generic;
using System.Text;

namespace LCARS.Core.Data
{
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}
