namespace Foxes.Game.Network
{
    using System;
    using JetBrains.Annotations;
    using UnityEngine;

    [UsedImplicitly]
    public class PlayerModel
    {
        public event Action<PlayerModel> NameChanged;
        public event Action<PlayerModel> ColorChanged;
        
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (Equals(_name, value)) return;
                _name = value;
                NameChanged?.Invoke(this);
            }
        }

        private Color _color;

        public Color Color
        {
            get => _color;
            set
            {
                if (Equals(_color, value)) return;
                _color = value;
                ColorChanged?.Invoke(this); 
            }
        }
    }
}