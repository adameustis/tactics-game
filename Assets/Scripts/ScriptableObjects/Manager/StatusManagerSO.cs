using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusManagerSO", menuName = "ScriptableObjects/Manager/StatusManagerSO")]
public class StatusManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]

    [SerializeField] private StatusSO statusBlock;
    [SerializeField] private StatusSO statusCounter;
    [SerializeField] private StatusSO statusDefend;

    #endregion
    #region Properties

    public StatusSO StatusBlock { get => statusBlock; set => statusBlock = value; }
    public StatusSO StatusCounter { get => statusCounter; set => statusCounter = value; }
    public StatusSO StatusDefend { get => statusDefend; set => statusDefend = value; }

    #endregion
    #region Constructors
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    #endregion
}
