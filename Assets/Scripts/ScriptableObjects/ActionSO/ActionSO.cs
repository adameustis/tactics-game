using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionSO", menuName = "ScriptableObjects/ActionSO")]

public class ActionSO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string actionName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;


    #endregion
    #region Events
    #endregion
    #region Properties

    public string ActionName { get => actionName; private set => actionName = value; }
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
