using MVC.Ability;
using MVC.Unit;
using UnityEngine;

namespace MVC.AbilityMenu
{
    public class AbilityMenuItemController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityController ability;
        [SerializeField] private UnitController unit;

        #endregion
        #region Properties

        public AbilityController Ability { get => ability; private set => ability = value; }
        public UnitController Unit { get => unit; private set => unit = value; }

        #endregion
        #region Methods

        public void Initialise(AbilityModel setAbility, UnitModel setUnit)
        {
            Ability.Model = setAbility;
            Unit.Model = setUnit;
        }
        
        #endregion
    }
}