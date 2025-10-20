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

    private bool isReady;
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

    void Update()
    {
        if (Input.GetButtonDown("Button X"))
        {
            isReady = true;
            Debug.Log("Button X");
            PressX();
        }
    }
    

    public void TextUpdate()
    {
        numberconnect.text = "En ligne:" + numberReady.ToString() + "/" + NumbrePlayerConnect.instance.numbre;
    }
    void OnNumberChanged(int oldValue, int newValue)
    {
        TextUpdate();
    }

    [Server]
    void PressX()
    {
        if (!isReady)
        {
            numberReady++;
        }
    }


}
