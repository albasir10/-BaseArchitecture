using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace albatroneer.Core
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractViewCanvas : AbstractMonoBehaviour
    {
        protected Canvas Canvas;

        public bool IsShow { get; private set; }

        protected sealed override UniTask<bool> Init()
        {
            Canvas = GetComponent<Canvas>();

            IsShow = Canvas.enabled;

            ViewInit();
            
            return UniTask.FromResult(true);
        }
        
        protected abstract void ViewInit();

        [ContextMenu("Show")]
        public virtual bool TryShow(bool isForce = false)
        {
            if (IsShow && !isForce)
            {
                return false;
            }
            
            Show();

            IsShow = true;
            
            return true;
        }

        
        protected virtual void Show()
        {
            Canvas.enabled = true;
        }
        
        [ContextMenu("Hide")]
        public virtual bool TryHide(bool isForce = false)
        {
            if (!IsShow && !isForce)
            {
                return false;
            }
            
            Hide();

            IsShow = false;
            
            return true;
        }
        
        
        protected virtual void Hide()
        {
            Canvas.enabled = false;
        }


    }
}

