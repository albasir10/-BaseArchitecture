using albatroneer.BaseArchitecture.Cores;
using albatroneer.BaseArchitecture.Utils;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace albatroneer.BaseArchitecture.UserInterfaces
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractViewCanvas : AbstractMonoBehaviour
    {
        protected Canvas _canvas;
        
        protected override void Init()
        {
            _canvas = GetComponent<Canvas>();

            ViewInit();
        }
        
        public bool TryShow()
        {
            _canvas.enabled = true;
                
            return true;
        }

        protected virtual void Show()
        {
            
        }

        [ContextMenu("Hide")]
        public virtual void Hide()
        {
            _canvas.enabled = false;
        }

        protected abstract void ViewInit();
    }
}

