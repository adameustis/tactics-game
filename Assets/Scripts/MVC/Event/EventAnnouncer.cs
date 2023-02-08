using System;
using System.Collections.Generic;
using System.Linq;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Event
{
    public class EventAnnouncer : MonoBehaviour
    {
        #region Properties
        [field: Header("Condition List is optional.")]
        [field: SerializeField] public List<Condition.Condition> ConditionsList { get; private set; }
        
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicAnnouncement { get; private set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformEventModel> LocalAnnouncement { get; private set; }
        
        #endregion
        #region Monobehaviour
        #endregion
        #region Methods

        public void Announce(PlayerAndTransformEventModel context)
        {
            // Guard Clause: Check if any of the conditions are not met
            if (ConditionsList.Any(condition => !condition.IsMet(context))) return;
        
            LocalAnnouncement.Invoke(context);
            PublicAnnouncement.UnityEvent.Invoke(context);
        }

        #endregion
    }
}