﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel
{
    #region Fields

    [SerializeField] private int intPlayerNumber;
    [SerializeField] private string strPlayerName;
    [SerializeField] private Sprite playerIcon;
    [SerializeField] private TeamModel team;

    #endregion
    #region Events
    #endregion
    #region Properties

    public int IntPlayerNumber { get => intPlayerNumber; set => intPlayerNumber = value; }
    public string StrPlayerName { get => strPlayerName; set => strPlayerName = value; }
    public Sprite PlayerIcon { get => playerIcon; set => playerIcon = value; }
    public TeamModel Team { get => team; set => team = value; }


    #endregion
    #region Event Properties
    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods
    #endregion
}
