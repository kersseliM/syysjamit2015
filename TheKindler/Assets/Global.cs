using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour
{
    public static Global Instanse;
    public List<ParticleSystemMultiplier> fires = new List<ParticleSystemMultiplier>();
    public float temperature;

    void Awake()
    {
        Instanse = this;
    }

    void Update()
    {

        float temp=0;
        foreach(ParticleSystemMultiplier psm in fires)
        {
            temp += psm.multiplier; 
        }
        temperature = temp;
        print(temperature);
    }
}
