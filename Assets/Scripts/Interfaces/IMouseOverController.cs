using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseOverController
{
    #region Event Subscriptions

    void SubscribeToEvents();
    void UnsubscribeFromEvents();

    #endregion
    #region Event Handlers

    void HandleMouseOff();
    void HandleMouseOn();

    #endregion
}
