using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace albatroneer.Core
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractViewButton : AbstractMonoBehaviour
    {
        protected Button MainBtn;
        
        public event Action OnMainBtnPressed;
        
        protected override UniTask<bool> Init()
        {
            MainBtn = GetComponent<Button>();
            
            MainBtn.onClick.AddListener(MainBtnPressed);
            
            ViewInit();
            
            Unselected();
            
            return UniTask.FromResult(true);
        }
        
        protected abstract void ViewInit();
        
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
            BaseChangeInteractable(interactable);
        }

        protected virtual void BaseChangeInteractable(bool interactable)
        {
            MainBtn.interactable = interactable;
        }



        protected virtual void MainBtnPressed()
        {
            OnMainBtnPressed?.Invoke();
        }
    }
}

