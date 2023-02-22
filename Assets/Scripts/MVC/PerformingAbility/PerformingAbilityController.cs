using MVC.Ability;
using MVC.Cell;
using MVC.EventData;
using MVC.Player;
using MVC.Unit;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.PerformingAbility
{
    public class PerformingAbilityController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private PlayerModel player;
        [SerializeField] private AbilityModel ability;
        [FormerlySerializedAs("unit")] [SerializeField] private UnitModel sourceUnit;
        [SerializeField] private CellModel sourceCell;
        [FormerlySerializedAs("cell")] [SerializeField] private CellModel targetCell;

        #endregion
        #region Fields
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onPerformingComplete;

        #endregion
        #region Properties

        public PlayerModel Player { get => player; set => player = value; }
        public AbilityModel Ability { get => ability; private set => ability = value; }
        public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        public CellModel SourceCell { get => sourceCell; set => sourceCell = value; }
        public CellModel TargetCell { get => targetCell; private set => targetCell = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnPerformingComplete { get => onPerformingComplete; private set => onPerformingComplete = value; }

        #endregion
        #region Methods

        public void Initialise(PlayerModel setPlayer, AbilityModel setAbility, UnitModel setSourceUnit, CellModel setSourceCell, CellModel setTargetCell)
        {
            Player = setPlayer;
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            SourceCell = setSourceCell;
            TargetCell = setTargetCell;
        }

        public void InvokeOnPerformingComplete()
        {
            OnPerformingComplete.UnityEvent.Invoke(new PerformingAbilityEventData(Player, transform, Ability, SourceUnit, SourceCell, TargetCell));
        }
        
        #endregion
    }
}