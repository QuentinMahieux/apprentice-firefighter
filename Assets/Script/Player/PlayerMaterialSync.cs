using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using TMPro;
public class PlayerMaterialSync : NetworkBehaviour
{
    [Header("Material Syncro")]
    [SerializeField] private Renderer playerRenderer;
    [SerializeField] public Material[] availableMaterials;
    
    [Header("PlayerName Syncro")]
    public TMP_Text playerNameText;
    public List<string> playerNamesRandom;
    
    [SyncVar(hook = nameof(OnMaterialIndexChanged))]
    private int materialIndex;
    
    [SyncVar(hook = nameof(OnNameChanged))]
    private string playerNameSync;
    
    public void SetMaterialIndex(int index)
    {
        materialIndex = index;
        ApplyMaterial(index);
    }

    [Command]
    public void CmdSetPlayerName(string name)
    {
        playerNameSync = string.IsNullOrEmpty(name) ? playerNamesRandom[Random.Range(0, playerNamesRandom.Count)] : name;
    }

    void OnNameChanged(string oldName, string newName)
    {
        playerNameText.text = newName;
    }
        


    // Et appeler automatiquement sur tous les clients quand la SyncVar change
    void OnMaterialIndexChanged(int oldIndex, int newIndex)
    {
        ApplyMaterial(newIndex);
    }

    void ApplyMaterial(int index)
    {
        if (playerRenderer != null && index >= 0 && index < availableMaterials.Length)
        {
            playerRenderer.material = availableMaterials[index];
        }
    }

    public override void OnStartClient()
    {
        ApplyMaterial(materialIndex);
        playerNameText.text = playerNameSync;
    }
    
    //Lorsque le joeuur local se connect on envoie sont name au serveur
    public override void OnStartLocalPlayer()
    {

        string name = InputManagerSelectGame.instance.GetPlayerName();
        CmdSetPlayerName(name);

           //string name = playerNamesRandom[Random.Range(0, playerNamesRandom.Count)];
            //CmdSetPlayerName(name);

    }
}
