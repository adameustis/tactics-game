using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MVC.Miscellaneous
{
    public class OnSelectTrigger : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
    {
        #region Event Properties
        [field: Header("Triggers")]
        [field: SerializeField] public UnityEvent OnTriggered { get; protected set; }

        #endregion
        #region Monobehaviour
        #endregion
        #region Methods
        //Do this when the selectable UI object is selected.
        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log(this.gameObject.name + " was selected");
            OnTriggered.Invoke();
        }
        #endregion
    }
}