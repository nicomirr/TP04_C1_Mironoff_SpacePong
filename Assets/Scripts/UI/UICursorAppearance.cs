using Game.Events;
using UnityEngine;

namespace Game.UI
{
    public class UICursorAppearance : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorTexture;

        private void Awake()
        {
            UIEvents.OnChangeCursorVisibilityRequest += ChangeCursorState;
        }

        private void Start()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void OnDestroy()
        {
            UIEvents.OnChangeCursorVisibilityRequest -= ChangeCursorState;
        }

        private void ChangeCursorState(bool isVisible)
        {
            Cursor.visible = isVisible;
        }
    }

}

