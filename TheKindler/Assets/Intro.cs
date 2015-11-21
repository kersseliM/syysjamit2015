using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
    AudioSource audioSource;
    Camera introGamm;
    public Camera mainCam;
    Animator anim;
   public GameObject musicBox;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        introGamm = GetComponent<Camera>();
       // Global.Instanse.Mover.enabled = false;
        Invoke("a0", 5);
       
    }

    void a0()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke("a1", 10);

    }

    void a1()
    {
        audioSource.Stop();
        anim.enabled = true;
        musicBox.SetActive(true);
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
