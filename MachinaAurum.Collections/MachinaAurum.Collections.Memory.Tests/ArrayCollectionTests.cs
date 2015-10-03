using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MachinaAurum.Collections.Memory.Tests
{
    [TestClass]
    public class ArrayCollectionTests
    {
        [TestMethod]
        public void ArrayCollectionMustBeAbleToInsertAndRemoveItems()
        {
            var factory = new MemoryCollectionsFactory();
            var collection = factory.Create<int>(x => x.AddMutability());

            AssertCanInsertAndRemove(collection);
        }

        private static void AssertCanInsertAndRemove(ICollection<int> collection)
        {
            var inserted = 0;

            collection.TryInsert(inserted);
            var removed = collection.TryRemove();

            Assert.AreEqual(inserted, removed);
        }
    }
}
