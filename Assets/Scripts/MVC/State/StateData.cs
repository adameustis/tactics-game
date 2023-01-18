using MVC.EventModel;
using UnityEngine;

namespace MVC.State
{
    [System.Serializable]
    public class StateData
    {
        #region Constructors
        public StateData(PlayerAndTransformEventModel setContext) => Context = setContext;
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public PlayerAndTransformEventModel Context { get; set; }
        #endregion
    }
}