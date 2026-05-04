using System.Threading;
using UnityEngine;
using VContainer.Unity;

namespace albatroneer.Core
{
    public abstract class AbstractEntryPoint : IAsyncStartable
    {
        public abstract Awaitable StartAsync(CancellationToken ct);
    }
}

