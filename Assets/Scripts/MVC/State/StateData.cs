using MVC.EventData;
using UnityEngine;

namespace MVC.State
{
    [System.Serializable]
    public class StateData
    {
        #region Constructors
        public StateData(PlayerAndTransformData setContext) => Context = setContext;
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public PlayerAndTransformData Context { get; set; }
        #endregion
    }
}