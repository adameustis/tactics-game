using System.Collections.Generic;
using System.Linq;
using MVC.AbilityMenu;
using MVC.EventData;
using MVC.SelectArea;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.EndTurn
{
    public class EndTurnController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private UnityEvent<SelectAreaData> onEnterStateWithWarning;
        [SerializeField] private UnityEvent<SelectAreaData> onEnterStateNoWarning;
        #endregion
        #region Properties
        #endregion
        #region Event Properties
        public UnityEvent<SelectAreaData> OnEnterStateWithWarning { get => onEnterStateWithWarning; private set => onEnterStateWithWarning = value; }
        public UnityEvent<SelectAreaData> OnEnterStateNoWarning { get => onEnterStateNoWarning; private set => onEnterStateNoWarning = value; }
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
    
        public void HandleOnEnterState(PlayerAndTransformData context)
        {
            if(context is SelectAreaData eventData)
                Display(eventData);
        }

        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        private void Display(SelectAreaData data)
        {
            if (!data.SourceCell.CellResidentUnit.UnitOnTurn) return;
            
            if (data.SourceCell.CellResidentUnit.UnitAbilities.Any(ability => ability.EffectiveUses > 0))
                OnEnterStateWithWarning.Invoke(data);
            else
                OnEnterStateNoWarning.Invoke(data);
        }

        #endregion
    }
}