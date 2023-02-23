using UnityEngine;

namespace MVC.EventData
{
    [System.Serializable]
    public class PlayerAndTransformData
    {
        #region Fields
        [Header("PlayerAndTransformData Fields")]
        [SerializeField] protected PlayerModel player;
        [SerializeField] protected Transform tf;
        
        #endregion
        #region Properties

        public PlayerModel Player { get => player; protected set => player = value; }
        public Transform Tf { get => tf; protected set => tf = value; }

        #endregion
        #region Constructors
        
        public PlayerAndTransformData(PlayerModel setPlayer, Transform setTf)
        {
            Player = setPlayer;
            Tf = setTf;
        }

        #endregion
    }
}