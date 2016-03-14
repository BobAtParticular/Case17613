using System;
using Raven.Server;
using Raven.Tests.Helpers;
using Xunit;

namespace Case17613.RavenDbTest
{
    public class SerializeDecimalMinValueTest : RavenTestBase
    {
        [Fact]
        public void CanStoreDecimalWithMinValue()
        {
            using (var store = NewRemoteDocumentStore())
            {
                var docId = $"EntityWithDecimalMinValueProperty/{Guid.NewGuid()}";

                using (var session = store.OpenSession())
                {
                    session.Store(new EntityWithDecimalMinValueProperty
                    {
                        Value = decimal.MinValue
                    }, docId);

                    session.SaveChanges();
                }

                using (var session = store.OpenSession())
                {
                    var result = session.Load<EntityWithDecimalMinValueProperty>(docId);

                    Assert.Equal(result.Value, decimal.MinValue);
                }
            }
        }
    }

    public class EntityWithDecimalMinValueProperty
    {
        public decimal Value { get; set; }
    }
}