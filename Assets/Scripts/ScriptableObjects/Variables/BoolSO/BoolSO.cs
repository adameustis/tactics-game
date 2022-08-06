using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolSO", menuName = "ScriptableObjects/Variables/BoolSO")]
[System.Serializable] public class BoolSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields
    [SerializeField] private bool initialValue;
    [SerializeField] private bool runTimeValue;
    #endregion
    #region Properties
    public bool RunTimeValue
    {
        get
        {
            return runTimeValue;
        }

        set
        {
            runTimeValue = value;
        }
    }


    #endregion

    #region Methods
    public void OnAfterDeserialize()
    {
        RunTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnEnable() { }
    #endregion
}
