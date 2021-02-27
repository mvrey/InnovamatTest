using mvreylib.features.messenger;
using System;
using System.Collections;
using TMPro;

namespace innovamattest.componentviews
{
    public class ScoreComponentView : ComponentView, IMessageSubscriber
    {
        public TextMeshProUGUI sucessText;
        public TextMeshProUGUI failText;

        private void Awake()
        {
            AddMessageListeners();
        }

        public void AddMessageListeners()
        {
            Func<ArrayList, bool> OnSetScoreSuccessDelegate = OnSetScoreSuccess;
            Messenger.AddListener(MessageEnum.SetScoreSuccess, OnSetScoreSuccessDelegate);

            Func<ArrayList, bool> OnSetScoreFailDelegate = OnSetScoreFail;
            Messenger.AddListener(MessageEnum.SetScoreFail, OnSetScoreFailDelegate);
        }

        public void RemoveMessageListeners()
        {

        }

        private bool OnSetScoreSuccess(ArrayList data)
        {
            int score = (int)data[0];
            sucessText.text = score.ToString();
            return true;
        }

        private bool OnSetScoreFail(ArrayList data)
        {
            int score = (int)data[0];
            failText.text = score.ToString();
            return true;
        }
    }
}
