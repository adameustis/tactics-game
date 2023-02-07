using MVC.Ability;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;

namespace MVC.Target
{
    public class TargetAreaController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityController ability;
        [SerializeField] private UnitController unit;
        [SerializeField] private CellController cell;

        #endregion
        #region Properties

        public AbilityController Ability { get => ability; private set => ability = value; }
        public UnitController Unit { get => unit; private set => unit = value; }
        public CellController Cell { get => cell; private set => cell = value; }

        #endregion
        #region Methods

        public void Initialise(AbilityModel setAbility, UnitModel setUnit, CellModel setCell)
        {
            Ability.Model = setAbility;
            Unit.Model = setUnit;
            Cell.Model = setCell;
        }
        
        #endregion
    }
}