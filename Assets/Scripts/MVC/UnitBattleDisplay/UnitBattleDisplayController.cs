using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UnitBattleDisplayController : MonoBehaviour {
    #region Delegates
    #endregion
    #region Fields
    
    [FormerlySerializedAs("controller")]
    [Header("Fields")]
    [SerializeField] private UnitModel model;
    [SerializeField] private Image icon;
    [SerializeField] private Text textName;
    [SerializeField] private UnitBattleDisplayController unitBattleUnitBattleDisplayPrefab;
    [SerializeField] private bool isDisplayingAbilities;
    
    #endregion

    #region Events

    [SerializeField] private UnityEvent eventIsDisplayingChanged;

    #endregion
    #region Properties

    public UnitModel Model { get => model; set => model = value; }

    public Image Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public Text TextName
    {
        get
        {
            return textName;
        }

        set
        {
            textName = value;
        }
    }

    public UnitBattleDisplayController UnitBattleDisplayPrefab { get => unitBattleUnitBattleDisplayPrefab; set => unitBattleUnitBattleDisplayPrefab = value; }
    
    public bool IsDisplayingAbilities
    {
        get
        {
            return isDisplayingAbilities;
        }

        set
        {
            if (isDisplayingAbilities != value)
            {
                isDisplayingAbilities = value;
                EventIsDisplayingChanged.Invoke();
            }
        }
    }
    
    #endregion
    #region Event Properties

    public UnityEvent EventIsDisplayingChanged
    {
        get
        {
            if (eventIsDisplayingChanged == null)
            {
                eventIsDisplayingChanged = new UnityEvent();
            }
            return eventIsDisplayingChanged;
        }

        set
        {
            eventIsDisplayingChanged = value;
        }
    }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    // Use this for initialization
    //private void Start () {
    //    if (Unit != null)
    //    {
    //        Init(Unit);
    //    }
    //}
    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    public void Initialise(UnitModel setUnit)
    {
        if (setUnit == null)
        {
            if (Icon != null)
            {
                Icon.sprite = null;
            }
            if (TextName != null)
            {
                TextName.text = "";
            }
        }
        else
        {
            if (Icon != null)
            {
                Icon.sprite = setUnit.UnitIcon;
            }
            if (TextName != null)
            {
                TextName.text = setUnit.UnitName;
            }
        }
    }

    public void Initialise()
    {
    }
    
    public void Display()
    {
        UnitBattleDisplayPrefab = (UnitBattleDisplayController)Object.Instantiate(UnitBattleDisplayPrefab);
        IsDisplayingAbilities = true;
    }
    
    public void Clear()
    {
        Destroy(UnitBattleDisplayPrefab.gameObject);
        IsDisplayingAbilities = false;
    }
    #endregion
}
