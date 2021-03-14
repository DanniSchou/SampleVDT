namespace Foxes.Game.Presets.Presenters
{
    using Core;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class PresetGroupPresenter : InjectedBehaviour
    {
        [SerializeField]
        protected TMP_Text nameText;
        
        [SerializeField]
        protected RectTransform content;

        protected RectTransform LayoutTransform;
        
        private bool _showPresets = true;
        private bool _rebuild;

        public RectTransform Content => content;

        protected override void Awake()
        {
            base.Awake();

            LayoutTransform = (RectTransform) content.parent;
        }

        protected void LateUpdate()
        {
            if (_rebuild)
            {
                RebuildLayout();
            }
        }

        public void SetName(string value)
        {
            nameText.text = value;
        }

        public void ToggleGroup()
        {
            _showPresets = !_showPresets;

            var first = true;
            foreach (Transform child in content)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                
                child.gameObject.SetActive(_showPresets);
            }

            _rebuild = true;
        }

        private void RebuildLayout()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(LayoutTransform);
        }
    }
}
