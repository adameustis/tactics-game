using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

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
    public virtual void Start()
    {
        Initialise(Model);
    }
    public void OnDestroy()
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
        SubscribeToEvents();
    }

    #endregion
}
