using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerSelectGame : MonoBehaviour
{
    public static InputManagerSelectGame instance;
    public List<GameObject> listCursorSelect;
    public List<GameObject> listCaseSelect;

    public GameObject canvas;

    private int index;
    private bool isCowlDown;
    
    public TMP_InputField  ipZone;
    public TMP_InputField playerName;

    private void Awake()
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

    void Start()
    {
        ipZone.text = "localhost";
        ipZone.onValueChanged.AddListener(UpdateTextFromInput);
        playerName.onValueChanged.AddListener(UpdateTextPlayerName);
    }

    void UpdateTextFromInput(string text)
    {
        ipZone.text = text;
    }

    public void UpdateTextPlayerName(string text)
    {
        playerName.text = text;
    }
    void Update()
    {
        if (Input.GetButtonDown("Button A"))
        {
            Debug.Log("Button A");
            PressA();
        }
        if (Input.GetAxis("Vertical") < 0 && !isCowlDown)
        {
            listCursorSelect[index].SetActive(false);
            index++;
            if (index >= listCursorSelect.Count)
            {
                index = listCursorSelect.Count - 1;
            }
            listCursorSelect[index].SetActive(true);
            StartCoroutine(JoyStick());
        }
        if (Input.GetAxis("Vertical") > 0 && !isCowlDown)
        {
            listCursorSelect[index].SetActive(false);
            index--;
            if (index <= 0)
            {
                index = 0;
            }
            listCursorSelect[index].SetActive(true);
        }


    }
    

    IEnumerator JoyStick()
    {
        isCowlDown = true;
        yield return new WaitForSeconds(0.3f);
        isCowlDown = false;
    }

    void PressA()
    {
        if (index == 0)
        {
            NetworkManager.singleton.StartHost();
        }
        else if (index == 1)

        {
            NetworkManager.singleton.networkAddress = ipZone.text;
            NetworkManager.singleton.StartClient();
 
        }
    }

    public string GetPlayerName()
    {
        return string.IsNullOrEmpty(playerName.text) ? null: playerName.text;
    }
}
