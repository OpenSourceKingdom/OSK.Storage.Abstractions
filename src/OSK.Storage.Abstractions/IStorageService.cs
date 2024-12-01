using OSK.Functions.Outputs.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Storage.Abstractions
{
    /// <summary>
    /// A storage service is capable of saving data to some sort of storage system, be it local or cloud based.
    /// </summary>
    /// <typeparam name="TSaveOptions">The specific save type options a storage service uses</typeparam>
    /// <typeparam name="TSearchOptions">Specific search filtering options that can be applied to the storage service</typeparam>
    public interface IStorageService<TSaveOptions, TSearchOptions>
        where TSaveOptions : class
        where TSearchOptions : class
    {
        Task<IOutput<StorageMetaData>> SaveAsync<T>(T data, string fullStoragePath, TSaveOptions options = null, CancellationToken cancellationToken = default);
        Task<IOutput<StorageObject>> GetAsync(string fullStoragePath, CancellationToken cancellationToken = default);
        Task<IOutput<IEnumerable<StorageMetaData>>> GetStorageDetailsAsync(string directoryPath, TSearchOptions options = null, CancellationToken cancellationToken = default);
        Task<IOutput> DeleteAsync(string fullStoragePath, CancellationToken cancellationToken = default);
    }
}
