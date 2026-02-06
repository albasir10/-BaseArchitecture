using UnityEngine;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractViewCanvas : AbstractMonoBehaviour
    {
        protected Canvas Canvas;
        
        protected override void Init()
        {
            Canvas = GetComponent<Canvas>();

            ViewInit();
        }
        
        public bool TryShow()
        {
            Canvas.enabled = true;
                
            return true;
        }

        protected virtual void Show()
        {
            
        }

        [ContextMenu("Hide")]
        public virtual void Hide()
        {
            Canvas.enabled = false;
        }

        protected abstract void ViewInit();
    }
}

