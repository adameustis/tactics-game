using System.Collections.Generic;
using Interfaces;
using MVC.EventModel;
using UnityEngine;

namespace MVC.Ability
{
    [System.Serializable]
    public class AbilityController: MonoBehaviour, IEventSubscriptions {
        #region Delegates
        #endregion
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityModel model;

        #endregion
        #region Properties

        public AbilityModel Model { get => model; set => model = value; }

        #endregion
        #region Constructors
        #endregion
        #region MonoBehaviour
        public virtual void OnEnable()
        {
            SubscribeToEvents();
        }
        public void OnDisable()
        {
            UnsubscribeFromEvents();
        }
    
        #endregion
        #region Event Subscriptions

        public void SubscribeToEvents()
        {
            Model.EventAbilityChanged.AddListener(HandleAbilityChanged);
            Model.EventLevelChanged.AddListener(HandleLevelChanged);
            Model.EventInvestmentChanged.AddListener(HandleInvestmentChanged);
        }

        public void UnsubscribeFromEvents()
        {
            Model.EventAbilityChanged.RemoveListener(HandleAbilityChanged);
            Model.EventLevelChanged.RemoveListener(HandleLevelChanged);
            Model.EventInvestmentChanged.RemoveListener(HandleInvestmentChanged);
        }

        #endregion
        #region Event Handlers

        public void HandleAbilityChanged() {}
        public void HandleLevelChanged() {}
        public void HandleInvestmentChanged() {}

        #endregion
        #region Methods

        public void Initialise(AbilityModel setModel)
        {
            Model = setModel;
        }

        // public void SetAbilityBasedOnUnitSelectedAndSiblingIndex(PlayerAndTransformEventModel context)
        // {
        //     Model = null;
        //     List<AbilityModel> unitAbilities;
        //     
        //     if (context.Tf.TryGetComponent(out UnitController unit))
        //         unitAbilities = unit.Model.UnitAbilities;
        //     else
        //         return;
        //
        //     int siblingIndex = transform.GetSiblingIndex();
        //
        //     if (unitAbilities.Count < siblingIndex) return;
        //
        //     Model = unitAbilities[siblingIndex];
        // }
        
        #endregion
    }
}
