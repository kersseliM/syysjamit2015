using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public static Global Instanse;
    public List<ParticleSystemMultiplier> fires = new List<ParticleSystemMultiplier>();
    public float temperature;
    public Slider slider;

    void Awake()
    {
        Instanse = this;
    }

    void Update()
    {


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
        slider.value = Mathf.Lerp(slider.value, temperature, Time.deltaTime * 5);
    }
}
