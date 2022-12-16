using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "TargetingTypeManagerSO", menuName = "ScriptableObjects/Manager/TargetingTypeManagerSO")]
public class TargetingTypeManagerSO : ScriptableObject
{
    #region Fields

    [FormerlySerializedAs("targetingTypeAdjacent")]
    [Header("Fields")]
    [SerializeField] private TargetingSO targetingAdjacent;
    [FormerlySerializedAs("targetingTypeAdjacentOrSelf")] [SerializeField] private TargetingSO targetingAdjacentOrSelf;
    [FormerlySerializedAs("targetingTypeInstant")] [SerializeField] private TargetingSO targetingInstant;
    [FormerlySerializedAs("targetingTypeMove")] [SerializeField] private TargetingSO targetingMove;
    [FormerlySerializedAs("targetingTypeRange")] [SerializeField] private TargetingSO targetingRange;
    [FormerlySerializedAs("targetingTypeThrough")] [SerializeField] private TargetingSO targetingThrough;

    #endregion
    #region Properties

    public TargetingSO TargetingAdjacent { get => targetingAdjacent; set => targetingAdjacent = value; }
    public TargetingSO TargetingAdjacentOrSelf { get => targetingAdjacentOrSelf; set => targetingAdjacentOrSelf = value; }
    public TargetingSO TargetingInstant { get => targetingInstant; set => targetingInstant = value; }
    public TargetingSO TargetingMove { get => targetingMove; set => targetingMove = value; }
    public TargetingSO TargetingRange { get => targetingRange; set => targetingRange = value; }
    public TargetingSO TargetingThrough { get => targetingThrough; set => targetingThrough = value; }


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
