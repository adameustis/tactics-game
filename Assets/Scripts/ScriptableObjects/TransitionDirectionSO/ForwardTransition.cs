using MVC.EventModel;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.TransitionDirectionSO
{
    [CreateAssetMenu(fileName = "ForwardTransition", menuName = "ScriptableObjects/TransitionDirections/ForwardTransition")]
    public class ForwardTransition : TransitionDirectionSO
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public bool ClearHistory { get; private set; }

        #endregion
        #region Methods

        public override void TransitionToState(PlayerAndTransformEventModel context, StateBehaviour stateToTransitionTo)
        {
            stateToTransitionTo.Machine.AdvanceToState(context, stateToTransitionTo, ClearHistory);
        }
        
        #endregion
    }
}