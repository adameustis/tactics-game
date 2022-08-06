using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetingTypeManagerSO", menuName = "ScriptableObjects/Manager/TargetingTypeManagerSO")]
public class TargetingTypeManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private TargetingTypeSO targetingTypeAdjacent;
    [SerializeField] private TargetingTypeSO targetingTypeAdjacentOrSelf;
    [SerializeField] private TargetingTypeSO targetingTypeInstant;
    [SerializeField] private TargetingTypeSO targetingTypeMove;
    [SerializeField] private TargetingTypeSO targetingTypeRange;
    [SerializeField] private TargetingTypeSO targetingTypeThrough;

    #endregion
    #region Properties

    public TargetingTypeSO TargetingTypeAdjacent { get => targetingTypeAdjacent; set => targetingTypeAdjacent = value; }
    public TargetingTypeSO TargetingTypeAdjacentOrSelf { get => targetingTypeAdjacentOrSelf; set => targetingTypeAdjacentOrSelf = value; }
    public TargetingTypeSO TargetingTypeInstant { get => targetingTypeInstant; set => targetingTypeInstant = value; }
    public TargetingTypeSO TargetingTypeMove { get => targetingTypeMove; set => targetingTypeMove = value; }
    public TargetingTypeSO TargetingTypeRange { get => targetingTypeRange; set => targetingTypeRange = value; }
    public TargetingTypeSO TargetingTypeThrough { get => targetingTypeThrough; set => targetingTypeThrough = value; }


    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    #endregion
}
