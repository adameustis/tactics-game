using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "ComponentAndEventTransformsAreEqual", menuName = "ScriptableObjects/Conditions/ComponentAndEventTransformsAreEqual")]
    public class ComponentAndEventTransformsAreEqual : ConditionSO
    {
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            return context.Tf == componentTransform;
        }
    }
}