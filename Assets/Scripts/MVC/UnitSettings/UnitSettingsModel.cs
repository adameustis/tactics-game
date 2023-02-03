using System.Collections;
using System.Collections.Generic;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnitSettingsModel
{
    #region Fields

    [Header("Values")]
    [SerializeField] private int unitNumber;
    [SerializeField] private string unitName;
    [SerializeField] private PointStruct point;
    [SerializeField] private UnitController prefab;

    #endregion
    #region Events

    [Header("Events")]
    [SerializeField] private UnityEvent eventUnitNumberChanged;
    [SerializeField] private UnityEvent eventUnitNameChanged;
    [SerializeField] private UnityEvent eventPointChanged;
    [SerializeField] private UnityEvent eventPrefabChanged;

    #endregion
    #region Properties

    public int UnitNumber
    {
        get
        {
            return unitNumber;
        }

        set
        {
            if (unitNumber != value)
            {
                unitNumber = value;
                EventUnitNumberChanged.Invoke();
            }
        }
    }

    public string UnitName
    {
        get
        {
            return unitName;
        }

        set
        {
            if (unitName != value)
            {
                unitName = value;
                EventUnitNameChanged.Invoke();
            }
        }
    }

    public PointStruct Point
    {
        get
        {
            return point;
        }
        set
        {
            if (!point.Equals(value))
            {
                point = value;
                EventPointChanged.Invoke();
            }
        }
    }

    public UnitController Prefab
    {
        get
        {
            return prefab;
        }
        set
        {
            if (prefab != value)
            {
                prefab = value;
                EventPrefabChanged.Invoke();
            }
        }
    }

    #endregion
    #region Events Properties

    public UnityEvent EventUnitNumberChanged
    {
        get
        {
            if (eventUnitNumberChanged == null)
            {
                eventUnitNumberChanged = new UnityEvent();
            }
            return eventUnitNumberChanged;
        }

        set
        {
            eventUnitNumberChanged = value;
        }
    }

    public UnityEvent EventUnitNameChanged
    {
        get
        {
            if (eventUnitNameChanged == null)
            {
                eventUnitNameChanged = new UnityEvent();
            }
            return eventUnitNameChanged;
        }

        set
        {
            eventUnitNameChanged = value;
        }
    }

    public UnityEvent EventPointChanged
    {
        get
        {
            if (eventPointChanged == null)
            {
                eventPointChanged = new UnityEvent();
            }
            return eventPointChanged;
        }

        set
        {
            eventPointChanged = value;
        }
    }

    public UnityEvent EventPrefabChanged
    {
        get
        {
            if (eventPrefabChanged == null)
            {
                eventPrefabChanged = new UnityEvent();
            }
            return eventPrefabChanged;
        }

        set
        {
            eventPrefabChanged = value;
        }
    }

    #endregion
    #region Methods
    #endregion
}
