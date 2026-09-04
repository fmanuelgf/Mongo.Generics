# Mongo.GenericClient

## Release 10.1.5

- Update nuget packages
- Fix recursive call to `Task DeleteAsync(ObjectId[] ids)`

## Release 10.1.4

- Update nuget packages

## Release 10.1.3

- Update nuget packages

## Release 10.1.2

- Update nuget packages

## Release 10.1.1

- Update nuget packages

## Release 10.1.0

- Changes to UpdateAsync

## Release 10.0.1

- Changes to UpdateAsync
- Update nuget packages.

## Release 10.0.0

- Upgrade to dotnet 10

## Release 9.0.4

- Update nuget packages

## Release 9.0.3

- Add MongoClientSettings
- Update nuget packages

## Release 9.0.2

- Add methods to delete an array of documents

## Release 9.0.1

- Update nuget packages

## Release 9.0.0

- Upgrade to dotnet 9

## Release 8.3.0

- Update nuget packages.
- The `AsQueryable()` method now returns an `IQueryable` object instead of the deprecated `IMogoQueryable`

## Release 8.2.0

- Remove obsolete code
- Add method `CountDocuments` to ReadService

## Release 8.1.8

- Add the `RegisterAllGenericServices` extension method

## Release 8.1.7

- Add `IMongoContext` to manage the collections
- Add the `RegisterMongoContext` extension method
- Mark `IGenericRepository` as `Obsolete`
- Mark the `RegisterGenericRepository` extension method as `Obsolete`
- Mark the `RegisterGenericRepositoryAndServices` extension method as `Obsolete`

## Release 8.1.6

- Add static class `MongoHelper`, providing access to `MongoClient` and `IMongoDatabase`
- Minor fixes

## Release 8.1.5

- Add method `DeleteAsync(string id)`

## Release 8.1.4

- Add namespace Mongo.GenericClient.DependencyInjection

## Release 8.1.3

- Add filter parameter to `GetAllAsync` & `GetPaginated` methods
- `GetByIdAsync` method: Id as `ObjectId` or as `string`
