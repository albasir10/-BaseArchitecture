using System;
using UnityEngine;

namespace albatroneer.CoreArchitecture.Events
{
    public interface IEventer
    {
        public void Subscribe<T>(Action<T> callback, int priority = 0) where T : struct;
        public void Unsubscribe<T>(Action<T> callback) where T : struct;
        public void Publish<T>(T eventData) where T : struct;
        
        
        public void Subscribe<T>(Action<T> callback, Guid guid, int priority = 0) where T : struct;
        public void Unsubscribe<T>(Action<T> callback , Guid guid) where T : struct;
        public void Publish<T>(T eventData , Guid guid) where T : struct;

        public void SubscribeGlobal<T>(Action<T> callback, int priority = 0) where T : struct;
        
        public void UnsubscribeAllGuid(Guid guid);

    }

}
