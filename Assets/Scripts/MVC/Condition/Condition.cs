using MVC.EventData;
using UnityEngine;

namespace MVC.Condition
{
    public abstract class Condition : MonoBehaviour
    {
        #region Methods
        public abstract bool IsMet(PlayerAndTransformData context);
        #endregion
    }
}