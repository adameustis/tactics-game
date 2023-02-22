using MVC.Ability;
using UnityEngine;

namespace MVC.Text
{
    public class AbilityNameTextController : TextController
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityModel ability;
        #endregion
        #region Events
        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; private set => ability = value; }

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

        public void Initialise(AbilityModel setAbility)
        {
            Ability = setAbility;
            UpdateText(setAbility.Ability.AbilityName);
        }
        
        public void UpdateText(string setText) => TextComponent.text = setText;

        #endregion
    }
}