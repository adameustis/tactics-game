using UnityEngine;

namespace MVC.EventModel
{
    [System.Serializable]
    public class PlayerAndTransformEventModel
    {
        #region Fields
        
        private PlayerModel player;
        private Transform tf;
        
        #endregion
        #region Properties
        
        public PlayerModel Player => player;
        public Transform Tf => tf;
        
        #endregion
        #region Constructors
        
        public PlayerAndTransformEventModel(PlayerModel player, Transform tf)
        {
            this.player = player;
            this.tf = tf;
        }

        #endregion
    }
}