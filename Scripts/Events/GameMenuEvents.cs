using UnityEngine.Events;

namespace Events
{
    public static class GameMenuEvents
    {
        public static UnityAction PauseGameBtnUAction;
        public static UnityAction ContinueGameBtnUAction;
        public static UnityAction ReplayGameBtnUAction;
        public static UnityAction GoMainMenuBtnUAction;
        public static UnityAction<float> MusicSliderUAction;
    }
}