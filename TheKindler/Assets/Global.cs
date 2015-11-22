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
     float TimeToFreezeDeaht=100;

   public bool FIREISOUT;
    public AudioSource hyperventio;
 public   float TimeToWin =  60;
  public  float timer;
    bool voititPelin;
    public Animator MainCamAnimator;
    void Awake()
    {
        Instanse = this;

        Fire = Resources.Load("FireComplex 1") as GameObject;
    }


        

    void Update()
    {

      //  if (voititPelin == true)
        //    return;

        timer += Time.deltaTime;


       // if(timer > TimeToWin)
        //{
           
        //}
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

 
        if (temperature >= 33)
        {
           targetPitch = 1.6f;
        }

        if (temperature > 1 && temperature < 32)
            musicBox.pitch = 1;

        if(temperature <= 0)
        {
           targetPitch = 0.7f;
        }

        musicBox.pitch = Mathf.Lerp(musicBox.pitch, targetPitch, Time.deltaTime * 4);


        if(temperature <=0)
        {
            if (!FIREISOUT)
                FIREISOUTAAA();

            TimeToFreezeDeaht = TimeToFreezeDeaht - Time.deltaTime;

            if(TimeToFreezeDeaht <= 0) 
            {
                Kuolema();
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

    private void Kuolema()
    {
        MainCamAnimator.enabled = true;
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

 public void VoititPelin()
  {

      voititPelin = true;
      print("Win");
  }
}
