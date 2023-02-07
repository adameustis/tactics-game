using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


[System.Serializable]
public class AbilityModel
{
    #region Delegates
    #endregion
    #region Fields
    [SerializeField] private AbilitySO ability;
    [SerializeField] private int level;
    [SerializeField] private int investment;
    [SerializeField] private int effectiveEnergy;
    [SerializeField] private int effectiveRange;
    [SerializeField] private int effectiveUses;
    [FormerlySerializedAs("effectiveTargetingType")] [SerializeField] private TargetingSO effectiveTargeting;
    [SerializeField] private EffectModel[] targetEffectArray;
    [SerializeField] private StatusModel[] targetStatusArray;

    #endregion
    #region Events

    private UnityEvent eventLevelChanged;
    private UnityEvent eventInvestmentChanged;
    private UnityEvent eventAbilityChanged;

    #endregion
    #region Properties

    public int Level
    {
        get => level;

        set
        {
            if (level == value) return;
            level = value;
            EventLevelChanged.Invoke();
        }
    }
    public int Investment
    {
        get => investment;

        set
        {
            if (investment == value) return;
            investment = value;
            EventInvestmentChanged.Invoke();
        }
    }

    public AbilitySO Ability
    {
        get => ability;

        set
        {
            if (ability == value) return;
            ability = value;
            EventAbilityChanged.Invoke();
        }
    }

    public int EffectiveEnergy { get => effectiveEnergy; set => effectiveEnergy = value; }
    public int EffectiveRange { get => effectiveRange; set => effectiveRange = value; }
    public int EffectiveUses { get => effectiveUses; set => effectiveUses = value; }
    public TargetingSO EffectiveTargeting { get => effectiveTargeting; set => effectiveTargeting = value; }
    public EffectModel[] TargetEffectArray { get => targetEffectArray; set => targetEffectArray = value; }
    public StatusModel[] TargetStatusArray { get => targetStatusArray; set => targetStatusArray = value; }

    #endregion
    #region Event Properties

    public UnityEvent EventLevelChanged
    {
        get
        {
            if (eventLevelChanged == null)
            {
                eventLevelChanged = new UnityEvent();
            }
            return eventLevelChanged;
        }

        set
        {
            eventLevelChanged = value;
        }
    }

    public UnityEvent EventInvestmentChanged
    {
        get
        {
            if (eventInvestmentChanged == null)
            {
                eventInvestmentChanged = new UnityEvent();
            }
            return eventInvestmentChanged;
        }

        set
        {
            eventInvestmentChanged = value;
        }
    }

    public UnityEvent EventAbilityChanged
    {
        get
        {
            if (eventAbilityChanged == null)
            {
                eventAbilityChanged = new UnityEvent();
            }
            return eventAbilityChanged;
        }

        set
        {
            eventAbilityChanged = value;
        }
    }
    
    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    // This should be called when the ability is equipped or at the start of battle. Not sure yet.
    public void Initialise()
    {
        EffectiveEnergy = Ability.Energy;
        EffectiveRange = Ability.MinimumRange;
        EffectiveTargeting = Ability.Targeting;
        EffectiveUses = Ability.Uses;
    }
    
    public AbilityModel ShallowCopy()
    {
        return (AbilityModel)this.MemberwiseClone();
    }

    public AbilityModel DeepCopy()
    {
        AbilityModel copy = new AbilityModel();
        copy.Ability = Ability;
        copy.Level = Level;
        copy.Investment = Investment;
        copy.EffectiveEnergy = EffectiveEnergy;
        copy.EffectiveRange = EffectiveRange;
        copy.EffectiveUses = EffectiveUses;
        copy.EffectiveTargeting = EffectiveTargeting;

        if (TargetEffectArray == null)
        {
            // Do nothing as no Effects
        }
        else if (TargetEffectArray.Length > 0)
        {
            copy.TargetEffectArray = new EffectModel[TargetEffectArray.Length];
            for (int i = 0; i < TargetEffectArray.Length; i++)
            {
                copy.TargetEffectArray[i] = TargetEffectArray[i].DeepCopy();
            }
        }

        if (TargetStatusArray == null)
        {
            // Do nothing as no Statuses
        }
        else if (TargetStatusArray.Length > 0)
        {
            copy.TargetStatusArray = new StatusModel[TargetStatusArray.Length];
            for (int i = 0; i < TargetStatusArray.Length; i++)
            {
                copy.TargetStatusArray[i] = TargetStatusArray[i].DeepCopy();
            }
        }
        
        // If non-value objects not int, double etc. need to add code like examples below
        // copy.PropertyNameHere = new ClassNameHere(PropertyNameHere);
        // copy.AbilityName = String.Copy(AbilityName);

        return copy;
    }

    public string GetDescription()
    {
        return Ability.GetDescription(TargetEffectArray, TargetStatusArray);
    }

    #endregion
}
