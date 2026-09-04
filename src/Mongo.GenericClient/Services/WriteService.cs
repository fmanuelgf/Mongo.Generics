namespace Mongo.GenericClient.Services
{
    using System.Threading.Tasks;
    using Mongo.GenericClient.Core;
    using Mongo.GenericClient.Core.Entities;
    using Mongo.GenericClient.Core.Services;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class WriteService<TEntity> : IWriteService<TEntity>
        where TEntity : IEntity
    {
        private readonly IMongoCollection<TEntity> collection;

        public WriteService(IMongoContext context)
        {
            this.collection = context.GetCollection<TEntity>();
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.Id = ObjectId.GenerateNewId();
            await this.collection
                .InsertOneAsync(entity);

            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>
                .Filter
                .Eq(x => x.Id, entity.Id);

            var result = await this.collection
                .UpdateOneAsync(
                    filter, 
                    new BsonDocument("$set", entity.ToBsonDocument())
                );

            return result.ModifiedCount == 1;
        }

        /// <inheritdoc />
        public virtual async Task<bool> UpdateAsync(ObjectId id, Dictionary<string, object> data)
        {
            var filter = Builders<TEntity>
                .Filter
                .Eq(x => x.Id, id);
            
            var result = await this.collection
                .UpdateOneAsync(
                    filter, 
                    new BsonDocument("$set", data.ToBsonDocument())
                );

            return result.ModifiedCount == 1;
        }

        /// <inheritdoc />
        public virtual async Task<bool> UpdateAsync(string id, Dictionary<string, object> data)
        {
            var objectId = id.ToObjectId();
            var filter = Builders<TEntity>
                .Filter
                .Eq(x => x.Id, objectId);
            
            var result = await this.collection
                .UpdateOneAsync(
                    filter, 
                    new BsonDocument("$set", data.ToBsonDocument())
                );

            return result.ModifiedCount == 1;
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<TEntity>
                .Filter
                .Eq(x => x.Id, id);

            var result = await this.collection
                .DeleteOneAsync(filter);
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException($"'{id}' is not a valid ObjectId");
            }
            
            await this.DeleteAsync(objectId);
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(ObjectId[] ids)
        {
            await this.DeleteAsync(ids.ToList());
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(IList<ObjectId> ids)
        {
            var filter = Builders<TEntity>
                .Filter
                .Where(x => ids.Contains(x.Id));

            var result = await this.collection
                .DeleteManyAsync(filter);
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(string[] ids)
        {
            await this.DeleteAsync(ids.ToList());
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(IList<string> ids)
        {
            var objIds = new List<ObjectId>();
            foreach (var id in ids)
            {
                if (!ObjectId.TryParse(id, out var objectId))
                {
                    throw new ArgumentException($"'{id}' is not a valid ObjectId");
                }

                objIds.Add(objectId);
            }
            
            await this.DeleteAsync(objIds);
        }
    }
}