using System.Collections;
using System.Collections.Generic;
using Interfaces;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class AbilityMenuItemDisplayController : MonoBehaviour
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private Text textName;
    [SerializeField] private Text textDescription;
    [SerializeField] private Image icon;

    #endregion
    #region Events
    #endregion
    #region Properties
    public Text TextName
    {
        get
        {
            return textName;
        }

        set
        {
            textName = value;
        }
    }

    public Text TextDescription
    {
        get
        {
            return textDescription;
        }

        set
        {
            textDescription = value;
        }
    }

    public Image Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    #endregion
    #region Event Properties
    #endregion
    #region Monobehaviour
    public virtual void Start()
    {
        AbilityModel model = transform.GetComponent<AbilityController>().Model;
        if (model == null)
            return;
        Initialise(model);
    }

    #endregion
    #region Event Subscriptions
    #endregion
    #region Event Handlers
    #endregion
    
    #region Methods

    public void Initialise(AbilityModel setModel)
    {
        UpdateDisplay(setModel);
    }

    public void UpdateDisplay(AbilityModel setModel)
    {
        TextName.text = setModel.Ability.AbilityName;
        //TextDescription.text = Model.GetDescription(); // Placeholder. Update this code in future.
        Icon.sprite = setModel.Ability.DisplayIcon;
    }

    public void ClearDisplay()
    {
        TextName.text = "";
        //TextDescription.text = "";
        Icon.sprite = null;
    }

    #endregion
}
