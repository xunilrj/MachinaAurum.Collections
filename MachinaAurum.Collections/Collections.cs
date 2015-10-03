using System;
using System.Collections;
using System.Collections.Generic;

namespace MachinaAurum.Collections
{
    public interface ICollection
    {
    }

    public interface IImmutableCollection : ICollection
    {

    }

    public interface IExpandableCollection : ICollection
    {
    }
    

    public interface ICollectionReader<out T> : ICollection
    {
    }

    public interface ICollectionWriter<in T> : ICollection
    {

    }

    public interface ISequenceableCollection : ICollection, IEnumerable
    {
    }

    public interface IAllowDuplicates
    {
    }

    public interface IDoesNotAllowDuplicates
    {
    }


    public interface ISequenceableReader<out T> : ISequenceableCollection, IEnumerable<T>
    {
        T First { get; }
    }

    public interface ISequenceableWriter<in T> : ISequenceableCollection, IExpandableCollection
    {
        void AddFirst(T item);
    }

    public interface IExpandableSequencedCollection<T> : IExpandableCollection, ISequenceableWriter<T>
    {
    }

    public interface IFiniteSequenceableReader<out T> : ISequenceableReader<T>
    {
        T Last { get; }
    }

    public interface IFiniteSequenceableWriter<in T> : ISequenceableWriter<T>, IExpandableCollection
    {
        void AddLast(T item);
    }

    public interface IIndexeable : ICollection
    {

    }

    public interface IIndexeableReader<TIndex, out T> : IIndexeable, ICollectionReader<T>
    {
        IIndexeableResult<T> this[TIndex index] { get; }
    }

    public interface IIndexeableWriter<TIndex, in T> : IIndexeable, ICollectionWriter<T>
    {
        IIndexeableResult<T> this[TIndex index] { set; }
    }

    public interface IIndexeableResult<out T>
    {
        bool Found { get; }
        T Value { get; }
    }

    public struct IndexeableResult<T> : IIndexeableResult<T>
    {
        public bool Found { get; private set; }
        public T Value { get; private set; }

    }

    public static class IndexeableExtensions
    {
        public class AtGetOptions
        {
            internal AtGetOptionsEnum Action { get; private set; }
            public object Value { get; private set; }

            public AtGetOptions()
            {
                Throw<ArgumentOutOfRangeException>();
            }

            public void Throw<T>() where T : new()
            {
                Action = AtGetOptionsEnum.Throw;
                Value = new T();
            }

            public void Throw(Exception e)
            {
                Action = AtGetOptionsEnum.Throw;
                Value = e;
            }

            public void Return(object value)
            {
                Action = AtGetOptionsEnum.ReturnValue;
                Value = value;
            }
        }

        internal enum AtGetOptionsEnum
        {
            Throw,
            ReturnValue
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TIndex"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="indexeable"></param>
        /// <param name="at"></param>
        /// <param name="whenFail"></param>
        /// <returns></returns>
        public static TValue At<TIndex, TValue>(this IIndexeableReader<TIndex, TValue> indexeable, TIndex at, Action<AtGetOptions> whenFail = null)
        {
            var result = indexeable[at];

            if (result.Found)
            {
                return result.Value;
            }
            else
            {
                var options = new AtGetOptions();

                if (whenFail != null)
                {
                    whenFail(options);
                }

                switch (options.Action)
                {
                    case AtGetOptionsEnum.Throw: throw (options.Value as Exception);
                    case AtGetOptionsEnum.ReturnValue: return (TValue)options.Value;
                }

                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <typeparam name="TIndex"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="indexeable"></param>
        /// <param name="at"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue At<TIndex, TValue>(this IIndexeableReader<TIndex, TValue> indexeable, TIndex at, TValue value)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExtensibleSequencedExplicitly<T> : ICollection, ISequenceableReader<T>, ISequenceableWriter<T>
    {

    }

    public interface IExtensibleUnsequenced<T> : ICollection
    {
    }

    public interface ISequenceImmutable<T> : IImmutableCollection, ISequenceableReader<T>
    {

    }

    public interface IExtensibleSequencedImplicitly<T> : ICollection, ISequenceableReader<T>, ISequenceableWriter<T>
    {

    }

    public interface ISequencedExplicitly<T> : ICollection, ISequenceableReader<T>
    {
    }

    public interface IHeap : IExtensibleSequencedImplicitly<object>
    {

    }

    public interface ISortedCollection<T> : IExtensibleSequencedImplicitly<T>, IIndexeable
    {

    }

    public interface IArray<T> : ISequencedExplicitly<T>, IIndexeable
    {

    }

    public interface IInterval<T> : ISequenceImmutable<T>, IIndexeableReader<int, T>
    {

    }

    public interface ILinkedList<T> : IExtensibleSequencedExplicitly<T>
    {

    }

    public interface IOrderedCollection<T> : IExtensibleSequencedExplicitly<T>, IIndexeableReader<int, T>, IIndexeableWriter<int, T>, IFiniteSequenceableReader<T>, IFiniteSequenceableWriter<T>
    {
    }

    public interface IWeakArray : IArray<object>
    {

    }

    public interface IBag<T> : IExtensibleUnsequenced<T>, IAllowDuplicates
    {

    }

    public interface IDictionary<Tkey, TValue> : IExtensibleUnsequenced<TValue>, IIndexeable, IAllowDuplicates
    {

    }

    public interface ISet<T> : IExtensibleUnsequenced<T>, IDoesNotAllowDuplicates
    {

    }

    public interface ISkipList<T> : IExtensibleUnsequenced<T>
    {

    }

    public interface IIdentityBag<T> : IBag<T>
    {

    }

    public interface IWeakSet<T> : ISet<T>
    {

    }

    public interface IIdentitySet<T> : ISet<T>
    {

    }

    public interface IPluggableSet<T> : ISet<T>
    {

    }

    public interface IPluggableDictionary<Tkey, TValue> : IDictionary<Tkey, TValue>
    {

    }

    public interface IIdentityDictionary<Tkey, TValue> : IDictionary<Tkey, TValue>
    {

    }

    public interface IWeakKeyDictionary<Tkey, TValue> : IDictionary<Tkey, TValue>
    {

    }

    public interface IWeakValueDictionary<Tkey, TValue> : IDictionary<Tkey, TValue>
    {

    }

    public interface IIdentitySkipList<T> : ISkipList<T>
    {

    }

    public interface IWeakIdentityKeyDictionary<Tkey, TValue> : IWeakKeyDictionary<Tkey, TValue>
    {
    }
}
