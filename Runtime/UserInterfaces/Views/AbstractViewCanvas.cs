using System;
using UnityEngine;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractViewCanvas : AbstractMonoBehaviour
    {
        protected Canvas Canvas;

        public bool IsShow { get; private set; }

        private void Reset()
        {
            _priority = 1;
        }

        protected sealed override void Init()
        {
            Canvas = GetComponent<Canvas>();

            IsShow = Canvas.enabled;

            ViewInit();
        }
        
        public virtual bool TryShow()
        {
            Show();

            IsShow = true;
            
            return true;
        }

        [ContextMenu("Show")]
        protected virtual void Show()
        {
            Canvas.enabled = true;
        }

        [ContextMenu("Hide")]
        public virtual bool TryHide()
        {
            Hide();

            IsShow = false;
            
            return true;
        }
        
        [ContextMenu("Hide")]
        protected virtual void Hide()
        {
            Canvas.enabled = false;
        }

        protected abstract void ViewInit();

        protected sealed override void Dispose()
        {
            base.Dispose();

            DisposeView();
        }

        protected virtual void DisposeView()
        {
            
        }
    }
}

