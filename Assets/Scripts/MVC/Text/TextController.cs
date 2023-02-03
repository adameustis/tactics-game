using UnityEngine;

namespace MVC.Text
{
    public class TextController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public UnityEngine.UI.Text TextComponent { get; private set; }
    
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