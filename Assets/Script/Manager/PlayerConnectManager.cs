using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerConnectManager : NetworkManager
{
    [Header("")]
    [Header("PlayerConnectManager")]
    public Transform[] spawnPoints;
    public Material[] playerMaterials;
    
    [Obsolete("Obsolete")]
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Transform spawnPoint = spawnPoints[NetworkServer.connections.Count-1];
        GameObject player = conn.identity.gameObject;
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        
        player.gameObject.GetComponent<Renderer>().material = playerMaterials[NetworkServer.connections.Count-1];
        
        
        
        Debug.Log("Player connected" + conn.identity);
    }
}
