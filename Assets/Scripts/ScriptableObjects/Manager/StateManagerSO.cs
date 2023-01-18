using System.Collections.Generic;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "StateManagerSO", menuName = "ScriptableObjects/Manager/StateManagerSO")]
    [System.Serializable] 
    public class StateManagerSO :  ScriptableObject
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public List<StateBehaviour> BattleStateList { get; set; } = new();
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