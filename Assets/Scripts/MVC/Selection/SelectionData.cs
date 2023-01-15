using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.Selection
{
    [System.Serializable]
    public class SelectionData
    {
        #region Fields

        [SerializeField] private bool isSelected;

        #endregion
        #region Events

        [FormerlySerializedAs("eventIsSelectedChanged")] [SerializeField] public UnityEvent isSelectedChanged;

        #endregion
        #region Properties

        public bool IsSelected
        {
            get => isSelected;

            set
            {
                if (isSelected == value) return;
            
                isSelected = value;
                IsSelectedChanged.Invoke();
            }
        }

        #endregion
        #region Event Properties

        public virtual UnityEvent IsSelectedChanged
        {
            get
            {
                if (isSelectedChanged == null)
                    isSelectedChanged = new UnityEvent();
            
                return isSelectedChanged;
            }

            set => isSelectedChanged = value;
        }

        #endregion
    }
}
