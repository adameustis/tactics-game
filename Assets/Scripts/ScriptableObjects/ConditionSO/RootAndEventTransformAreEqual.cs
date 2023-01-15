using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "RootAndEventTransformAreEqual", menuName = "ScriptableObjects/Conditions/RootAndEventTransformAreEqual")]
    public class RootAndEventTransformAreEqual : ConditionSO
    {
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            return context.Tf == componentTransform.root;
        }
    }
}