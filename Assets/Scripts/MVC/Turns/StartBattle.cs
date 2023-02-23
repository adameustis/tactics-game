using MVC.EventData;
using ScriptableObjects.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Turns
{
    public class StartBattle : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private CellManagerSO cellManager;
        [SerializeField] private UnitManagerSO unitManager;
        [SerializeField] private TurnManagerSO turnManager;
        [SerializeField] private CellMapSO cellMap;
        [SerializeField] private UnitManagerSettingsSO unitManagerSettings;

        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private UnityEvent<PlayerAndTransformData> onStarted;

        #endregion
        #region Properties

        public CellManagerSO CellManager { get => cellManager; private set => cellManager = value; }
        public UnitManagerSO UnitManager { get => unitManager; private set => unitManager = value; }
        public TurnManagerSO TurnManager { get => turnManager; private set => turnManager = value; }
        public CellMapSO CellMap { get => cellMap; set => cellMap = value; }
        public UnitManagerSettingsSO UnitManagerSettings { get => unitManagerSettings; set => unitManagerSettings = value; }

        #endregion
        #region Event Properties

        public UnityEvent<PlayerAndTransformData> OnStarted { get => onStarted; set => onStarted = value; }

        #endregion
        #region MonoBehaviour
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void Initialise(PlayerAndTransformData context)
        {
            CellManager.CreateBattleCells(CellMap);
            UnitManager.CreateUnits(UnitManagerSettings, CellManager);
            TurnManager.Initialise(UnitManager.UnitModelList);
            OnStarted.Invoke(context);
        }
        #endregion
    }
}