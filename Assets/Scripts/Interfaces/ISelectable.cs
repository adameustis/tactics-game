using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    #region Methods

    void Deselect();
    InstructionSO MouseOffOtherObject(IMouseOver otherObject);
    InstructionSO MouseOverOtherObject(IMouseOver otherObject);
    InstructionSO SelectOtherObject(ISelectable otherObject);

    #endregion
}
