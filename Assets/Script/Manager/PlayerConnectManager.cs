using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        player.gameObject.GetComponent<Renderer>().material = playerMaterials[NetworkServer.connections.Count-1];
        
        
        
        Debug.Log("Player connected" + conn.identity);
    }
}
