using System;

namespace MachinaAurum.Collections
{
    interface ICollectionsFactory
    {
        TForm Create<TForm>(params Type[] capabilities);
    }
}
