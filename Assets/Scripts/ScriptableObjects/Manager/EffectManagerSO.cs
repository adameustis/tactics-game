using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectManagerSO", menuName = "ScriptableObjects/Manager/EffectManagerSO")]
public class EffectManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]

    [SerializeField] private EffectSO effectBlock;
    [SerializeField] private EffectSO effectBurn;
    [SerializeField] private EffectSO effectCounter;
    [SerializeField] private EffectSO effectDamage;
    [SerializeField] private EffectSO effectEndTurn;
    [SerializeField] private EffectSO effectMove;
    [SerializeField] private EffectSO effectNothing;

    #endregion
    #region Properties

    public EffectSO EffectBlock { get => effectBlock; set => effectBlock = value; }
    public EffectSO EffectBurn { get => effectBurn; set => effectBurn = value; }
    public EffectSO EffectCounter { get => effectCounter; set => effectCounter = value; }
    public EffectSO EffectDamage { get => effectDamage; set => effectDamage = value; }
    public EffectSO EffectEndTurn { get => effectEndTurn; set => effectEndTurn = value; }
    public EffectSO EffectMove { get => effectMove; set => effectMove = value; }
    public EffectSO EffectNothing { get => effectNothing; set => effectNothing = value; }
    
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
