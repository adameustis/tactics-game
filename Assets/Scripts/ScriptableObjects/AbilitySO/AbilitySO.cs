using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    [SerializeField] private TargetingTypeSO targetingType;

    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> castEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> stopCastEvent;
    
    #endregion
    #region Properties

    public string AbilityName { get => abilityName; private set => abilityName = value; }
    private string Description { get => description; set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }
    public int Investment { get => investment; private set => investment = value; }
    public int Energy { get => energy; private set => energy = value; }
    public int Range { get => range; private set => range = value; }
    public int Uses { get => uses; private set => uses = value; }
    public TargetingTypeSO TargetingType { get => targetingType; private set => targetingType = value; }

    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> CastEvent { get => castEvent; set => castEvent = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> StopCastEvent { get => castEvent; set => stopCastEvent = value; }
    
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
        formattedDescription = formattedDescription.Replace("{TargettingTypeName}", TargetingType.TargetingTypeName);

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
