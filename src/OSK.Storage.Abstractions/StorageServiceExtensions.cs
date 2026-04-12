using OSK.Operations.Outputs;
using OSK.Operations.Outputs.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Storage.Abstractions;

public static class StorageServiceExtensions
{
    /// <summary>
    /// Provides a direct way to retrieve an object of T, without needing any additional calls to the underlying storage object by the consumer that will raise errors through the IOutput response
    /// </summary>
    /// <typeparam name="TValue">The value type the storage object is expected to be</typeparam>
    /// <param name="storageService">The storage service used to make the call</param>
    /// <param name="fullStoragePath">The full path to the object location</param>
    /// <param name="cancellationToken">The token for operation cancellation</param>
    /// <returns>An <see cref="Output{TValue}"></see> containing the object if successful or standard error information if not</returns>
    public static async Task<Output<TValue>> GetAsync<TValue>(this IStorageService storageService, string fullStoragePath, CancellationToken cancellationToken = default)
    {
        try
        {
            var getOutput = await storageService.GetAsync(fullStoragePath, cancellationToken);
            if (getOutput.IsSuccessful)
            {
                var item = await getOutput.Data.StreamAsAsync<TValue>(cancellationToken);
                return Out.Success(item);
            }

            return getOutput.As<TValue>();
        }
        catch (Exception ex)
        {
            return Out.Fault<TValue>(ex);
        }
    }
}
