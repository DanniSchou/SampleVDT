namespace Foxes.Game.Themes.Models
{
    using System;
    using Core;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class DiceSkinModel
    {
        [Inject] protected DiceSkinCollection DiceSkins;
        
        public event Action<DiceSkinModel> DiceSkinChanged;
        
        private int _diceSkinIndex = -1;
        private DiceSkin _currentSkin;
        
        public DiceSkin DiceSkin => _currentSkin;

        public int DiceSkinIndex => _diceSkinIndex;

        public void CycleSkin()
        {
            _diceSkinIndex = (_diceSkinIndex + 1) % DiceSkins.Count;
            _currentSkin = DiceSkins.GetDiceSkin(_diceSkinIndex);
            DiceSkinChanged?.Invoke(this);
        }
    }
}