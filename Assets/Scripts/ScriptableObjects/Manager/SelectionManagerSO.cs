using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionManagerSO", menuName = "ScriptableObjects/Manager/SelectionManagerSO")]
[System.Serializable] public class SelectionManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private bool boolAnObjectIsSelected;
    [SerializeField] private ISelectable selectedObject;
    [SerializeField] private GameManagerSO gameManager;

    #endregion

    #region Properties

    public bool BoolAnObjectIsSelected
    {
        get
        {
            return boolAnObjectIsSelected;
        }

        private set
        {
            boolAnObjectIsSelected = value;
        }
    }

    public ISelectable SelectedObject
    {
        get
        {
            return selectedObject;
        }

        private set
        {
            if (BoolAnObjectIsSelected)
            {
                SelectedObject.Deselect();
            }
            if(value == null)
            {
                BoolAnObjectIsSelected = false;
            }
            else
            {
                BoolAnObjectIsSelected = true;
            }
            selectedObject = value;
        }
    }

    public GameManagerSO GameManager { get => gameManager; set => gameManager = value; }

    #endregion

    #region Methods

    public void OnAfterDeserialize()
    {
        Initialise();
    }

    public void OnEnable() { }

    public void Initialise()
    {
        BoolAnObjectIsSelected = false;
        SelectedObject = null;
    }

    public InstructionSO SelectObject(ISelectable setObject)
    {
        InstructionSO instruction;
        if (!BoolAnObjectIsSelected)
        {
            instruction = GameManager.InstructionManager.Select;
            SelectedObject = setObject;
        }
        else if(SelectedObject == setObject)
        {
            instruction = GameManager.InstructionManager.DoubleSelect;
        }
        else
        {
            instruction = SelectedObject.SelectOtherObject(setObject);
            if (instruction == GameManager.InstructionManager.Select)
            {
                SelectedObject = setObject;
            }
        }
        return instruction;
    }

    public void DeselectObject()
    {
        SelectedObject = null;
    }

    public void OnBeforeSerialize()
    {

    }

    #endregion
}
