using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Global : MonoBehaviour
{
  public  GameObject Fire;

  public LayerMask burningMask;
    public static Global Instanse;
    public List<ParticleSystemMultiplier> fires = new List<ParticleSystemMultiplier>();
    public float temperature;
    public Slider slider;
    public Material burnedTexture;
    public RigidbodyFirstPersonController Mover;
    public AudioSource musicBox;
    public float MassOfThItem = 1;
    public float TimeToFreezeDeaht=60;

   public bool FIREISOUT;
    public AudioSource hyperventio;
    public float TimeToWin =  5000;
    float timer;
    bool voititPelin;

    void Awake()
    {
        Instanse = this;

        Fire = Resources.Load("FireComplex 1") as GameObject;
    }


        

    void Update()
    {

        if (voititPelin == true)
            return;

        timer += Time.deltaTime;


        if(timer > TimeToWin)
        {
            print("VoititPelin");
            voititPelin = true;

        }
   //     Mover.movementSettings.CurrentTargetSpeed *= MassOfThItem;//
    //    Mover.movementSettings.CurrentTargetSpeed = 20;

        
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        float temp = 0;
        foreach (ParticleSystemMultiplier psm in fires)
        {
            temp += psm.multiplier;
        }

        temperature = temp;

        if (temperature > 40)
            temperature = 40;

        slider.value = Mathf.Lerp(slider.value, temperature, Time.deltaTime * 5);


        float targetPitch = 1;



        if (temperature >= 39)
        {
           targetPitch = 2.5f;
        }

        if (temperature > 1 && temperature < 25)
            musicBox.pitch = 1;

        if (temperature >= 25)
        {
           targetPitch = 1.6f;
        }

        if(temperature <= 0)
        {
           targetPitch = 0.3f;
        }

        musicBox.pitch = Mathf.Lerp(musicBox.pitch, targetPitch, Time.deltaTime * 5);


        if(temperature <=0)
        {
            if (!FIREISOUT)
                FIREISOUTAAA();

            TimeToFreezeDeaht = TimeToFreezeDeaht - Time.deltaTime;

            if(TimeToFreezeDeaht <= 0) 
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            if(FIREISOUT)
            {
                TaasWarm();

            }

        }

    }

    void FIREISOUTAAA()
    {
        FIREISOUT = true;
        hyperventio.Play();
    }

    void TaasWarm()
    {
        FIREISOUT = false;
        hyperventio.Stop();


    }
  public  void MakeFire(GameObject item)
    {
        Vector3 pos = item.transform.position;
        float multiplier = item.GetComponent<Item>().burnValue;
        GameObject g = (GameObject)Instantiate(Global.Instanse.Fire, pos, Quaternion.identity);
        g.GetComponent<ParticleSystemMultiplier>().multiplier = multiplier;
        g.GetComponent<ParticleSystemDestroyer>().duration = item.GetComponent<Item>().duration;
        g.GetComponent<AudioSource>().maxDistance = 1 + multiplier;
        g.GetComponent<AudioSource>().volume = 0.5f + (multiplier / 10);
        item.GetComponent<Item>().StartLerp();
        item.gameObject.layer = burningMask;
        g.transform.parent = item.transform;
        item.GetComponent<Item>().IsBurning = true;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
