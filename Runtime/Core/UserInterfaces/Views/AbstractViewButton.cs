using albatroneer.BaseArchitecture.Cores;
using UnityEngine;
using UnityEngine.UI;

namespace albatroneer.BaseArchitecture.UserInterfaces
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractViewButton : AbstractMonoBehaviour
    {
        protected Button _mainBtn;
        
        public event Action OnMainBtnPressed;
        
        protected override void Init()
        {
            _mainBtn = GetComponent<Button>();
            
            _mainBtn.onClick.AddListener(MainBtnPressed);
            
            ViewInit();
            
            Unselected();
        }
        
        public virtual void Unselected()
        {
            ChangeInteractable(true);
        }
        
        public virtual void Selected()
        {
            ChangeInteractable(false);
        }
        
        public void ChangeInteractable(bool interactable)
        {
            BaseChangeInteractable();
        }

        protected virtual void BaseChangeInteractable(bool interactable)
        {
            _mainBtn.interactable = interactable;
        }

        protected abstract void ViewInit();

        protected virtual void MainBtnPressed()
        {
            OnMainBtnPressed?.Invoke();
        }
    }
}

