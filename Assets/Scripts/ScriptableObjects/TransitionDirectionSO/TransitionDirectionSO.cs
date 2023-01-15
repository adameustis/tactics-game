using MVC.EventModel;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.TransitionDirectionSO
{
    public abstract class TransitionDirectionSO : ScriptableObject
    {
        public abstract void TransitionToState(PlayerAndTransformEventModel context, StateBehaviour stateToTransitionTo);
    }
}