using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class StartGameManager : NetworkBehaviour
{
    public static StartGameManager instance;
    [SyncVar(hook = nameof(OnNumberChanged))]
    public int numberReady;
    public TMP_Text numberconnect;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public override void OnStartServer()
    {
        base.OnStartServer();
        numberReady = 0;

    }

    [Server]
    public void AddReady()
    {
        numberReady++;
    }
    

    
    
    public void TextUpdate()
    {
        numberconnect.text = "En ligne:" + numberReady.ToString() + "/" + NumbrePlayerConnect.instance.numbre + "prêts";
    }
    
    void OnNumberChanged(int oldValue, int newValue)
    {
        TextUpdate();
    }
    

}
