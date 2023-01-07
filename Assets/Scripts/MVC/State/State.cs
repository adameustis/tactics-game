using MVC.EventModel;
using UnityEngine;

namespace MVC.State
{
    public class State : MonoBehaviour
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateController.StateController Controller { get; private set; }
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO OnEnter { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO OnExit { get; private set; }
        #endregion
        #region Methods

        public virtual void Init(PlayerAndTransformEventModel context)
        {
            OnEnter.UnityEvent.Invoke(context);
        }
        
        public virtual void Disable(PlayerAndTransformEventModel context)
        {
            OnExit.UnityEvent.Invoke(context);
        }

        #endregion


    }
}
