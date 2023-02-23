using MVC.Ability;
using MVC.EventData;
using MVC.State;
using UnityEngine;

namespace MVC.StateMachine
{
    public class AbilityBattleMenuItemStateMachine : StateMachine
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public virtual StateBehaviour Usable { get; protected set; }
        [field: SerializeField] public virtual StateBehaviour Unusable { get; protected set; }
        [field: SerializeField] public AbilityController Ability { get; private set; }
        

        #endregion
        #region MonoBehaviour

        protected override void OnEnable()
        {
            if (StateQueue.Count > 0) return;
            
            if (Ability == null)
                AdvanceToState(new PlayerAndTransformData(new PlayerModel(), transform), DefaultState, false); // Player will need to come from somewhere
            else if (Ability.Model.EffectiveUses > 0)
                AdvanceToState(new PlayerAndTransformData(new PlayerModel(), transform), Usable, false); // Player will need to come from somewhere
            else
                AdvanceToState(new PlayerAndTransformData(new PlayerModel(), transform), Unusable, false); // Player will need to come from somewhere
        }
        
        #endregion
    }
}