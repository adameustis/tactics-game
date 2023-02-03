using MVC.Ability;
using UnityEngine;

namespace MVC.Text
{
    public class AbilityNameTextController : TextController
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityController Ability { get; private set; }

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

        public void UpdateText() => TextComponent.text = Ability.Model.Ability.AbilityName;

        #endregion
    }
}