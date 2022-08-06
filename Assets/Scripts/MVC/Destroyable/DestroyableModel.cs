using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class DestroyableModel: MonoBehaviour
{
    #region Fields
    #endregion
    #region Events

    [SerializeField] protected UnityEvent eventMonoBehaviourStart;
    [SerializeField] protected UnityEvent eventMonoBehaviourOnDestroy;

    #endregion
    #region Properties
    #endregion
    #region Event Properties

    public virtual UnityEvent EventMonoBehaviourStart
    {
        get
        {
            if (eventMonoBehaviourStart == null)
            {
                eventMonoBehaviourStart = new UnityEvent();
            }
            return eventMonoBehaviourStart;
        }

        set
        {
            eventMonoBehaviourStart = value;
        }
    }

    public virtual UnityEvent EventMonoBehaviourOnDestroy
    {
        get
        {
            if (eventMonoBehaviourOnDestroy == null)
            {
                eventMonoBehaviourOnDestroy = new UnityEvent();
            }
            return eventMonoBehaviourOnDestroy;
        }

        set
        {
            eventMonoBehaviourOnDestroy = value;
        }
    }

    #endregion
    #region MonoBehaviour

    public virtual void Start()
    {
        EventMonoBehaviourStart?.Invoke();
    }

    public virtual void OnDestroy()
    {
        EventMonoBehaviourOnDestroy?.Invoke();
    }

    #endregion
    #region Methods
    #endregion
}
