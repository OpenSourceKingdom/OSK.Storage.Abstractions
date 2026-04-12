using OSK.Operations.Outputs.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Storage.Abstractions;

/// <summary>
/// A storage service is capable of saving data to some sort of storage system, be it local or cloud based.
/// </summary>
public interface IStorageService
{
    Task<Output<StorageObject>> GetAsync(string fullStoragePath, CancellationToken cancellationToken = default);
}
