using UnityEngine;

namespace MVC.Image
{
    public class ImageController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] protected UnityEngine.UI.Image imageComponent;
        #endregion
        #region Events
        #endregion
        #region Properties

        public UnityEngine.UI.Image ImageComponent { get => imageComponent; protected set => imageComponent = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Monobehaviour
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void SetSprite(Sprite newSprite) => ImageComponent.sprite = newSprite;
        public void ClearSprite() => ImageComponent.sprite = null;

        #endregion
    }
}