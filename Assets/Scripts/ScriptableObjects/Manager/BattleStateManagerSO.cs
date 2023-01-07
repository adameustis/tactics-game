using System.Collections.Generic;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "BattleStateManagerSO", menuName = "ScriptableObjects/Manager/BattleStateManagerSO")]
    [System.Serializable] 
    public class BattleStateManagerSO :  ScriptableObject
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public State CurrentState { get; set; }
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
}