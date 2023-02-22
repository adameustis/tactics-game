using UnityEngine;

namespace MVC.Text
{
    public class TextController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] protected UnityEngine.UI.Text textComponent;
        #endregion
        #region Events
        #endregion
        #region Properties
        public UnityEngine.UI.Text TextComponent { get => textComponent; protected set => textComponent = value; }

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

        public void SetText(string newText) => TextComponent.text = newText;
        public void ClearText() => TextComponent.text = "";

        #endregion
    }
}