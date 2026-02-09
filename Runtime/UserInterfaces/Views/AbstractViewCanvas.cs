using System;
using UnityEngine;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractViewCanvas : AbstractMonoBehaviour
    {
        protected Canvas Canvas;

        private void Reset()
        {
            _priority = 1;
        }

        protected override void Init()
        {
            Canvas = GetComponent<Canvas>();

            ViewInit();
        }
        
        public virtual bool TryShow()
        {
            Show();
            
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
            
            return true;
        }
        
        [ContextMenu("Hide")]
        protected virtual void Hide()
        {
            Canvas.enabled = false;
        }

        protected abstract void ViewInit();
    }
}

