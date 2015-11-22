using UnityEngine;
using System.Collections;

public class MainCamere : MonoBehaviour {

    public AudioClip mumnreisd;
    AudioSource s;


    void Start()
    {

        s = GetComponent<AudioSource>();

    }

    public void Win()
    {
       s.clip = mumnreisd;
      
       s.enabled = true;
       s.Play();
    }

    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
