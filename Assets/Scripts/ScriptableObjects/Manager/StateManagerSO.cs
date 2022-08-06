using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateManagerSO", menuName = "ScriptableObjects/Manager/StateManagerSO")]
[System.Serializable] public class StateManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields

    [Header("Fields")]

    [SerializeField] private StateSO stateSOIdol;
    [SerializeField] private StateSO stateSOSelected;
    [SerializeField] private StateSO stateSOUnitChoosingWhereToMove;
    [SerializeField] private StateSO stateSOUnitMoving;
    [SerializeField] private StateSO stateSOUnitViewingAbilityMenu;

    [SerializeField] private StateSO stateSOGameState;
    [SerializeField] private StateSO stateSOBattleState;

    public StateSO StateSOGameState
    {
        get
        {
            return stateSOGameState;
        }

        set
        {
            stateSOGameState = value;
        }
    }

    public StateSO StateSOBattleState
    {
        get
        {
            return stateSOBattleState;
        }

        set
        {
            stateSOBattleState = value;
        }
    }

    public StateSO StateSOIdol
    {
        get
        {
            return stateSOIdol;
        }

        private set
        {
            stateSOIdol = value;
        }
    }

    public StateSO StateSOSelected
    {
        get
        {
            return stateSOSelected;
        }

        private set
        {
            stateSOSelected = value;
        }
    }

    public StateSO StateSOUnitChoosingWhereToMove
    {
        get
        {
            return stateSOUnitChoosingWhereToMove;
        }

        private set
        {
            stateSOUnitChoosingWhereToMove = value;
        }
    }

    public StateSO StateSOUnitMoving
    {
        get
        {
            return stateSOUnitMoving;
        }

        private set
        {
            stateSOUnitMoving = value;
        }
    }

    public StateSO StateSOUnitViewingAbilityMenu
    {
        get
        {
            return stateSOUnitViewingAbilityMenu;
        }

        private set
        {
            stateSOUnitViewingAbilityMenu = value;
        }
    }

    #endregion
    #region Properties


    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    public void OnAfterDeserialize()
    {
        stateSOGameState = null; // To do
        stateSOBattleState = null; // To do
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnEnable() { }
    #endregion
}
