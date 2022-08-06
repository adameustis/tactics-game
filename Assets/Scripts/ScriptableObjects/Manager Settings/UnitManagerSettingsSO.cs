using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitManagerSettingsSO", menuName = "ScriptableObjects/Settings/UnitManagerSettingsSO")]
[System.Serializable] public class UnitManagerSettingsSO : ScriptableObject
{
    #region Fields

    // Runtime Values
    [SerializeField] private List<UnitSettingsModel> unitSettingsList;

    #endregion

    #region Properties

    public List<UnitSettingsModel> UnitSettingsList
    {
        get
        {
            if(unitSettingsList == null)
            {
                unitSettingsList = new List<UnitSettingsModel>();
            }
            return unitSettingsList;
        }
        set
        {
            unitSettingsList = value;
        }
    }

    #endregion

    #region Methods
    #endregion
}
