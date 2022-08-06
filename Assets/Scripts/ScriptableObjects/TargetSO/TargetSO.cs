﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetSO", menuName = "ScriptableObjects/TargetSO")]
[System.Serializable]
public class TargetSO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string targetName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;


    #endregion
    #region Events
    #endregion
    #region Properties

    public string TargetName { get => targetName; private set => targetName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }

    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    #endregion
}
