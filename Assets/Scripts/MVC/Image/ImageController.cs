using UnityEngine;

namespace MVC.Image
{
    public class ImageController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public UnityEngine.UI.Image ImageComponent { get; private set; }
    
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