using UnityEngine;

namespace MVC.Miscellaneous
{
    public class DontDestroyOnSceneChange : MonoBehaviour
    {
        #region Event Properties
        [field: Header("Triggers")]
        [field: SerializeField] public GameObject TheGameObject { get; protected set; }

        #endregion
        #region Monobehaviour
        #endregion
        #region Methods

        public void DontDestroyGameObjectOnLoad()
        {
            DontDestroyOnLoad(TheGameObject);
        }
        #endregion
    }
}