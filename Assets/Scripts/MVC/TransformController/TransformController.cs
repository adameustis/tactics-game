using UnityEngine;

namespace MVC.Miscellaneous
{
    public class TransformController : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] protected Transform theTransform;

        #endregion
        #region Properties

        public Transform TheTransform { get => theTransform; protected set => theTransform = value; }

        #endregion
        #region Methods

        public void SetTransformPosition(Vector3 setPosition) => TheTransform.position = setPosition;

        #endregion
    }
}