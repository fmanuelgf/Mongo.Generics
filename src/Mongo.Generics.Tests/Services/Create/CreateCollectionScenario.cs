namespace Mongo.Generics.Tests.Services.Create
{
    using Mongo.Generics.Tests.Base;
    using Mongo.Generics.Tests.SetUp;
    using MongoDB.Driver;

    public class CreateCollectionScenario : ScenarioBase<PersonEntity>
    {
        private List<PersonEntity> personEntities;

        public CreateCollectionScenario()
            : base()
        {
            this.personEntities = new List<PersonEntity>();
        }

        public void CreatePersonEntities(int number)
        {
            this.personEntities = DataFactory.BuildRandomPersonsList(number);
        }

        public async Task RunMethodAsync(string method)
        {
            switch (method)
            {
                case "CreateAsync":
                    await this.WriteService.CreateAsync(this.personEntities.First());
                    break;

                default:
                    throw new ArgumentException($"Unknown method {method}");
            }
        }

        public void CheckCollectionIsCreated()
        {
            Assert.That(
                this.Repository.Collection.CountDocuments(Builders<PersonEntity>.Filter.Empty),
                Is.GreaterThan(0)
            );
        }

        public void CheckCollectionCount(int expectedCount)
        {
            Assert.That(
                this.Repository.Collection.CountDocuments(Builders<PersonEntity>.Filter.Empty),
                Is.EqualTo(expectedCount)
            );
        }
    }
}