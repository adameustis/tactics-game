using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellUIController : MonoBehaviour
{
    #region Fields

    [SerializeField] private CellModel model;

    #endregion
    #region Events
    #endregion
    #region Properties

    public CellModel Model
    {
        get
        {
            if (model == null)
            {
                model = new CellModel();
            }
            return model;
        }

        set
        {
            model = value;
        }
    }

    #endregion
    #region Event Properties
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        Model.EventCellDescriptionChanged.AddListener(HandleCellDescriptionChanged);
        Model.EventCellIconChanged.AddListener(HandleCellIconChanged);
        Model.EventCellNameChanged.AddListener(HandleCellNameChanged);
    }

    public void UnsubscribeFromEvents()
    {
        Model.EventCellDescriptionChanged.RemoveListener(HandleCellDescriptionChanged);
        Model.EventCellIconChanged.RemoveListener(HandleCellIconChanged);
        Model.EventCellNameChanged.RemoveListener(HandleCellNameChanged);
    }

    #endregion
    #region Event Handlers

    public void HandleCellDescriptionChanged()
    {

    }

    public void HandleCellIconChanged()
    {

    }

    public void HandleCellNameChanged()
    {

    }

    #endregion
    #region Methods
    public void Initialise()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
