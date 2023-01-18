using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MouseOverManagerSO", menuName = "ScriptableObjects/Manager/MouseOverManagerSO")]
[System.Serializable]
public class MouseOverManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private bool boolAnObjectHasMouseOver;
    [SerializeField] private IMouseOver mouseOverObject;
    [SerializeField] private GameManagerSO gameManager;

    #endregion

    #region Properties

    public bool BoolAnObjectHasMouseOver
    {
        get
        {
            return boolAnObjectHasMouseOver;
        }

        private set
        {
            boolAnObjectHasMouseOver = value;
        }
    }

    public IMouseOver MouseOverObject
    {
        get
        {
            return mouseOverObject;
        }

        private set
        {
            if (BoolAnObjectHasMouseOver)
            {
                MouseOverObject.MouseOff();
            }
            if (value == null)
            {
                BoolAnObjectHasMouseOver = false;
            }
            else
            {
                BoolAnObjectHasMouseOver = true;
            }
            mouseOverObject = value;
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
        BoolAnObjectHasMouseOver = false;
        MouseOverObject = null;
    }

    public InstructionSO MouseOver(IMouseOver setObject)
    {
        InstructionSO instruction;
        instruction = GameManager.InstructionManager.MouseOver;
        // if (BoolAnObjectHasMouseOver && MouseOverObject == setObject)
        // {
        //     instruction = GameManager.InstructionManager.DoNothing;
        // }
        // else if (GameManager.UnitSelectionManager.BoolAnObjectIsSelected)
        // {
        //     if (GameManager.UnitSelectionManager.SelectedObject != setObject)
        //     {
        //         instruction = GameManager.UnitSelectionManager.SelectedObject.MouseOverOtherObject(setObject);
        //     }
        // }
        MouseOverObject = setObject;
        return instruction;
    }

    public InstructionSO MouseOff()
    {
        InstructionSO instruction;
        instruction = GameManager.InstructionManager.MouseOff;
        // if (GameManager.UnitSelectionManager.BoolAnObjectIsSelected)
        // {
        //     if (GameManager.UnitSelectionManager.SelectedObject != MouseOverObject)
        //     {
        //         instruction = GameManager.UnitSelectionManager.SelectedObject.MouseOffOtherObject(MouseOverObject);
        //     }
        // }
        MouseOverObject = null;
        return instruction;
    }

    public void OnBeforeSerialize()
    {

    }

    #endregion
}
