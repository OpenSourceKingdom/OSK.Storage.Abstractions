﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Storage.Abstractions
{
    /// <summary>
    /// A generic storage object that contains the raw data stream and the metadata for that object
    /// </summary>
    public abstract class StorageObject : IDisposable
    {
        #region Variables

        public Stream Value { get; }

        public StorageMetaData MetaData { get; }

        #endregion

        #region Constructors

        public StorageObject(Stream value, StorageMetaData metaData)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            MetaData = metaData ?? throw new ArgumentNullException(nameof(metaData));
        }

        #endregion

        #region Helpers

        public void Dispose()
        {
            Value?.Dispose();
        }

        /// <summary>
        /// Provides easy access to deserializing the underlying stream into a specified object
        /// </summary>
        /// <typeparam name="T">The expected typed for the stream to be converted to</typeparam>
        /// <returns>The object T if the stream could be successfully deserialized</returns>
        /// <remarks>
        /// Note: This method will close the stream and should only be used with storage objects that
        /// were saved by the storage service otherwise unexpected errors and behavior
        /// may occur
        /// </remarks>
        public abstract ValueTask<T> StreamAsAsync<T>(CancellationToken cancellationToken = default);

        #endregion
    }
}
