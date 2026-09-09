using Game.Pause;

namespace Game.UI
{
    public class UIPausePanel : UIMainPanel
    {
        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            PauseEvents.RaiseContinueClicked();
        }
    }
}

