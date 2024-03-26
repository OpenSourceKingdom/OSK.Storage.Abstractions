using OSK.Functions.Outputs.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlankStudios.Common.Storage.Abstractions
{
    public interface IStorageService<TSaveOptions, TSearchOptions>
        where TSaveOptions: class
        where TSearchOptions : class
    {
        Task<IOutput<StorageMetaData>> SaveAsync<T>(T data, string fullStoragePath, TSaveOptions options = null, CancellationToken cancellationToken = default);
        Task<IOutput<StorageObject>> GetAsync(string fullStoragePath, CancellationToken cancellationToken = default);
        Task<IOutput<IEnumerable<StorageMetaData>>> GetStorageDetailsAsync(string directoryPath, TSearchOptions options = null, CancellationToken cancellationToken = default);
        Task<IOutput> DeleteAsync(string fullStoragePath, CancellationToken cancellationToken = default);
    }
}
