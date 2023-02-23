using System.Collections;
using System.Collections.Generic;
using MVC.EventData;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events
    #endregion
    #region Properties

    #endregion
    #region Event Properties

    [field: Header("Public Events")]
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputCancel { get; private set; }
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputDown { get; private set; }
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputLeft { get; private set; }
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputRight { get; private set; }
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputSubmit { get; private set; }
    [field: SerializeField] public EventPlayerModelAndTransformSO EventInputUp { get; private set; }
    
    [field: Header("Local Events")]
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputCancel { get; private set; }
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputDown { get; private set; }
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputLeft { get; private set; }
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputRight { get; private set; }
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputSubmit { get; private set; }
    [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalInputUp { get; private set; }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods
    
    public void InvokeInputCancel(PlayerAndTransformData context)
    {
        EventInputCancel.UnityEvent?.Invoke(context);
        LocalInputCancel?.Invoke(context);
    }
    
    public void InvokeInputDown(PlayerAndTransformData context)
    {
        EventInputDown.UnityEvent?.Invoke(context);
        LocalInputDown?.Invoke(context);
    }
    
    public void InvokeInputLeft(PlayerAndTransformData context)
    {
        EventInputLeft.UnityEvent?.Invoke(context);
        LocalInputLeft?.Invoke(context);
    }
    
    public void InvokeInputRight(PlayerAndTransformData context)
    {
        EventInputRight.UnityEvent?.Invoke(context);
        LocalInputRight?.Invoke(context);
    }
    
    public void InvokeInputSubmit(PlayerAndTransformData context)
    {
        EventInputSubmit.UnityEvent?.Invoke(context);
        LocalInputSubmit?.Invoke(context);
    }
    
    public void InvokeInputUp(PlayerAndTransformData context)
    {
        EventInputUp.UnityEvent?.Invoke(context);
        LocalInputUp?.Invoke(context);
    }
    
    #endregion
}
