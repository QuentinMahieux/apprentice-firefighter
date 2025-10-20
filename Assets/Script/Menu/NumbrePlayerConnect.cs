using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class NumbrePlayerConnect : NetworkBehaviour
{
    public static NumbrePlayerConnect instance;
    [SyncVar(hook = nameof(OnNumberChanged))]
    public int numbre;
    public TMP_Text numbreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        numbre = 0;

    }

    [Server]
    public void AddPlayer()
    {
        numbre++;
    }
    [Server]
    public void RemovePlayer()
    {
        numbre--;
    }

    void TextUpdate()
    {
        numbreText.text = "En ligne:" + numbre.ToString() + "/6";
    }
    void OnNumberChanged(int oldValue, int newValue)
    {
        TextUpdate();
        StartGameManager.instance.TextUpdate();
    }
}
