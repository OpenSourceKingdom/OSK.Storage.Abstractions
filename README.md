# OSK.Storage.Abstractions
A set of abstractions for saving and loading object data from storage in .NET. Implementations will need to add logic for `IStorageService`
and `StorageObejct` classes, which represents the main APIs users will access to get infromation and other data relating to their storage objects.
`IStorageService` should be the single point in which users interact with the library or other implementations.

# Contributions and Issues
Any and all contributions are appreciated! Please be sure to follow the branch naming convention OSK-{issue number}-{deliminated}-{branch}-{name} as current workflows rely on it for automatic issue closure. Please submit issues for discussion and tracking using the github issue tracker.