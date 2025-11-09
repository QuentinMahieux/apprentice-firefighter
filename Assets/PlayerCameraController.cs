using Cinemachine;
using Mirror;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    [Header("JoyStick")]
    public float sensitivityY = 5;
    
    [Range(0, 1)] public float deadZone = 0.19f;
    
    public GameObject cameraObject;
    public CinemachineFreeLook cinemachineFreeLook;

    void Start()
    {
        cameraObject.SetActive(false);
        if (isLocalPlayer)
        {
            cameraObject.SetActive(true);
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetAxis("RT") >= 0.19f)
        {
            cinemachineFreeLook.m_YAxis.Value -=  Input.GetAxis("_Verticale") * sensitivityY *  Time.deltaTime;
        }
        
    }
    
    
    
    
}
