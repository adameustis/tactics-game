using MVC.Ability;
using MVC.Cell;
using MVC.EventData;
using MVC.Image;
using MVC.SelectArea;
using MVC.Text;
using MVC.Unit;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVC.AbilityMenu
{
    public class AbilityMenuItemController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityMenuItemData data;
        // [SerializeField] private PlayerModel player;
        // [SerializeField] private AbilityModel ability;
        // [FormerlySerializedAs("unit")] [SerializeField] private UnitModel sourceUnit;
        // [SerializeField] private CellModel sourceCell;
        [SerializeField] private Button uIButton;
        [SerializeField] private AbilityImageController imageController;
        [SerializeField] private AbilityNameTextController nameTextController;

        #endregion
        #region Fields
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onMenuItemClicked;

        #endregion
        #region Properties
        public AbilityMenuItemData Data { get => data; private set => data = value; }
        // public PlayerModel Player { get => player; set => player = value; }
        // public AbilityModel Ability { get => ability; private set => ability = value; }
        // public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        // public CellModel SourceCell { get => sourceCell; set => sourceCell = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }
        public AbilityImageController ImageController { get => imageController; private set => imageController = value; }
        public AbilityNameTextController NameTextController { get => nameTextController; private set => nameTextController = value; }

        #endregion
        #region Event Properties
        public EventPlayerModelAndTransformSO OnMenuItemClicked { get => onMenuItemClicked; private set => onMenuItemClicked = value; }

        #endregion
        #region Event Handlers

        public void HandleOnClick() => InvokeMenuItemClicked(Data);

        #endregion
        #region Methods

        public void Initialise(SelectAreaData areaData, AbilityModel setAbility)
        {
            Data = new AbilityMenuItemData(areaData.Player, transform, areaData.SourceCell, setAbility);
            
            ImageController.Initialise(setAbility);
            NameTextController.Initialise(setAbility);
        }
        
        public void InvokeMenuItemClicked(AbilityMenuItemData setData) => OnMenuItemClicked.UnityEvent.Invoke(setData);

        
        #endregion
    }
}