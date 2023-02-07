using System;
using System.Collections;
using System.Collections.Generic;
using MVC.Ability;
using MVC.PerformingAbility;
using MVC.Target;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "AbilitySO", menuName = "ScriptableObjects/AbilitySO")]

public class AbilitySO : ScriptableObject
{
    #region Fields

    [SerializeField] private string abilityName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;
    [SerializeField] private int investment;
    [SerializeField] private int energy;
    [FormerlySerializedAs("range")] [SerializeField] private int minimumRange;
    [SerializeField] private int maximumRange;
    [SerializeField] private bool canTargetUnit;
    [SerializeField] private bool canTargetLand;
    [SerializeField] private bool canTargetAir;
    [SerializeField] private int uses;
    [FormerlySerializedAs("targetingType")] [SerializeField] private TargetingSO targeting;
    [SerializeField] private TargetController targetUnitPrefab;
    [SerializeField] private TargetController targetCellPrefab;
    [SerializeField] private AbilityController targetingPrefab;
    [SerializeField] private PerformingAbilityController performingPrefab;

    #endregion
    #region Events
    #endregion
    #region Properties

    public string AbilityName { get => abilityName; private set => abilityName = value; }
    private string Description { get => description; set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }
    public int Investment { get => investment; private set => investment = value; }
    public int Energy { get => energy; private set => energy = value; }
    public int MinimumRange { get => minimumRange; private set => minimumRange = value; }
    public int MaximumRange { get => maximumRange; private set => maximumRange = value; }
    public bool CanTargetUnit { get => canTargetUnit; private set => canTargetUnit = value; }
    public bool CanTargetLand { get => canTargetLand; private set => canTargetLand = value; }
    public bool CanTargetAir { get => canTargetAir; private set => canTargetAir = value; }
    public int Uses { get => uses; private set => uses = value; }
    public TargetingSO Targeting { get => targeting; private set => targeting = value; }
    public TargetController TargetUnitPrefab { get => targetUnitPrefab; private set => targetUnitPrefab = value; }
    public TargetController TargetCellPrefab { get => targetCellPrefab; private set => targetCellPrefab = value; }
    public AbilityController TargetingPrefab { get => targetingPrefab; private set => targetingPrefab = value; }
    public PerformingAbilityController PerformingPrefab { get => performingPrefab; set => performingPrefab = value; }

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
        formattedDescription = formattedDescription.Replace("{MinimumRange}", MinimumRange.ToString());
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
