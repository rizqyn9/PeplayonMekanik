using UnityEngine;
using Mirror;
using UnityEngine.Playables;

namespace Peplayon
{
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager

    {
        public static bool haha;

        public NetworkIdentity[] _item = null;

        public Transform[] PointSpawnItem;

        public Transform[] spawnplayer;

        public Transform ItemParent;

        #region NetworkBehavoiur

        public override void OnStartServer()
        {
            base.OnStartServer();
            SpawnItem.Spawnitemrandom();
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            GameObject player = Instantiate(playerPrefab, spawnplayer[numPlayers].position, spawnplayer[numPlayers].rotation);

            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        }

        private void Update()
        {
            if (NetworkServer.connections.Count >= 2
                )
            {
                StartGame();
            }

            if (haha)
            {
                Playable();
            }
            /* if (!haha)
             {
                 notPlayable();
             }*/
        }

        #endregion NetworkBehavoiur

        #region Game Settingsss

        public void StartGame()
        {
            if (NetworkServer.connections.Count >= 2)
            {
                Debug.Log("gaga");
                UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();

                ui.startCutcsene();
            }
            else
            {
            }
        }

        public void Playable()
        {
            UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
            ui.CMDsetPlayable();
            Debug.Log("playable");
        }

        public void notPlayable()
        {
            UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
            ui.CMDsetnonPlayable();
        }

        #endregion Game Settingsss
    }
}