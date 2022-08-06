using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseController
{
    InstructionSO SelectOtherObject(BaseController<BaseModel, BaseView> otherObject);
}
