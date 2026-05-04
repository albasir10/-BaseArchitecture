using Cysharp.Threading.Tasks;
using UnityEngine;

namespace albatroneer.Core
{
    /// <summary>
    /// custom MonoBehaviour with need functions, not use Awake/Start. Only Init()
    /// </summary>
    public abstract class AbstractMonoBehaviour : MonoBehaviour, IInitializable
    {
        protected bool IsInitialized = false;

        /// <summary>
        /// Not Use, Use Init()
        /// </summary>
        protected void Awake()
        {
            return;
        }

        /// <summary>
        /// Not Use, Use Init()
        /// </summary>
        protected void Start()
        {
            return;
        }

        public async UniTask<bool> TryInit()
        {
            if (IsInitialized || !await Init())
            {
                return false;
            }
            
            IsInitialized = true;
            
            return true;
        }

        protected abstract UniTask<bool> Init();

        protected void OnDestroy()
        {
            Dispose();
        }

        protected virtual void Dispose()
        {
            
        }

    }
}

