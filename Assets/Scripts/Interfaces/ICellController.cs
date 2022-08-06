using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellController
{
    #region Event Subscriptions

    void SubscribeToEvents();
    void UnsubscribeFromEvents();

    #endregion
    #region Event Handlers

    void HandleCellNameChanged();
    void HandleCellIconChanged();
    void HandleCellGridPositionXChanged();
    void HandleCellGridPositionYChanged();
    void HandleCellIsLandTraversableChanged();
    void HandleCellIsAirTraversableChanged();
    void HandleCellIsLandDestinationChanged();
    void HandleCellIsAirDestinationChanged();
    void HandleCellHasResidentUnitChanged();
    void HandleCellResidentUnitChanged();
    void HandleCellAdjacentCellAdded(CellBattleDisplayController cell);
    void HandleCellAdjacentCellRemoved(CellBattleDisplayController cell);

    #endregion
}
