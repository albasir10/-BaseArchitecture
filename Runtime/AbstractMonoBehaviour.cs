using UnityEngine;

namespace albatroneer.CoreArchitecture
{
    /// <summary>
    /// custom MonoBehaviour with need functions, not use Awake/Start. Only Init()
    /// </summary>
    public abstract class AbstractMonoBehaviour : MonoBehaviour
    {
        [Range(0, 100)]
        [SerializeField] private int _priority;

        public int Priority => _priority;

        protected bool _isInit = false;
        

        [field: SerializeField] public bool IsInject { get; private set; } = true; 

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

        public void TryInit()
        {
            if (_isInit)
            {
                return;
            }

            Init();
            
            _isInit = true;
        }

        protected abstract void Init();

        protected void OnDestroy()
        {
            Dispose();
        }

        protected virtual void Dispose()
        {
            
        }

    }
}

