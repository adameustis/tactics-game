using MVC.EventData;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.TransitionDirectionSO
{
    [CreateAssetMenu(fileName = "BackwardTransition", menuName = "ScriptableObjects/TransitionDirections/BackwardTransition")]
    public class BackwardTransition : TransitionDirectionSO
    {
        public override void TransitionToState(PlayerAndTransformData context, StateBehaviour stateToTransitionTo)
        {
            stateToTransitionTo.Machine.ReturnToPreviousState(context);
        }
    }
}