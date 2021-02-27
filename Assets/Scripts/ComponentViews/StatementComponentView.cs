using mvreylib.features.messenger;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace innovamattest.componentviews
{
    public class StatementComponentView : FadeableComponentView, IMessageSubscriber
    {
        public TextMeshProUGUI title;


        private void Awake()
        {
            AddMessageListeners();
        }

        public void AddMessageListeners()
        {
            Func<ArrayList, bool> OnSetStatementTextDelegate = OnSetStatementText;
            Messenger.AddListener(MessageEnum.SetStatementText, OnSetStatementTextDelegate);

            Func<bool> OnShowStatementDelegate = OnShowStatement;
            Messenger.AddListener(MessageEnum.ShowStatement, OnShowStatementDelegate);
        }

        public void RemoveMessageListeners()
        {

        }

        private bool OnSetStatementText(ArrayList data)
        {
            title.text = data[0] as string;
            return true;
        }

        private bool OnShowStatement()
        {
            StartCoroutine("ShowStatementCoroutine");
            return true;
        }

        private IEnumerator ShowStatementCoroutine()
        {
            FadeIn(2.0f);

            yield return new WaitForSeconds(4.0f);

            FadeOut(2.0f);

            yield return new WaitForSeconds(2.0f);

            Messenger.SendMessage(MessageEnum.ShowAnswers);
        }
    }
}
