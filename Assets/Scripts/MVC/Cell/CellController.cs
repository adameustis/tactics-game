using UnityEngine;
using UnityEngine.Events;

namespace MVC.Cell
{
    [System.Serializable]
    public class CellController : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private CellModel model;

        #endregion
        #region Events
        #endregion
        #region Properties

        public CellModel Model { get => model; set => model = value; }

        #endregion
        #region Event Properties
        #endregion
        #region MonoBehaviour
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Methods
        #endregion

    }
}
