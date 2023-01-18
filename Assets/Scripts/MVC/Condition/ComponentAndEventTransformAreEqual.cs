using MVC.EventModel;
using UnityEngine;

namespace MVC.Condition
{
    public class TransformAndEventTransformAreEqual : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public Transform TransformToCompare { get; private set; }

        #endregion
        #region Methods
        
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return context.Tf == TransformToCompare;
        }
        
        #endregion
    }
}