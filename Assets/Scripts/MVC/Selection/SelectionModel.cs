using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class SelectionModel
{
    #region Fields

    [SerializeField] private bool isSelected;

    #endregion
    #region Events

    [SerializeField] public UnityEvent eventIsSelectedChanged;

    #endregion
    #region Properties

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }

        set
        {
            if (isSelected != value)
            {
                isSelected = value;
                EventIsSelectedChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventIsSelectedChanged
    {
        get
        {
            if (eventIsSelectedChanged == null)
            {
                eventIsSelectedChanged = new UnityEvent();
            }
            return eventIsSelectedChanged;
        }

        set
        {
            eventIsSelectedChanged = value;
        }
    }

    #endregion
}
