using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusSO", menuName = "ScriptableObjects/StatusSO")]

public class StatusSO : ScriptableObject
{
    #region Delegates
    #endregion
    #region Fields

    [SerializeField] private string statusName;
    [SerializeField] private string description;
    [SerializeField] private Sprite displayIcon;
    [SerializeField] private ActionSO activateTrigger;
    [SerializeField] private ActionSO exhaustTrigger;

    #endregion
    #region Events
    #endregion
    #region Properties

    public string StatusName { get => statusName; private set => statusName = value; }
    private string Description { get => description; set => description = value; }
    public Sprite DisplayIcon { get => displayIcon; private set => displayIcon = value; }
    public ActionSO ActivateTrigger { get => activateTrigger; private set => activateTrigger = value; }
    public ActionSO ExhaustTrigger { get => exhaustTrigger; private set => exhaustTrigger = value; }


    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public string GetDescription(int power, int exhaustValue)
    {
        string formattedDescription = Description;
        //formattedDescription = formattedDescription.Replace("{Power}", power.ToString());
        //formattedDescription = formattedDescription.Replace("{ExhaustValue}", exhaustValue.ToString());
        //formattedDescription = formattedDescription.Replace("{StatusName}", StatusName);
        //formattedDescription = formattedDescription.Replace("{ActivateActionName}", ActivateTrigger.ActionName);
        //formattedDescription = formattedDescription.Replace("{ExhaustActionName}", ExhaustTrigger.ActionName);
        //formattedDescription = formattedDescription.Replace("{ActivateEffectName}", ActivateEffect.Effect.EffectName);
        //formattedDescription = formattedDescription.Replace("{ActivateSkillName}", ActivateStatus.Status.StatusName);
        //formattedDescription = formattedDescription.Replace("{ActivateEffectDescription}", ActivateEffect.GetDescription());
        //formattedDescription = formattedDescription.Replace("{ActivateStatusDescription}", ActivateStatus.GetDescription());
        return formattedDescription;
    }

    #endregion
}
