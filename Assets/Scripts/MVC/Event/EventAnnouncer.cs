using MVC.EventData;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;

namespace MVC.Event
{
    public class EventAnnouncer : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private PlayerAndTransformData data;

        #endregion
        #region Events

        [Header("Events")] 
        [SerializeField] public EventPlayerModelAndTransformSO publicAnnouncement;

        #endregion
        #region Properties

        public PlayerAndTransformData Data { get => data; private set => data = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO PublicAnnouncement { get => publicAnnouncement; private set => publicAnnouncement = value; }

        #endregion
        #region Monobehaviour
        #endregion
        #region Methods
        
        public void Initialise(PlayerAndTransformData setData) => Data = setData;
        public void Announce() => PublicAnnouncement.UnityEvent.Invoke(Data);

        #endregion
    }
}