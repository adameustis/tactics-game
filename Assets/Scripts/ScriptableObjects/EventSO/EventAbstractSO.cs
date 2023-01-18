using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.EventSO
{
    public abstract class EventAbstractSO<T> : ScriptableObject where T : UnityEventBase
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public T UnityEvent { get; set; }
        #endregion
        #region MonoBehaviour
        #endregion
        #region Methods

        protected virtual void OnDisable()
        {
            UnityEvent.RemoveAllListeners();
        }

        #endregion
    }
}
