using UnityEngine;
using System.Collections;
using UnityStandardAssets.Effects;
public class Bonfire : MonoBehaviour {


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
         Global.Instanse.   MakeFire(col.gameObject);
            col.gameObject.tag = "Used";
        }
    }



}
