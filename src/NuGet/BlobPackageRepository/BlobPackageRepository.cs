using Microsoft.Azure.Storage.Blob;
using NuGet.Client;
using NuGet;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;

public class BlobPackageRepository : NuGet.Core.Repositories.IPackageRepository
{
    private CloudBlobContainer _container;

    public BlobPackageRepository(Uri containerUri)
    {
        var bareContainerUri = ToContainerUri(containerUri);
        _source = bareContainerUri.ToString();
        var sasToken = containerUri.Query;

        if (string.IsNullOrEmpty(sasToken))
        {
            _container = new CloudBlobContainer(bareContainerUri);
        }
        else
        {
            _container = new CloudBlobContainer(bareContainerUri, new StorageCredentials(sasToken));
        }
    }

    public static Uri ToContainerUri(Uri uri)
    {
        var pathPart = uri.AbsolutePath.ToLower().TrimEnd('/');
        return new UriBuilder(uri.Scheme, uri.Host, uri.Port, pathPart).Uri;
    }

    public BlobPackageRepository(string containerName, string connectionString)
    {
        var account = CloudStorageAccount.Parse(connectionString);
        _container = account.CreateCloudBlobClient().GetContainerReference(containerName);

        _container.CreateIfNotExists();

        _source = _container.Uri.ToString();
    }
}
