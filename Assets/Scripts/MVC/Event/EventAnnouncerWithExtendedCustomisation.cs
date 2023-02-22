using System;
using MVC.EventData;
using MVC.Player;
using UnityEngine;

namespace MVC.Event
{
    public class EventAnnouncerWithExtendedCustomisation : EventAnnouncer
    {
        #region Properties

        [Header("Extended Fields")] 
        [SerializeField] private PlayerModel thePlayer;
        [SerializeField] private Transform theTransform;
        
        #endregion
        #region Properties

        public PlayerModel ThePlayer { get => thePlayer; private set => thePlayer = value; }
        public Transform TheTransform { get => theTransform; private set => theTransform = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Monobehaviour
        

        #endregion
        #region Methods

        public void ExtendedAnnounce()
        {
            Announce(new PlayerAndTransformEventData(ThePlayer, TheTransform));
        }

        #endregion
    }
}