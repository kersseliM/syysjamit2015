using UnityEngine;
using System.Collections;
using UnityStandardAssets.Effects;
public class Bonfire : MonoBehaviour {

     GameObject Fire;
    public LayerMask burningMask;
	// Use this for initialization
	void Start ()
    {
  
        Fire = Resources.Load("FireComplex 1") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
	


        


        
	}


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Item")
        {
            MakeFire(col.gameObject);
            col.gameObject.tag = "Used";
        }
    }


    void MakeFire(GameObject item)
    {
        Vector3 pos = item.transform.position;
        float multiplier = item.GetComponent<Item>().burnValue;
        GameObject g = (GameObject)Instantiate(Fire, pos, Quaternion.identity);
        g.GetComponent<ParticleSystemMultiplier>().multiplier = multiplier;
        g.GetComponent<ParticleSystemDestroyer>().duration = item.GetComponent<Item>().duration;
        g.GetComponent<AudioSource>().maxDistance = 1 + multiplier;
        g.GetComponent<AudioSource>().volume = 0.5f + (multiplier/10);
        item.GetComponent<Item>().StartLerp() ;
        item.gameObject.layer = burningMask;
        g.transform.parent = item.transform;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
