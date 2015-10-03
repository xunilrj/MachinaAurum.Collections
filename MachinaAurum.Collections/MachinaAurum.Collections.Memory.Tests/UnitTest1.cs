using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MachinaAurum.Collections.Memory.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var factory = new MemoryCollectionsFactory();
            var collection = factory.Create<int>(CollectionCapabilities.Mutable | CollectionCapabilities.NonExpandable);

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
