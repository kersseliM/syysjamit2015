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

    public float MassOfThItem = 1;


    void Awake()
    {
        Instanse = this;

        Fire = Resources.Load("FireComplex 1") as GameObject;
    }


        

    void Update()
    {
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
        print(temperature / 40);

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
