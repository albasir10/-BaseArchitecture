using UnityEngine;
using VContainer;
using VContainer.Unity;
using albatroneer.BaseArchitecture.Events;

namespace albatroneer.BaseArchitecture.Containers
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

