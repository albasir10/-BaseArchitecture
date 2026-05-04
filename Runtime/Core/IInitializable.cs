using Cysharp.Threading.Tasks;
using UnityEngine;

namespace albatroneer.Core
{
    public interface IInitializable
    {
        UniTask<bool> TryInit();
    }
}
