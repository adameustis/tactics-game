using MVC.Ability;
using MVC.Cell;
using MVC.EventModel;
using MVC.Player;
using MVC.Unit;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.PerformingAbility
{
    public class PerformingAbilityController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private PlayerController player;
        [SerializeField] private AbilityController ability;
        [SerializeField] private UnitController unit;
        [SerializeField] private CellController cell;

        #endregion
        #region Fields
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onPerformingComplete;

        #endregion
        #region Properties

        public PlayerController Player { get => player; set => player = value; }
        public AbilityController Ability { get => ability; private set => ability = value; }
        public UnitController Unit { get => unit; private set => unit = value; }
        public CellController Cell { get => cell; private set => cell = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnPerformingComplete { get => onPerformingComplete; private set => onPerformingComplete = value; }

        #endregion
        #region Methods

        public void Initialise(PlayerModel setPlayer, AbilityModel setAbility, UnitModel setUnit, CellModel setCell)
        {
            Player.Model = setPlayer;
            Ability.Model = setAbility;
            Unit.Model = setUnit;
            Cell.Model = setCell;
        }

        public void InvokeOnPerformingComplete()
        {
            OnPerformingComplete.UnityEvent.Invoke(new PlayerAndTransformEventModel(Player.Model, transform));
        }
        
        #endregion
    }
}