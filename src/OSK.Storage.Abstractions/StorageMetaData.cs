using System;
using System.IO;

namespace OSK.Storage.Abstractions
{
    /// <summary>
    /// Information relating to data that has been saved to a storage medium
    /// </summary>
    public class StorageMetaData
    {
        #region Variables

        public string FileName => Path.GetFileNameWithoutExtension(FullStoragePath);
        public string StorageDirectory => Path.GetDirectoryName(FullStoragePath);
        public string Extension => Path.GetExtension(FullStoragePath);

        public string FullStoragePath { get; }

        /// <summary>
        /// Whether the content is encrypted and must be decrypted to be usable
        /// </summary>
        public bool IsEncrypted { get; }

        /// <summary>
        /// The byte size of the content
        /// </summary>
        public long ContentSize { get; }

        /// <summary>
        /// The media type for the document being retrieved. See https://developer.mozilla.org/en-US/docs/Web/HTTP/MIME_types for more information.
        /// </summary>
        public string StorageMimeType { get; internal set; }

        public DateTime LastModifiedTimeUtc { get; }

        #endregion

        #region Constructors

        public StorageMetaData(string storagePath, long contentSize, bool isEncrypted,
            string mimeType, DateTime dateTimeUtcSinceLastUpdateTime)
        {
            FullStoragePath = storagePath;
            ContentSize = contentSize;
            IsEncrypted = isEncrypted;
            StorageMimeType = mimeType;
            LastModifiedTimeUtc = dateTimeUtcSinceLastUpdateTime;
        }

        #endregion
    }
}
