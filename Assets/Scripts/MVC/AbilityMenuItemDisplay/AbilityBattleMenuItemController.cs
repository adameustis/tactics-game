using UnityEngine;
using UnityEngine.UI;

namespace MVC.AbilityMenuItemDisplay
{
    [System.Serializable]
    public class AbilityBattleMenuItemController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityModel Ability { get; private set; }
        [field: SerializeField] public UnitBattleController SourceUnit { get; private set; }
        [field: SerializeField] public Text TextName { get; private set; }
        [field: SerializeField] public Text TextDescription { get; private set; }
        [field: SerializeField] public Image Icon { get; private set; }
    
        #endregion
        #region Event Properties
        #endregion
        #region Monobehaviour
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void Initialise(AbilityModel setAbility, UnitBattleController setUnit)
        {
            Ability = setAbility;
            SourceUnit = setUnit;
            UpdateDisplay(setAbility);
        }

        public void UpdateDisplay(AbilityModel setModel)
        {
            TextName.text = setModel.Ability.AbilityName;
            //TextDescription.text = Data.GetDescription(); // Placeholder. Update this code in future.
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
}
