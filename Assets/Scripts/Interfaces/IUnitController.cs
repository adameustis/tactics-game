using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitController
{
    #region Event Subscriptions

    void SubscribeToEvents();
    void UnsubscribeFromEvents();

    #endregion
    #region Event Handlers

    void HandleUnitNumberChanged();
    void HandleUnitNameChanged();
    void HandleUnitIconChanged();
    void HandleUnitAbilityAdded(AbilityModel ability);
    void HandleUnitAbilityRemoved(AbilityModel ability);
    void HandleUnitCanLandTraverseChanged();
    void HandleUnitCanAirTraverseChanged();
    void HandleUnitCanStopOnLandChanged();
    void HandleUnitCanStopInAirChanged();
    void HandleUnitHasCellResidenceChanged();
    void HandleUnitCellResidenceChanged();
    void HandleUnitOnTurnChanged();
    void HandleUnitTurnWaitValueChanged();
    void HandleUnitDistanceTravelledChanged();

    #endregion
}
