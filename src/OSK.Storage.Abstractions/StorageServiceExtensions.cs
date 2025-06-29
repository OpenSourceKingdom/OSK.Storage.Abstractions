using System;
using System.Threading;
using System.Threading.Tasks;
using OSK.Functions.Outputs.Abstractions;

namespace OSK.Storage.Abstractions
{
    public static class StorageServiceExtensions
    {
        /// <summary>
        /// Provides a direct way to retrieve an object of T, without needing any additional calls to the underlying storage object by the consumer that will raise errors through the IOutput response
        /// </summary>
        /// <typeparam name="TSaveOptions">The service save option type</typeparam>
        /// <typeparam name="TSearchOptions">The service search option type</typeparam>
        /// <typeparam name="TValue">The value type the storage object is expected to be</typeparam>
        /// <param name="storageService">The storage service used to make the call</param>
        /// <param name="fullStoragePath">The full path to the object location</param>
        /// <param name="outputFactory">The output factory to generate an error response in case of a failure</param>
        /// <param name="cancellationToken">The token for operation cancellation</param>
        /// <returns>An <see cref="IOutput{TValue}"></see> containing the object if successful or standard error information if not</returns>
        public static async Task<IOutput<TValue>> GetAsync<TSaveOptions, TSearchOptions, TValue>(this IStorageService<TSaveOptions, TSearchOptions> storageService,
            string fullStoragePath, IOutputFactory outputFactory, CancellationToken cancellationToken = default)
            where TSaveOptions : class
            where TSearchOptions : class
        {
            try
            {
                var getResult = await storageService.GetAsync(fullStoragePath, cancellationToken);
                if (getResult.IsSuccessful)
                {
                    var item = await getResult.Value.StreamAsAsync<TValue>(cancellationToken);
                    return outputFactory.Succeed(item);
                }

                return getResult.AsOutput<TValue>();
            }
            catch (Exception ex)
            {
                return outputFactory.Exception<TValue>(ex);
            }
        }
    }
}
