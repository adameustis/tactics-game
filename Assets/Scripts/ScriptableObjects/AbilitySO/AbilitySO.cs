using System;
using System.Collections;
using System.Collections.Generic;
using MVC.Target;
using MVC.TargetCell;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "AbilitySO", menuName = "ScriptableObjects/AbilitySO")]

public class AbilitySO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string abilityName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;
    [SerializeField] private int investment;
    [SerializeField] private int energy;
    [SerializeField] private int range;
    [SerializeField] private int uses;
    [FormerlySerializedAs("targetingType")] [SerializeField] private TargetingSO targeting;
    [SerializeField] private TargetUnitController targetUnitPrefab;
    [SerializeField] private TargetCellController targetCellPrefab;

    #endregion
    #region Events
    #endregion
    #region Properties

    public string AbilityName { get => abilityName; private set => abilityName = value; }
    private string Description { get => description; set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }
    public int Investment { get => investment; private set => investment = value; }
    public int Energy { get => energy; private set => energy = value; }
    public int Range { get => range; private set => range = value; }
    public int Uses { get => uses; private set => uses = value; }
    public TargetingSO Targeting { get => targeting; private set => targeting = value; }

    public TargetUnitController TargetUnitPrefab
    {
        get => targetUnitPrefab;
        set => targetUnitPrefab = value;
    }

    public TargetCellController TargetCellPrefab
    {
        get => targetCellPrefab;
        set => targetCellPrefab = value;
    }

    #endregion
    #region Event Properties
    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public string GetDescription(EffectModel[] targetEffectArray, StatusModel[] targetStatusArray)
    {
        string formattedDescription = Description;
        formattedDescription = formattedDescription.Replace("{AbilityName}", AbilityName);
        formattedDescription = formattedDescription.Replace("{Investment}", Investment.ToString());
        formattedDescription = formattedDescription.Replace("{Energy}", Energy.ToString());
        formattedDescription = formattedDescription.Replace("{Range}", Range.ToString());
        formattedDescription = formattedDescription.Replace("{Uses}", Uses.ToString());
        formattedDescription = formattedDescription.Replace("{TargettingTypeName}", Targeting.TargetingTypeName);

        if (targetEffectArray == null)
        {
            // Do nothing as no Effects
        }
        else if (targetEffectArray.Length > 0)
        {
            for (int i = 0; i < targetEffectArray.Length; i++)
            {
                formattedDescription = formattedDescription + targetEffectArray[i].GetDescription();
            }
        }

        if (targetStatusArray == null)
        {
            // Do nothing as no Statuses
        }
        else if (targetStatusArray.Length > 0)
        {
            for (int i = 0; i < targetStatusArray.Length; i++)
            {
                formattedDescription = formattedDescription + targetStatusArray[i].GetDescription();
            }
        }

        return formattedDescription;
    }

    #endregion
}
