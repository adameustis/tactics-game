using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellBattleDisplayController : MonoBehaviour
{
    #region Delegates
    #endregion
    #region Fields
    [Header("Fields")]
    private Image cellIcon;
    private Text cellName;
    #endregion
    #region Properties

    public Sprite CellIconSprite
    {
        get
        {
            return cellIcon.sprite;
        }

        set
        {
            if (cellIcon != null)
            {
                cellIcon.sprite = value;
            }
        }
    }

    public string CellNameText
    {
        get
        {
            return cellName.text;
        }

        set
        {
            if (cellName != null)
            {
                cellName.text = value;
            }
        }
    }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour

    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    public void Initialise()
    {
    }
    #endregion
}
