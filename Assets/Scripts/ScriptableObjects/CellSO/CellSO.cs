using UnityEngine;

namespace ScriptableObjects.CellSO
{
    [CreateAssetMenu(fileName = "CellSO", menuName = "ScriptableObjects/CellSO")]
    public class CellSO : ScriptableObject
    {
        #region Fields
        [field: Header("Fields")]
        [SerializeField] private string cellName;
        [SerializeField] private Sprite cellIcon;
        [SerializeField] private string cellDescription;
        [SerializeField] private bool cellIsLandTraversable;
        [SerializeField] private bool cellIsAirTraversable;
        [SerializeField] private bool cellIsLandDestination;
        [SerializeField] private bool cellIsAirDestination;

        #endregion
        #region Events
        #endregion
        #region Properties

        public string CellName => cellName;
        public Sprite CellIcon => cellIcon;
        public string CellDescription => cellDescription;
        public bool CellIsLandTraversable => cellIsLandTraversable;
        public bool CellIsAirTraversable => cellIsAirTraversable;
        public bool CellIsLandDestination => cellIsLandDestination;
        public bool CellIsAirDestination => cellIsAirDestination;

        #endregion
    }
}