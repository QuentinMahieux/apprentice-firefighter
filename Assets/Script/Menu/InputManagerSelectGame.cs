using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerSelectGame : MonoBehaviour
{
    public List<GameObject> listCursorSelect;
    public List<GameObject> listCaseSelect;

    private int index;
    private bool isCowlDown;
    
    public string ipZone;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        
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

        if (SceneManager.GetActiveScene().name != "Main")
        {
            Destroy(gameObject);
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
            NetworkManager.singleton.networkAddress = ipZone;
            NetworkManager.singleton.StartClient();
 
        }
    }
}
