using System;

namespace MachinaAurum.Collections
{
    public interface ICollectionsFactory
    {
        ICollection<T> Create<T>(CollectionCapabilities capabilities);
    }

    public enum CollectionCapabilities
    {
        Mutable     = 1,
        Immutable   = 0,

        FowardEnumerable = 2,
        NonFowardEnumerable = 0,

        BackwardEnumerable = 4,
        NonBackwardEnumerable = 0,

        Indexable = 8,
        NonIndexable = 0,

        Expandable = 16,
        NonExpandable = 0
    }
}
