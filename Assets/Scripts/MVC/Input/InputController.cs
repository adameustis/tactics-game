using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events

    [SerializeField] private EventPlayerModelAndTransformSO eventInputCancel;
    [SerializeField] private EventPlayerModelAndTransformSO eventInputDown;
    [SerializeField] private EventPlayerModelAndTransformSO eventInputLeft;
    [SerializeField] private EventPlayerModelAndTransformSO eventInputRight;
    [SerializeField] private EventPlayerModelAndTransformSO eventInputSubmit;
    [SerializeField] private EventPlayerModelAndTransformSO eventInputUp;

    #endregion
    #region Properties

    #endregion
    #region Event Properties

    public EventPlayerModelAndTransformSO EventInputCancel { get => eventInputCancel; set => eventInputCancel = value; }
    public EventPlayerModelAndTransformSO EventInputDown { get => eventInputDown; set => eventInputDown = value; }
    public EventPlayerModelAndTransformSO EventInputLeft { get => eventInputLeft; set => eventInputLeft = value; }
    public EventPlayerModelAndTransformSO EventInputRight { get => eventInputRight; set => eventInputRight = value; }
    public EventPlayerModelAndTransformSO EventInputSubmit { get => eventInputSubmit; set => eventInputSubmit = value; }
    public EventPlayerModelAndTransformSO EventInputUp { get => eventInputUp; set => eventInputUp = value; }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods
    #endregion
}
