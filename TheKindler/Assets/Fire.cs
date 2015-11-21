using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    GameObject bonfire;
    // Use this for initialization
    void Start()
    {
        bonfire = transform.FindChild("BonFire").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        Invoke("e", 2);

    }

    void e()
    {
        Global.Instanse.fires.Add(GetComponent<ParticleSystemMultiplier>());

    }
    void OnDisable()
    {
        Global.Instanse.fires.Remove(GetComponent<ParticleSystemMultiplier>());
        bonfire.SetActive(false);
    }

}
