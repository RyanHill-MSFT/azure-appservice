using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LCARS.Core.Data;

namespace Subroutine.Database.Services
{
    public class StorageManager
    {
        private readonly BlobContainerClient containerClient;

        public StorageManager(string accountName, string containerName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentException($"'{nameof(accountName)}' cannot be null or empty.", nameof(accountName));
            }

            if (string.IsNullOrEmpty(containerName))
            {
                throw new ArgumentException($"'{nameof(containerName)}' cannot be null or empty.", nameof(containerName));
            }

            string containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",
                accountName,
                containerName);
            containerClient = new BlobContainerClient(new Uri(containerEndpoint), new DefaultAzureCredential());
        }

        public async Task UploadBlob(string blobName, string blobContents)
        {
            try
            {
                await containerClient.CreateIfNotExistsAsync();

                byte[] byteArray = Encoding.ASCII.GetBytes(blobContents);
                using MemoryStream stream = new MemoryStream(byteArray);
                await containerClient.UploadBlobAsync(blobName, stream);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IDictionary<string, string>> GetBlobsAsync()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            try
            {
                await containerClient.CreateIfNotExistsAsync();

                await foreach (var blob in containerClient.GetBlobsAsync())
                {
                    BlobClient blobClient = containerClient.GetBlobClient(blob.Name);
                    BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();

                    byte[] bytes;
                    using(MemoryStream stream = new MemoryStream())
                    {
                        await downloadInfo.Content.CopyToAsync(stream);
                        bytes = stream.ToArray();
                    }

                    string text = new string(Encoding.ASCII.GetString(bytes));
                    dict.Add(blob.Name, text);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dict;
        }
    }
}
