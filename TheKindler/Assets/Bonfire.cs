using UnityEngine;
using System.Collections;
using UnityStandardAssets.Effects;
public class Bonfire : MonoBehaviour {

    public GameObject Fire;
    public LayerMask burningMask;
	// Use this for initialization
	void Start ()
    {
	
       
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
        }
    }


    void MakeFire(GameObject item)
    {
        Vector3 pos = item.transform.position;
        float multiplier = item.GetComponent<Item>().burnValue;
        GameObject g = (GameObject)Instantiate(Fire, pos, Quaternion.identity);
        g.GetComponent<ParticleSystemMultiplier>().multiplier = multiplier;
        item.gameObject.layer = burningMask;
        g.transform.parent = item.transform;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
