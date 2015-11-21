using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{

    Camera introGamm;
    public Camera mainCam;
    // Use this for initialization
    void Start()
    {
        introGamm = GetComponent<Camera>();
       // Global.Instanse.Mover.enabled = false;
        
    }

    public void SwitchCameras()
    {
        introGamm.enabled = false;
        mainCam.enabled = true;
      
    }
    // Update is called once per frame
    void Update()
    {

    }
}
