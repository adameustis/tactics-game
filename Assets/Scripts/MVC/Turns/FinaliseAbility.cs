using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using MVC.PerformingAbility;
using MVC.SelectArea;
using MVC.Target;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.Turns
{
    public class FinaliseAbility : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<AbilitySO> moveAbilities;

        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onContinueTurn;

        #endregion
        #region Properties
        public List<AbilitySO> MoveAbilities { get => moveAbilities; private set => moveAbilities = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnContinueTurn { get => onContinueTurn; private set => onContinueTurn = value; }

        #endregion
        #region MonoBehaviour
        #endregion
        #region Event Handlers
        public void HandleOnEnterState(PlayerAndTransformData context)
        {
            //if (!context.Tf.TryGetComponent(out PerformingAbilityController controller)) return;

            if(context is TargetAreaData eventData)
                Finalise(eventData);
        }
        #endregion
        #region Methods

        public void Finalise(TargetAreaData data)
        {
            data.SourceCell.CellResidentUnit.UnitTurnWaitValue += data.Ability.Ability.TurnWaitValueCost;
            
            if (MoveAbilities.Contains(data.Ability.Ability))
            {
                data.Ability.EffectiveUses = 0;
                OnContinueTurn.UnityEvent.Invoke(data);
                return;
            }

            Debug.Log("Ability Name: " + data.Ability.Ability.AbilityName);
            Debug.Log("Source Cell Name: " + data.SourceCell.StaticData.CellName);
            Debug.Log("Target Cell Name: " + data.TargetCell.StaticData.CellName);
            Debug.Log("Source Unit: " + data.SourceCell.CellResidentUnit.UnitName);
            Debug.Log("Source Unit number of abilities: " + data.SourceCell.CellResidentUnit.UnitAbilities.Count);
            Debug.Log("Source Unit number of abilities with conditions: " + data.SourceCell.CellResidentUnit.UnitAbilities.Count(ability => !MoveAbilities.Contains(ability.Ability)));
            
            foreach (var ability in data.SourceCell.CellResidentUnit.UnitAbilities.Where(ability => !MoveAbilities.Contains(ability.Ability)))
                ability.EffectiveUses = 0;

            OnContinueTurn.UnityEvent.Invoke(data);
        }

        #endregion
    }
}