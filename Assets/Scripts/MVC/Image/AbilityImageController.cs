using MVC.Ability;
using UnityEngine;

namespace MVC.Image
{
    public class AbilityImageController : ImageController
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
            UpdateSprite(setAbility.Ability.DisplayIcon);
        }
        
        public void UpdateSprite(Sprite setSprite) => ImageComponent.sprite = setSprite;

        #endregion
    }
}