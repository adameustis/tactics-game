using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEvents;

namespace MVC.Selection
{
    public class SelectionController : MonoBehaviour
    {
        #region Values
    
        [FormerlySerializedAs("model")] [SerializeField] protected SelectionData data;
    
        #endregion
        #region Events
    
        [FormerlySerializedAs("eventSelected")] [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> selectedEvent;
        [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> doubleSelectedEvent;
        [FormerlySerializedAs("eventDeselected")] [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> deselectedEvent;

        #endregion
        #region Properties
    
        public SelectionData Data { get => data; set => data = value; }
    
        #endregion
        #region Event Properties
    
        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

        public EventAbstractSO<UnityEventPlayerModelAndTransform> DoubleSelectedEvent
        {
            get => doubleSelectedEvent;
            set => doubleSelectedEvent = value;
        }

        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> DeselectedEvent { get => deselectedEvent; set => deselectedEvent = value; }


        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region MonoBehaviour
    
        public void Start()
        {
            Init(Data);
        }

        #endregion
        #region Methods

        public void Init(SelectionData setData)
        {
            Data = setData;
        }

        public void Select(PlayerModel player)
        {
            if (Data.IsSelected) return;
            Data.IsSelected = true;
            SelectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
        }

        public void DoubleSelect(PlayerModel player)
        {
            if (!Data.IsSelected) return;
            DoubleSelectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
        }
    
        public void Deselect(PlayerModel player)
        {
            if (!Data.IsSelected) return;
            Data.IsSelected = false;
            DeselectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
        }

        #endregion
    }
}
