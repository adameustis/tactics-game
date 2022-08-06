using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectModel
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private EffectSO effect;
    [SerializeField] private TargetSO target;
    [SerializeField] private int power;


    #endregion
    #region Events
    #endregion
    #region Properties

    public EffectSO Effect { get => effect; set => effect = value; }
    public TargetSO Target { get => target; set => target = value; }
    public int Power { get => power; set => power = value; }


    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public EffectModel ShallowCopy()
    {
        return (EffectModel)this.MemberwiseClone();
    }

    public EffectModel DeepCopy()
    {
        EffectModel copy = new EffectModel();
        copy.Effect = Effect;
        copy.Target = Target;
        copy.Power = Power;

        // If non-value objects not int, double etc. need to add code like examples below
        // copy.PropertyNameHere = new ClassNameHere(PropertyNameHere);
        // copy.AbilityName = String.Copy(AbilityName);

        return copy;
    }

    public string GetDescription()
    {
        return "To Do";
    }

    #endregion
}
