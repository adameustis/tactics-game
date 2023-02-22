using UnityEngine;

namespace MVC.EventData
{
    [System.Serializable]
    public class PlayerAndTransformEventData
    {
        #region Fields
        
        protected PlayerModel player;
        protected Transform tf;
        
        #endregion
        #region Properties
        
        public PlayerModel Player => player;
        public Transform Tf => tf;
        
        #endregion
        #region Constructors
        
        public PlayerAndTransformEventData(PlayerModel player, Transform tf)
        {
            this.player = player;
            this.tf = tf;
        }

        #endregion
    }
}