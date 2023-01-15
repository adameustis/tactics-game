using MVC.EventModel;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.TransitionDirectionSO
{
    [CreateAssetMenu(fileName = "BackwardTransition", menuName = "ScriptableObjects/TransitionDirections/BackwardTransition")]
    public class BackwardTransition : TransitionDirectionSO
    {
        public override void TransitionToState(PlayerAndTransformEventModel context, StateBehaviour stateToTransitionTo)
        {
            stateToTransitionTo.Controller.ReturnToPreviousState(context);
        }
    }
}