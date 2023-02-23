using MVC.EventData;
using MVC.Unit;
using UnityEngine;

namespace MVC.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Fields

        [Header("Fields")] 
        [SerializeField] public PlayerModel model;
        #endregion
        #region Events
        #endregion
        #region Properties
        public PlayerModel Model { get => model; set => model = value; }

        #endregion
        #region Event Properties
        #endregion
        #region MonoBehaviour
        #endregion
        #region Methods
        
        public void SetPlayerBasedOnContextPlayerModel(PlayerAndTransformData context)
        {
            Model = context.Player;
        }
        
        #endregion
    }
}