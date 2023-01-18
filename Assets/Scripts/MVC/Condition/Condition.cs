using MVC.EventModel;
using UnityEngine;

namespace MVC.Condition
{
    public abstract class Condition : MonoBehaviour
    {
        #region Methods
        public abstract bool IsMet(PlayerAndTransformEventModel context);
        #endregion
    }
}