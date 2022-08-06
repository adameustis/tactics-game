using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMouseOverView
{
    #region Events

    #endregion
    #region Properties

    UnityEvent EventMouseOff { get; set; }
    UnityEvent EventMouseOn { get; set; }


    #endregion
    #region Methods

    void MouseOff();
    void MouseOn();

    #endregion
}
