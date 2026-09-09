using System;
using Game.Data;

namespace Game.SceneTransitions
{
    public static class SceneTransitionEvents
    {
        public static event Action<SceneToLoadSo> OnSceneChangeRequested;

        public static void RaiseSceneChangeRequested(SceneToLoadSo sceneToLoad)
        {
            OnSceneChangeRequested?.Invoke(sceneToLoad);
        }
    }
}


