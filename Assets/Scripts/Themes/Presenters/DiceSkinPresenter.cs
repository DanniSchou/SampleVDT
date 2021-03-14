namespace Foxes.Game.Themes.Presenters
{
    using Core;
    using Models;
    using Rolls;
    using UnityEngine;

    [RequireComponent(typeof(Renderer))]
    public class DiceSkinPresenter : InjectedBehaviour
    {
        [Inject] protected DiceSkinModel DiceSkinModel;

        [SerializeField] public DiceType dice;
        
        private Renderer _renderer;
        
        protected override void Awake()
        {
            base.Awake();

            _renderer = GetComponent<Renderer>();
        }
        
        protected override void Start()
        {
            base.Start();
            
            DiceSkinModel.DiceSkinChanged += OnDiceSkinChanged;
            
            if (DiceSkinModel.DiceSkin != null)
            {
                OnDiceSkinChanged(DiceSkinModel);
            }
        }
        
        protected void OnDestroy()
        {
            DiceSkinModel.DiceSkinChanged -= OnDiceSkinChanged;
        }

        private void OnDiceSkinChanged(DiceSkinModel model)
        {
            var material = model.DiceSkin.GetDiceMaterial(dice);
            _renderer.sharedMaterial = material;
        }
    }
}