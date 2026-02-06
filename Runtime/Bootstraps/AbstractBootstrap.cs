using System;
using System.Linq;
using albatroneer.CoreArchitecture;
using UnityEngine;
using VContainer.Unity;

namespace albatroneer.CoreArchitecture.Bootstraps
{
    public abstract class AbstractBootstrap : MonoBehaviour
    {
        [SerializeField] protected LifetimeScope _lifetimeScope;
        
        protected void Awake()
        {
            _lifetimeScope.Build();
            
            
            var allMonoBehaviours = FindObjectsByType<AbstractMonoBehaviour>(FindObjectsSortMode.None)
                .OrderByDescending(mb => mb.Priority)
                .ToList();
        
            foreach (var component in allMonoBehaviours)
            {
                if (component.IsInject)
                {
                    _lifetimeScope.Container.Inject(component);
                }
                component.TryInit();
            }

            Init();
        }

        protected void OnDestroy()
        {
            Dispose();
        }

        protected abstract void Init();
        
        protected abstract void Dispose();

    }
}

