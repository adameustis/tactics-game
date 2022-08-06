using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game : MonoBehaviour
{
    #region Delegates
    #endregion
    #region Fields

    private GameManagerSO gameManager;

    #endregion
    #region Properties

    public GameManagerSO GameManager { get => gameManager; set => gameManager = value; }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    // private void Awake()
    // {
    //     ////Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
    //     //if (BattleStateManager.Instance == null)
    //     //{
    //     //    //Instantiate gameManager prefab
    //     //    Instantiate(BattleState);
    //     //}
    //     //BattleStateManager.Instance.StartBattleState(StateEnum.BattleInitialising, transform);
    // }

    //private void Update()
    //{
    //    GameManager.InputManager.Update();
    //}

    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    #endregion
}
