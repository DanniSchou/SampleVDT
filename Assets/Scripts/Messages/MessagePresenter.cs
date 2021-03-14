namespace Foxes.Game.Messages
{
    using System.Collections;
    using Core;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class MessagePresenter : InjectedBehaviour
    {
        [Inject] protected MessageSettings Settings;
        [Inject] protected MessageListModel ListModel;
        
        public TMP_Text Text;

        private Image _image;
        private Coroutine _transition;
        private Coroutine _timeout;

        private MessageModel _model;

        protected override void Awake()
        {
            base.Awake();
            
            _image = GetComponent<Image>();
        }

        protected override void Start()
        {
            base.Start();

            ListModel.ShowMessagesChanged += OnShowMessagesChanged;

            if (_model != null)
            {
                UpdateVisibility();
            }
        }

        protected void OnDestroy()
        {
            ListModel.ShowMessagesChanged -= OnShowMessagesChanged;
        }

        public void SetModel(MessageModel value)
        {
            _model = value;
            Text.text = _model.Text;
            _image.color = value.Color;

            if (Settings != null)
            {
                UpdateVisibility();
            }
        }

        private void UpdateVisibility()
        {
            StopTimeout();
            StopTransition();

            var timePassedSinceCreation = Time.realtimeSinceStartup - _model.TimeCreated;
            var timeLeft = Settings.Lifetime - timePassedSinceCreation;
            
            if (timeLeft > 0f)
            {
                SetAlpha(1f);
                _timeout = StartCoroutine(DelayHide(timeLeft));
            }
            else
            {
                _transition = StartCoroutine(ListModel.ShowMessages ? FadeIn() : FadeOut());
            }
            
        }

        private void OnShowMessagesChanged(MessageListModel model)
        {
            UpdateVisibility();
        }

        private void StopTimeout()
        {
            if (_timeout == null) return;
            StopCoroutine(_timeout);
            _timeout = null;
        }

        private void StopTransition()
        {
            if (_transition == null) return;
            StopCoroutine(_transition);
            _transition = null;
        }

        private void SetAlpha(float value)
        {
            var imageColor = _image.color;
            imageColor.a = value;
            _image.color = imageColor;
            
            var textColor = Text.color;
            textColor.a = value;
            Text.color = textColor;
        }

        private IEnumerator DelayHide(float value)
        {
            yield return new WaitForSeconds(value);
            UpdateVisibility();
        }

        private IEnumerator FadeIn()
        {
            var alpha = _image.color.a;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime / Settings.TransitionSpeed;
                SetAlpha(alpha);
                yield return null;
            }
            
            SetAlpha(1f);
        }

        private IEnumerator FadeOut()
        {
            var alpha = _image.color.a;
            while (alpha > 0f)
            {
                alpha -= Time.deltaTime / Settings.TransitionSpeed;
                SetAlpha(alpha);
                yield return null;
            }
            
            SetAlpha(0f);
        }
    }
}