using System.Collections.Generic;
using MVC.Cell;
using UnityEngine;

namespace ScriptableObjects.UnitSO
{
    [CreateAssetMenu(fileName = "UnitSO", menuName = "ScriptableObjects/UnitSO")]
    public class UnitSO : ScriptableObject
    {
        #region Fields
        [field: Header("Fields")]
        [SerializeField] private string unitName;
        [SerializeField] private Sprite icon;
        [SerializeField] private int maxHP;
        [SerializeField] private List<AbilityModel> abilities;
        [SerializeField] private List<StatusModel> statuses;
        [SerializeField] private bool canLandTraverse;
        [SerializeField] private bool canAirTraverse;
        [SerializeField] private bool canStopOnLand;
        [SerializeField] private bool canStopInAir;

        #endregion
        #region Events
        #endregion
        #region Properties

        public string UnitName => unitName;
        public Sprite Icon => icon;
        public int MaxHp => maxHP;
        public List<AbilityModel> Abilities => abilities;
        public List<StatusModel> Statuses => statuses;
        public bool CanLandTraverse => canLandTraverse;
        public bool CanAirTraverse => canAirTraverse;
        public bool CanStopOnLand => canStopOnLand;
        public bool CanStopInAir => canStopInAir;

        #endregion
    }
}