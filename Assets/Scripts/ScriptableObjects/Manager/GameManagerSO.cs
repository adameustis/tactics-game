using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerSO", menuName = "ScriptableObjects/Manager/GameManagerSO")]
[System.Serializable] public class GameManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private AbilityManagerSO abilityManager;
    [SerializeField] private CellManagerSO cellManager;
    [SerializeField] private EffectManagerSO effectManager;
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private InstructionManagerSO instructionManager;
    [SerializeField] private MouseOverManagerSO mouseOverManager;
    [SerializeField] private SceneManagerSO sceneManager;
    [SerializeField] private SelectionManagerSO selectionManager;
    [SerializeField] private StateManagerSO stateManager;
    [SerializeField] private StatusManagerSO statusManager;
    [SerializeField] private TargetManagerSO targetManager;
    [SerializeField] private TargetingTypeManagerSO targetingTypeManager;
    [SerializeField] private TurnManagerSO turnManager;
    [SerializeField] private UnitManagerSO unitManager;

    #endregion
    #region Events
    #endregion
    #region Properties

    public AbilityManagerSO AbilityManager { get => abilityManager; set => abilityManager = value; }
    public CellManagerSO CellManager { get => cellManager; set => cellManager = value; }
    public EffectManagerSO EffectManager { get => effectManager; set => effectManager = value; }
    public EventManagerSO EventManager { get => eventManager; set => eventManager = value; }
    public InstructionManagerSO InstructionManager { get => instructionManager; set => instructionManager = value; }
    public MouseOverManagerSO MouseOverManager { get => mouseOverManager; set => mouseOverManager = value; }
    public SceneManagerSO SceneManager { get => sceneManager; set => sceneManager = value; }
    public SelectionManagerSO SelectionManager { get => selectionManager; set => selectionManager = value; }
    public StateManagerSO StateManager { get => stateManager; set => stateManager = value; }
    public StatusManagerSO StatusManager { get => statusManager; set => statusManager = value; }
    public TargetManagerSO TargetManager { get => targetManager; set => targetManager = value; }
    public TargetingTypeManagerSO TargetingTypeManager { get => targetingTypeManager; set => targetingTypeManager = value; }
    public TurnManagerSO TurnManager { get => turnManager; set => turnManager = value; }
    public UnitManagerSO UnitManager { get => unitManager; set => unitManager = value; }
    
    #endregion
    #region Event Properties
    #endregion
    #region Methods
    #endregion
}
