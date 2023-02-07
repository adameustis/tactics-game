using System.Collections.Generic;
using System.Linq;
using MVC.EventModel;
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

        public void Initialise(PlayerAndTransformEventModel context)
        {
            if (!context.Tf.TryGetComponent(out PerformingAbilityController controller)) return;

            if (controller.Ability.Model.Ability == EndTurnAbility)
            {
                TurnManager.EndTurn();
                OnEndTurn.UnityEvent.Invoke(context);
                return;
            }
            
            if (MoveAbilities.Contains(controller.Ability.Model.Ability))
            {
                controller.Ability.Model.EffectiveUses = 0;
                OnContinueTurn.UnityEvent.Invoke(context);
                return;
            }

            foreach (var ability in controller.Unit.Model.UnitAbilities.Where(ability => ability.Ability != EndTurnAbility && !MoveAbilities.Contains(ability.Ability)))
                ability.EffectiveUses = 0;

            OnContinueTurn.UnityEvent.Invoke(context);
        }
        #endregion
    }
}