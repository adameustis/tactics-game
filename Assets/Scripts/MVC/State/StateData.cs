using MVC.EventModel;
using UnityEngine;

namespace MVC.State
{
    public class StateData
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public PlayerAndTransformEventModel Context { get; set; }
        #endregion
    }
}