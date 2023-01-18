using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventSO;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetingTypeSO", menuName = "ScriptableObjects/TargetingTypeSO")]
[System.Serializable]
public class TargetingSO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string targetingTypeName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;
    
    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> cancel;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> start;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> finish;
    
    #endregion
    #region Properties

    public string TargetingTypeName { get => targetingTypeName; private set => targetingTypeName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }

    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> Cancel { get => cancel; set => cancel = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> Start { get => start; set => start = value; }
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> Finish
    {
        get => finish;
        set => finish = value;
    }
    
    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    #endregion
}
