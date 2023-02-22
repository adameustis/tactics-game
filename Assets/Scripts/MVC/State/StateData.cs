using MVC.EventData;
using UnityEngine;

namespace MVC.State
{
    [System.Serializable]
    public class StateData
    {
        #region Constructors
        public StateData(PlayerAndTransformEventData setContext) => Context = setContext;
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public PlayerAndTransformEventData Context { get; set; }
        #endregion
    }
}