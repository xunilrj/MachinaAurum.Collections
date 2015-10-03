using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MachinaAurum.Collections.Memory
{
    public class MemoryCollectionsFactory : ICollectionsFactory
    {
        public MemoryCollectionsFactory()
        {
            RegisterCatalog();
        }

        public ICollection<T> Create<T>(CollectionOptions options)
        {
            return new MemoryArray<T>();
        }

        private void RegisterCatalog()
        {
        }
    }

    public class MemoryArray<T> : IArray<T>
    {
        T[] Array;
        int FirstNullPosition;

        public MemoryArray()
        {
            Array = new T[10];
            FirstNullPosition = 0;
        }

        T ISequenceableReader<T>.First
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void ICollectionWriter<T>.BestInsertion(T item)
        {
            var pos = Interlocked.Increment(ref FirstNullPosition);
            Array[pos - 1] = item;
        }

        T ICollectionReader<T>.BestRemove()
        {
            var pos = Interlocked.Decrement(ref FirstNullPosition);
            return Array[pos + 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
