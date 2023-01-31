using MVC.EventModel;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Input
{
    public abstract class Input : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties

        #endregion
        #region Event Properties

        [field: Header("Public Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicInput { get; private set; }

        [field: Header("Local Events")]
        [field: SerializeField] public UnityEvent<PlayerAndTransformEventModel> LocalInput { get; private set; }

        #endregion
        #region MonoBehaviour
        #endregion
        #region Methods
    
        public void InvokeInput(PlayerAndTransformEventModel context)
        {
            PublicInput.UnityEvent?.Invoke(context);
            LocalInput?.Invoke(context);
        }

        #endregion
    }
}
