using MVC.EventData;
using MVC.State;
using UnityEngine;

namespace ScriptableObjects.TransitionDirectionSO
{
    public abstract class TransitionDirectionSO : ScriptableObject
    {
        public abstract void TransitionToState(PlayerAndTransformEventData context, StateBehaviour stateToTransitionTo);
    }
}