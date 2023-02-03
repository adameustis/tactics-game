using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEvents;

[CreateAssetMenu(fileName = "EventManagerSO", menuName = "ScriptableObjects/Manager/EventManagerSO")]
[System.Serializable] public class EventManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields
    #endregion
    #region Events

    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputCancel;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputDown;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputLeft;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputRight;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputSubmit;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputUp;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputMouseOff;
    [SerializeField] private UnityEventPlayerModelAndTransform eventCellInputMouseOn;

    #endregion
    #region Properties

    #endregion
    #region Event Properties

    public UnityEventPlayerModelAndTransform EventCellInputCancel { get => eventCellInputCancel; set => eventCellInputCancel = value; }
    public UnityEventPlayerModelAndTransform EventCellInputDown { get => eventCellInputDown; set => eventCellInputDown = value; }
    public UnityEventPlayerModelAndTransform EventCellInputLeft { get => eventCellInputLeft; set => eventCellInputLeft = value; }
    public UnityEventPlayerModelAndTransform EventCellInputRight { get => eventCellInputRight; set => eventCellInputRight = value; }
    public UnityEventPlayerModelAndTransform EventCellInputSubmit { get => eventCellInputSubmit; set => eventCellInputSubmit = value; }
    public UnityEventPlayerModelAndTransform EventCellInputUp { get => eventCellInputUp; set => eventCellInputUp = value; }
    public UnityEventPlayerModelAndTransform EventCellInputMouseOff { get => eventCellInputMouseOff; set => eventCellInputMouseOff = value; }
    public UnityEventPlayerModelAndTransform EventCellInputMouseOn { get => eventCellInputMouseOn; set => eventCellInputMouseOn = value; }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
    }

    public void OnEnable()
    {
    }

    #endregion

}
