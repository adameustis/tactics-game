using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypeManagerSO", menuName = "ScriptableObjects/Manager/TypeManagerSO")]
[System.Serializable]
public class TypeManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private TypeSO cell;
    [SerializeField] private TypeSO unit;

    #endregion
    #region Properties

    public TypeSO Cell { get => cell; private set => cell = value; }
    public TypeSO Unit { get => unit; private set => unit = value; }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void OnAfterDeserialize()
    {

    }

    public void OnBeforeSerialize()
    {

    }

    public void OnEnable() { }

    #endregion
}
