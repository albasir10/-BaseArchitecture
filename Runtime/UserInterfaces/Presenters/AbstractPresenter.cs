using UnityEngine;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(AbstractViewCanvas))]
    public abstract class AbstractPresenter<T> : AbstractMonoBehaviour where T : AbstractViewCanvas
    {
        protected T View { get; private set; }

        protected bool IsShowed;

        protected override void Init()
        {
            View = GetComponent<T>();

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
        

        protected override void Dispose()
        {
            DisposePresenter();
        }

        protected virtual void DisposePresenter()
        {
            
        }
    }
}

