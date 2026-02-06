using albatroneer.BaseArchitecture.Cores;
using UnityEngine;

namespace albatroneer.BaseArchitecture.UserInterfaces
{
    [RequireComponent(typeof(AbstractViewCanvas))]
    public abstract class AbstractPresenter : AbstractMonoBehaviour
    {
        protected AbstractViewCanvas View { get; private set; }

        protected bool _isShowed;

        protected override void Init()
        {
            View = GetComponent<AbstractViewCanvas>();

            if (IsCanShow())
            {
                PresenterInit(); 
            }
        }

        public bool TryShow()
        {
            if (IsCanShow())
            {
                View.TryShow();

                _isShowed = true;

                Show();
                
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void Show()
        {
            
        }

        
        public virtual void Hide()
        {
            if (_isShowed)
            {
                View.Hide();
            
                _isShowed = false;
            }
        }

        protected abstract void PresenterInit();

        public bool IsCanShow()
        {
            return View.IsCanShow();
        }

        protected override void Dispose()
        {
            if (IsCanShow())
            {
                DisposePresenter();
            }
        }

        protected virtual void DisposePresenter()
        {
            
        }
    }
}

