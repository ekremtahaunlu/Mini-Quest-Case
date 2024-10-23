using Photon.Pun;
using Photon.Realtime;

namespace Managers
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }
    
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };
            PhotonNetwork.CreateRoom("Oda Adı", roomOptions);
        }
    }
}
