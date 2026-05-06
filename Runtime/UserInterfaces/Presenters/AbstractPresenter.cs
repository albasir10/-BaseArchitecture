using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace albatroneer.Core
{
    [RequireComponent(typeof(AbstractViewCanvas))]
    public abstract class AbstractPresenter<T> : AbstractMonoBehaviour where T : AbstractViewCanvas
    {
        protected T View { get; private set; }

        protected bool IsShowed;

        [Inject] private IEventer _eventer;
        
        protected IEventer Eventer => _eventer;

        protected sealed override async UniTask<bool> Init()
        {
            View = GetComponent<T>();

            await View.TryInit();
            
            IsShowed = View.IsShow;

            PresenterInit(); 
            
            return true;
        }
        
        protected abstract void PresenterInit();

        public bool TryShow()
        {
            if (IsShowed)
            {
                return false;
            }
            
            View.TryShow(true);

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
            
            View.TryHide(true);
            
            Hide();
            
            IsShowed = false;

            return true;
        }

        protected virtual void Hide()
        {
            
        }

       
    }
}

