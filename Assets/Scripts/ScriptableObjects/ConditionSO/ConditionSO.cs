using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    public abstract class ConditionSO : ScriptableObject
    {
        public abstract bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform);
    }
}