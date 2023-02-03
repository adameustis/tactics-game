using UnityEngine;
using UnityEngine.Events;

namespace MVC.Miscellaneous
{
    public class OnEnableTrigger : MonoBehaviour
    {
        #region Event Properties
        [field: Header("Triggers")]
        [field: SerializeField] public UnityEvent OnTriggered { get; protected set; }

        #endregion
        #region Monobehaviour
        private void OnEnable() => OnTriggered.Invoke();
        #endregion
        #region Methods
        #endregion
    }
}