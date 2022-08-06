using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetManagerSO", menuName = "ScriptableObjects/Manager/TargetManagerSO")]
public class TargetManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]
    
    [SerializeField] private TargetSO targetAllAllies;
    [SerializeField] private TargetSO targetAllCells;
    [SerializeField] private TargetSO targetAllEnemies;
    [SerializeField] private TargetSO targetAllUnits;
    [SerializeField] private TargetSO targetAttacker;
    [SerializeField] private TargetSO targetPrimaryTargetCell;
    [SerializeField] private TargetSO targetPrimaryTargetUnit;
    [SerializeField] private TargetSO targetSecondaryTargetCell;
    [SerializeField] private TargetSO targetSecondaryTargetUnit;
    [SerializeField] private TargetSO targetSelfCell;
    [SerializeField] private TargetSO targetSelfUnit;

    #endregion
    #region Properties

    public TargetSO TargetAllAllies { get => targetAllAllies; set => targetAllAllies = value; }
    public TargetSO TargetAllCells { get => targetAllCells; set => targetAllCells = value; }
    public TargetSO TargetAllEnemies { get => targetAllEnemies; set => targetAllEnemies = value; }
    public TargetSO TargetAllUnits { get => targetAllUnits; set => targetAllUnits = value; }
    public TargetSO TargetAttacker { get => targetAttacker; set => targetAttacker = value; }
    public TargetSO TargetPrimaryTargetCell { get => targetPrimaryTargetCell; set => targetPrimaryTargetCell = value; }
    public TargetSO TargetPrimaryTargetUnit { get => targetPrimaryTargetUnit; set => targetPrimaryTargetUnit = value; }
    public TargetSO TargetSecondaryTargetCell { get => targetSecondaryTargetCell; set => targetSecondaryTargetCell = value; }
    public TargetSO TargetSecondaryTargetUnit { get => targetSecondaryTargetUnit; set => targetSecondaryTargetUnit = value; }
    public TargetSO TargetSelfCell { get => targetSelfCell; set => targetSelfCell = value; }
    public TargetSO TargetSelfUnit { get => targetSelfUnit; set => targetSelfUnit = value; }

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
