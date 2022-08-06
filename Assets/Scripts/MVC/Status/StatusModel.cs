using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusModel
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private StatusSO status;
    [SerializeField] private int exhaustValue; // No effective version as I don't think this needs to be returned to default
    [SerializeField] private TargetSO target;
    [SerializeField] private EffectModel[] targetEffectArray;



    #endregion
    #region Events
    #endregion
    #region Properties

    public StatusSO Status { get => status; set => status = value; }
    public int ExhaustValue { get => exhaustValue; set => exhaustValue = value; }
    public TargetSO Target { get => target; set => target = value; }
    public EffectModel[] TargetEffectArray { get => targetEffectArray; set => targetEffectArray = value; }

    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public StatusModel ShallowCopy()
    {
        return (StatusModel)this.MemberwiseClone();
    }

    public StatusModel DeepCopy()
    {
        StatusModel copy = new StatusModel();
        copy.ExhaustValue = ExhaustValue;
        copy.Target = Target;

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
