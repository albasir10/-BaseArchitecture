using UnityEngine;

namespace albatroneer.CoreArchitecture.UserInterfaces
{
    [RequireComponent(typeof(AbstractViewCanvas))]
    public abstract class AbstractPresenter : AbstractMonoBehaviour
    {
        protected AbstractViewCanvas View { get; private set; }

        protected bool IsShowed;

        protected override void Init()
        {
            View = GetComponent<AbstractViewCanvas>();

            PresenterInit(); 
        }

        public bool TryShow()
        {
            View.TryShow();

            IsShowed = true;

            Show();
                
            return true;
        }

        protected virtual void Show()
        {
            
        }

        
        public virtual void Hide()
        {
            if (IsShowed)
            {
                View.Hide();
            
                IsShowed = false;
            }
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

