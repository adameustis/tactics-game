using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputController
{
    #region Event Subscriptions

    void SubscribeToEvents();
    void UnsubscribeFromEvents();

    #endregion
    #region Event Handlers

    void HandleInputBack();
    void HandleInputDown();
    void HandleInputLeft();
    void HandleInputOk();
    void HandleInputRight();
    void HandleInputUp();

    #endregion
}
