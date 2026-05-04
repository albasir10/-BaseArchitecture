using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace albatroneer.Core
{
    public abstract class AbstractEntryPoint : IAsyncStartable
    {
        public async Awaitable StartAsync(CancellationToken ct)
        {
            await Run(ct);
        }

        protected abstract UniTask Run(CancellationToken ct);
    }
}

