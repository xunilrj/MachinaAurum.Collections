using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MachinaAurum.Collections.Tests
{
    [TestClass]
    public class CollectionsTaxonomyTests
    {
        [TestMethod]
        public void SequenceableCollections()
        {
            AssertIs<IInterval<object>, ISequenceableCollection>();
            AssertIs<ISortedCollection<object>, ISequenceableCollection>();
            AssertIs<IArray<object>, ISequenceableCollection>();
            AssertIs<IOrderedCollection<object>, ISequenceableCollection>();

            AssertIs<ILinkedList<object>, ISequenceableCollection>();
        }

        [TestMethod]
        public void NonSequenceableCollections()
        {
            AssertIsNot<IDictionary<string, object>, ISequenceableCollection>();
            AssertIsNot<IIdentityDictionary<string, object>, ISequenceableCollection>();
            AssertIsNot<IPluggableDictionary<string, object>, ISequenceableCollection>();

            AssertIsNot<ISet<object>, ISequenceableCollection>();
            AssertIsNot<IIdentitySet<object>, ISequenceableCollection>();
            AssertIsNot<IPluggableSet<object>, ISequenceableCollection>();
            AssertIsNot<IBag<object>, ISequenceableCollection>();
            AssertIsNot<IIdentityBag<object>, ISequenceableCollection>();
        }

        [TestMethod]
        public void IndexeableCollections()
        {
            AssertIs<IInterval<object>, IIndexeable>();
            AssertIs<ISortedCollection<object>, IIndexeable>();
            AssertIs<IArray<object>, IIndexeable>();
            AssertIs<IOrderedCollection<object>, IIndexeable>();

            AssertIs<IDictionary<string, object>, IIndexeable>();
            AssertIs<IIdentityDictionary<string, object>, IIndexeable>();
            AssertIs<IPluggableDictionary<string, object>, IIndexeable>();
        }

        [TestMethod]
        public void NonIndexeableCollections()
        {
            AssertIsNot<ILinkedList<object>, IIndexeable>();

            AssertIsNot<ISet<object>, IIndexeable>();
            AssertIsNot<IIdentitySet<object>, IIndexeable>();
            AssertIsNot<IPluggableSet<object>, IIndexeable>();
            AssertIsNot<IBag<object>, IIndexeable>();
            AssertIsNot<IIdentityBag<object>, IIndexeable>();
        }

        [TestMethod]
        public void ExpansableCollections()
        {
            AssertIs<ISortedCollection<object>, IExpandableCollection>();
            AssertIs<IOrderedCollection<object>, IExpandableCollection>();
            AssertIs<ILinkedList<object>, IExpandableCollection>();
        }

        [TestMethod]
        public void NonExpansableCollections()
        {
            AssertIsNot<IInterval<object>, IExpandableCollection>();
            AssertIsNot<IArray<object>, IExpandableCollection>();
        }

        [TestMethod]
        public void ImmutableCollections()
        {
            AssertIs<IInterval<object>, IImmutableCollection>();
            //AssertIs<ISymbol<object>, IImmutableCollection>();
        }

        [TestMethod]
        public void MutableCollections()
        {
            AssertIsNot<ISortedCollection<object>, IImmutableCollection>();
            AssertIsNot<IArray<object>, IImmutableCollection>();
            AssertIsNot<IOrderedCollection<object>, IImmutableCollection>();
            AssertIsNot<ILinkedList<object>, IImmutableCollection>();
            AssertIsNot<IDictionary<string, object>, IImmutableCollection>();
            AssertIsNot<IIdentityDictionary<string, object>, IImmutableCollection>();
            AssertIsNot<IPluggableDictionary<string, object>, IImmutableCollection>();
            AssertIsNot<ISet<object>, IImmutableCollection>();
            AssertIsNot<IIdentitySet<object>, IImmutableCollection>();
            AssertIsNot<IPluggableSet<object>, IImmutableCollection>();
            AssertIsNot<IBag<object>, IImmutableCollection>();
            AssertIsNot<IIdentityBag<object>, IImmutableCollection>();
        }

        void AssertIs(Type derived, Type @base)
        {
            Assert.IsTrue(@base.IsAssignableFrom(derived));
        }

        [TestMethod]
        public void AllowDuplicatesCollections()
        {
            AssertIs<IDictionary<int, object>, IAllowDuplicates>();
            AssertIs<IBag<object>, IAllowDuplicates>();

            AssertIsNot<IDictionary<int, object>, IDoesNotAllowDuplicates>();
            AssertIsNot<IBag<object>, IDoesNotAllowDuplicates>();
        }

        [TestMethod]
        public void DoesNotAllowDuplicatesCollections()
        {
            AssertIsNot<ISet<object>, IAllowDuplicates>();

            AssertIs<ISet<object>, IDoesNotAllowDuplicates>();
        }


        void AssertIs<TDerived, TBase>()
        {
            AssertIs(typeof(TDerived), typeof(TBase));
        }

        void AssertIsNot(Type derived, Type @base)
        {
            Assert.IsFalse(@base.IsAssignableFrom(derived));
        }

        void AssertIsNot<TDerived, TBase>()
        {
            AssertIsNot(typeof(TDerived), typeof(TBase));
        }
    }
}
