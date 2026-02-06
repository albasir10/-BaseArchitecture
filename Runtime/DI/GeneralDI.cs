using UnityEngine;
using VContainer;
using VContainer.Unity;
using albatroneer.CoreArchitecture.Events;

namespace albatroneer.CoreArchitecture.Containers
{
    public class GeneralDI : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterComponentInHierarchy<EventBus>()
                .As<IEventer>().AsSelf();
        }
    }
}

