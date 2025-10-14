using System;
using Mirror;
using UnityEngine;

namespace Script.Manager
{
    public class PlayerConnectManager : NetworkManager
    {
        [Header("")]
        [Header("PlayerConnectManager")]
        public Material[] playerMaterials;
        private bool isSpawn;
    

        [Obsolete("Obsolete")]
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);
        
            Transform spawnPoint = PlayerSpawn.instance.spawnPoints[NetworkServer.connections.Count-1];
            GameObject player = conn.identity.gameObject;
        
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;

            int matIndex = NetworkServer.connections.Count - 1;
        
            var playerMatSync = player.gameObject.GetComponent<PlayerMaterialSync>();
            if (playerMatSync != null)
            {
                playerMatSync.SetMaterialIndex(matIndex);
            }
        
        
            Debug.Log("Player connected" + NetworkServer.connections.Count);
        }
    }
}
