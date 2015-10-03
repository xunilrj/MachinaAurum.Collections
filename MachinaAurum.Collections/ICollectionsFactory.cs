using System;

namespace MachinaAurum.Collections
{
    public interface ICollectionsFactory
    {
        ICollection<T> Create<T>(CollectionOptions options);
    }

    public static class CollectionsFactoryExtensions
    {
        public static ICollection<T> Create<T>(this ICollectionsFactory factory, Action<CollectionOptions> configure = null)
        {
            var options = new CollectionOptions();

            if (configure != null)
            {
                configure(options);
            }

            return factory.Create<T>(options);
        }
    }

    public class CollectionOptions
    {
        System.Collections.Generic.ICollection<ICollectionCapability> Capabilities;

        public CollectionOptions()
        {
            Capabilities = new System.Collections.Generic.LinkedList<ICollectionCapability>();
        }

        public void Add(ICollectionCapability capability)
        {
            Capabilities.Add(capability);
        }
    }

    public interface ICollectionCapability
    {
    }

    public class MutabilityOptions : ICollectionCapability
    {

    }

    public static class CollectionOptionsExtensions
    {
        public static CollectionOptions AddMutability(this CollectionOptions options, Action<MutabilityOptions> configure = null)
        {
            var mutabilityOptions = new MutabilityOptions();

            if (configure != null)
            {
                configure(mutabilityOptions);
            }

            options.Add(mutabilityOptions);

            return options;
        }
    }

    public enum CollectionCapabilities
    {
        Mutable = 1,
        Immutable = 0,

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
