using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityManagerSO", menuName = "ScriptableObjects/Manager/AbilityManagerSO")]
[System.Serializable] public class AbilityManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]

    [SerializeField] private AbilityModel[] abilityEndTurn;
    [SerializeField] private AbilityModel[] abilityMove;
    [SerializeField] private AbilityModel[] abilityDefend;
    [SerializeField] private AbilityModel[] abilitySword;
    [SerializeField] private AbilityModel[] abilityBlock;
    [SerializeField] private AbilityModel[] abilityBow;
    [SerializeField] private AbilityModel[] abilityCounter;
    [SerializeField] private AbilityModel[] abilitySpear;

    #endregion
    #region Properties

    public AbilityModel[] AbilityEndTurn { get => abilityEndTurn; private set => abilityEndTurn = value; }
    public AbilityModel[] AbilityMove { get => abilityMove; private set => abilityMove = value; }
    public AbilityModel[] AbilityDefend { get => abilityDefend; private set => abilityDefend = value; }
    public AbilityModel[] AbilitySword { get => abilitySword; private set => abilitySword = value; }
    public AbilityModel[] AbilityBlock { get => abilityBlock; private set => abilityBlock = value; }
    public AbilityModel[] AbilityBow { get => abilityBow; private set => abilityBow = value; }
    public AbilityModel[] AbilityCounter { get => abilityCounter; private set => abilityCounter = value; }
    public AbilityModel[] AbilitySpear { get => abilitySpear; private set => abilitySpear = value; } 

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    #endregion
}
