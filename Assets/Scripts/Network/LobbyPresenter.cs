namespace Foxes.Game.Network
{
    using Core;
    using Events;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class LobbyPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected NetworkModel NetworkModel;
        [Inject] protected PlayerModel PlayerModel;
        
        public TMP_InputField NameInput;
        public TMP_InputField GameNameInput;
        public TMP_InputField GameSecretInput;
        public Button ColorButton;
        public Transform GamesListTransform;
        public GameObject GamesJoinButton;

        public Color[] UserColors;

        private int _colorIndex;

        protected override void Start()
        {
            base.Start();
            
            NetworkModel.RoomListChanged += OnRoomListChanged;
            NetworkModel.IsConnectedToRoomChanged += OnShowChanged;
            
            NameInput.onValueChanged.AddListener(OnNameChanged);
            
            _colorIndex = Random.Range(0, UserColors.Length);
            UpdateColor();

            OnShowChanged(NetworkModel);
        }

        protected void OnDestroy()
        {
            NetworkModel.RoomListChanged -= OnRoomListChanged;
            NetworkModel.IsConnectedToRoomChanged -= OnShowChanged;
        }

        private void OnRoomListChanged(NetworkModel model)
        {
            SetRoomList(model.RoomList);
        }

        private void OnShowChanged(NetworkModel model)
        {
            gameObject.SetActive(!model.IsConnectedToRoom);
        }

        private void OnNameChanged(string value)
        {
            PlayerModel.Name = value.Trim();
        }

        private void UpdateColor()
        {
            var currentColor = UserColors[_colorIndex];
            ColorButton.image.color = currentColor;
            PlayerModel.Color = currentColor;
        }

        public void NextColor()
        {
            _colorIndex = (_colorIndex + 1) % UserColors.Length;
            UpdateColor();
        }

        public void HostGame()
        {
            EventBus.Publish(new CreateRoomRequestedEvent(GetRoomName()));
        }
        
        private string GetRoomName()
        {
            return GameNameInput.text.Trim();
        }

        private void SetRoomList(string[] roomList)
        {
            foreach(Transform trans in GamesListTransform)
            {
                Destroy(trans.gameObject);
            }

            foreach (var room in roomList)
            {
                var roomObject = Instantiate(GamesJoinButton, GamesListTransform);
                roomObject.GetComponent<JoinButtonPresenter>().SetText(room);
            }
        }
    }
}