using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstructionManagerSO", menuName = "ScriptableObjects/Manager/InstructionManagerSO")]
[System.Serializable]
public class InstructionManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private InstructionSO doNothing;
    [SerializeField] private InstructionSO doubleSelect;
    [SerializeField] private InstructionSO mouseOff;
    [SerializeField] private InstructionSO mouseOver;
    [SerializeField] private InstructionSO select;

    #endregion
    #region Events
    #endregion
    #region Properties

    public InstructionSO DoNothing { get => doNothing; set => doNothing = value; }
    public InstructionSO DoubleSelect { get => doubleSelect; set => doubleSelect = value; }
    public InstructionSO MouseOff { get => mouseOff; set => mouseOff = value; }
    public InstructionSO MouseOver { get => mouseOver; set => mouseOver = value; }
    public InstructionSO Select { get => select; set => select = value; }

    #endregion
    #region Event Properties
    #endregion
    #region Methods
    #endregion
}
