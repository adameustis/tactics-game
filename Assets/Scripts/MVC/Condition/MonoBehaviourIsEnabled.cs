using MVC.EventData;
using UnityEngine;

namespace MVC.Condition
{
    public class MonoBehaviourIsEnabled : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public MonoBehaviour TheMonoBehaviour { get; private set; }

        #endregion
        #region Methods
        
        public override bool IsMet(PlayerAndTransformData context)
        {
            return TheMonoBehaviour.enabled;
        }
        
        #endregion
    }
}