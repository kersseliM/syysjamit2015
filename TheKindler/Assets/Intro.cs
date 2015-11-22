using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    AudioSource audioSource;
    Camera introGamm;
    public Camera mainCam;
    Animator anim;
   public GameObject musicBox;
 public  AudioListener ad;
 public  AudioListener mainAd;
 public Text IntroText;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        introGamm = GetComponent<Camera>();
       // Global.Instanse.Mover.enabled = false;
        Invoke("a0", 5);
        ad.enabled = true;
        mainAd.enabled = false;
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            a0();
            a1();
        }
        }

    void a0()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke("d", 2.1f);
        Invoke("a1", 10);
    }


    void d()
    {

        IntroText.enabled = true;
    }
    void a1()
    {
        audioSource.Stop();
        IntroText.enabled = false;
        anim.enabled = true;
        musicBox.SetActive(true);
     //   gameObject.SetActive(false);
        ad.enabled = false;
        mainAd.enabled = true;
    }

    public void SwitchCameras()
    {
        introGamm.enabled = false;
        mainCam.enabled = true;
        anim.enabled = false;
        this.enabled = false;
    }
    // Update is called once per frame

}
