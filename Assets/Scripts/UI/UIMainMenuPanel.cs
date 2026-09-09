using UnityEngine;
using Game.SceneTransitions;
using Game.Data;

namespace Game.UI
{
    public class UIMainMenuPanel : UIMainPanel
    {
        [SerializeField] private SceneToLoadSo _gameplayScene;
        
        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            SceneTransitionEvents.RaiseSceneChangeRequested(_gameplayScene);            
        }     
      
    }
}

