using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInputView
{
    #region Events

    #endregion
    #region Properties

    UnityEvent EventInputBack { get; set; }
    UnityEvent EventInputDown { get; set; }
    UnityEvent EventInputLeft { get; set; }
    UnityEvent EventInputOk { get; set; }
    UnityEvent EventInputRight { get; set; }
    UnityEvent EventInputUp { get; set; }

    #endregion
    #region Methods

    void InputBack();
    void InputDown();
    void InputLeft();
    void InputOk();
    void InputRight();
    void InputUp();

    #endregion
}
