using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battle : MonoBehaviour
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private CellMapSO cellMap;
    [SerializeField] private UnitManagerSettingsSO unitManagerSettings;

    #endregion
    #region Properties

    public GameManagerSO GameManager { get => gameManager; set => gameManager = value; }
    public CellMapSO CellMap { get => cellMap; set => cellMap = value; }
    public UnitManagerSettingsSO UnitManagerSettings { get => unitManagerSettings; set => unitManagerSettings = value; }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour

    private void Start()
    {
        Initialise();
    }

    private void OnDestroy()
    {
        GameManager.CellManager.Clear();
    }

    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void Initialise()
    {
        GameManager.CellManager.CreateBattleCells(CellMap);
        GameManager.UnitManager.CreateUnits(UnitManagerSettings, GameManager.CellManager);
        GameManager.TurnManager.Initialise(GameManager.UnitManager.UnitModelList);
        // GameManager.UnitManager.UnitModelList[0].AddAbility(GameManager.AbilityManager.AbilityMove[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[0].AddAbility(GameManager.AbilityManager.AbilitySword[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[0].AddAbility(GameManager.AbilityManager.AbilityDefend[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[0].AddAbility(GameManager.AbilityManager.AbilityEndTurn[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[1].AddAbility(GameManager.AbilityManager.AbilityMove[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[1].AddAbility(GameManager.AbilityManager.AbilitySword[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[1].AddAbility(GameManager.AbilityManager.AbilityDefend[0].DeepCopy());
        // GameManager.UnitManager.UnitModelList[1].AddAbility(GameManager.AbilityManager.AbilityEndTurn[0].DeepCopy());
    }
    #endregion
}
