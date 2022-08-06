using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO", menuName = "ScriptableObjects/EffectSO")]

public class EffectSO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string effectName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;


    #endregion
    #region Events
    #endregion
    #region Properties

    public string EffectName { get => effectName; private set => effectName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }


    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public string GetDescription(TargetSO target, int power)
    {
        string formattedDescription = Description;
        formattedDescription = formattedDescription.Replace("{TargetName}", target.TargetName);
        formattedDescription = formattedDescription.Replace("{Power}", power.ToString());
        formattedDescription = formattedDescription.Replace("{EffectName}", EffectName);
        return formattedDescription;
    }

    #endregion
}
