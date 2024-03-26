using System;
using System.IO;

namespace OSK.Storage.Abstractions
{
    public class StorageMetaData
    {
        #region Variables

        public string FileName => Path.GetFileNameWithoutExtension(FullStoragePath);
        public string StorageDirectory => Path.GetDirectoryName(FullStoragePath);
        public string Extension => Path.GetExtension(FullStoragePath);

        public string FullStoragePath { get; }

        public bool IsEncrypted { get; }

        public long ContentSize { get; }

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
