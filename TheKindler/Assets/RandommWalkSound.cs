using UnityEngine;
using System.Collections;

public class RandommWalkSound : MonoBehaviour {

	// Use this for initialization
    public AudioClip[] walkSounds;
    public float InvokeSpeed = 1;
    AudioSource ad;
	void Start () 
    {
        ad = GetComponent<AudioSource>();
        Invoke("i", InvokeSpeed);
	}
	
    void i()
    {
        int random = Random.Range(0, walkSounds.Length);
        ad.clip = walkSounds[random];
        ad.Play();
        Invoke("i", InvokeSpeed);
    }

}
