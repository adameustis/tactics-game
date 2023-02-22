using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using MVC.PerformingAbility;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.Turns
{
    public class FinaliseTurn : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private TurnManagerSO turnManager;
        [SerializeField] private AbilitySO endTurnAbility;
        [SerializeField] private List<AbilitySO> moveAbilities;

        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onContinueTurn;
        [SerializeField] private EventPlayerModelAndTransformSO onEndTurn;

        #endregion
        #region Properties
        public TurnManagerSO TurnManager { get => turnManager; private set => turnManager = value; }
        public AbilitySO EndTurnAbility { get => endTurnAbility; private set => endTurnAbility = value; }
        public List<AbilitySO> MoveAbilities { get => moveAbilities; private set => moveAbilities = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnContinueTurn { get => onContinueTurn; private set => onContinueTurn = value; }
        public EventPlayerModelAndTransformSO OnEndTurn { get => onEndTurn; private set => onEndTurn = value; }

        #endregion
        #region MonoBehaviour
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void Initialise(PlayerAndTransformEventData context)
        {
            //if (!context.Tf.TryGetComponent(out PerformingAbilityController controller)) return;
            
            if (context.GetType() != typeof(PerformingAbilityEventData)) return;
            
            var eventData = (PerformingAbilityEventData)context;
            
            if (eventData.Ability.Ability == EndTurnAbility)
            {
                TurnManager.EndTurn();
                OnEndTurn.UnityEvent.Invoke(context);
                return;
            }
            
            if (MoveAbilities.Contains(eventData.Ability.Ability))
            {
                eventData.Ability.EffectiveUses = 0;
                OnContinueTurn.UnityEvent.Invoke(context);
                return;
            }

            Debug.Log("Ability Name: " + eventData.Ability.Ability.AbilityName);
            Debug.Log("Source Cell Name: " + eventData.SourceCell.StaticData.CellName);
            Debug.Log("Target Cell Name: " + eventData.TargetCell.StaticData.CellName);
            Debug.Log("Source Unit: " + eventData.SourceUnit.UnitName);
            Debug.Log("Source Unit number of abilities: " + eventData.SourceUnit.UnitAbilities.Count);
            Debug.Log("Source Unit number of abilities with conditions: " + eventData.SourceUnit.UnitAbilities.Count(ability => ability.Ability != EndTurnAbility && !MoveAbilities.Contains(ability.Ability)));
            
            foreach (var ability in eventData.SourceUnit.UnitAbilities.Where(ability => ability.Ability != EndTurnAbility && !MoveAbilities.Contains(ability.Ability)))
                ability.EffectiveUses = 0;

            OnContinueTurn.UnityEvent.Invoke(context);
        }
        #endregion
    }
}