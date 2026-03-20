using albatroneer.CoreArchitecture.Events;
using UnityEngine;
using VContainer;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(AbstractViewCanvas))]
    public abstract class AbstractPresenter<T> : AbstractMonoBehaviour where T : AbstractViewCanvas
    {
        protected T View { get; private set; }

        protected bool IsShowed;

        [Inject] private IEventer _eventer;
        
        protected IEventer Eventer => _eventer;

        protected sealed override void Init()
        {
            View = GetComponent<T>();
            
            IsShowed = View.IsShow;

            PresenterInit(); 
        }

        public bool TryShow()
        {
            if (IsShowed)
            {
                return false;
            }
            
            View.TryShow();

            IsShowed = true;

            Show();
                
            return true;
        }

        protected virtual void Show()
        {
            
        }

        
        public bool TryHide()
        {
            if (!IsShowed)
            {
                return false;
            }
            
            View.TryHide();
            
            Hide();
            
            IsShowed = false;

            return true;
        }

        protected virtual void Hide()
        {
            
        }

        protected abstract void PresenterInit();
        

        protected sealed override void Dispose()
        {
            DisposePresenter();
        }

        protected virtual void DisposePresenter()
        {
            
        }
    }
}

