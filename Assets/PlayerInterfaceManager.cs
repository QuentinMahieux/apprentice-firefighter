using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInterfaceManager : NetworkBehaviour
{
    public bool isReady;
    void Update()
    {
        if (Input.GetButtonDown("Button X") && !isReady)
        {
            PressXToStartingGame();
            isReady = true;
        }
    }
    
    
    [Command]
    void PressXToStartingGame()
    {
        StartGameManager.instance.AddReady();
    }
}
