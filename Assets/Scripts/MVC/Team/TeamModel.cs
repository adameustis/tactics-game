using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamModel
{
    #region Fields

    [SerializeField] private int intTeamNumber;
    [SerializeField] private string strTeamName;
    [SerializeField] private Sprite teamIcon;

    #endregion
    #region Events
    #endregion
    #region Properties

    public int IntPlayerNumber { get => intTeamNumber; set => intTeamNumber = value; }
    public string StrPlayerName { get => strTeamName; set => strTeamName = value; }
    public Sprite PlayerIcon { get => teamIcon; set => teamIcon = value; }


    #endregion
    #region Event Properties
    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods
    #endregion
}
