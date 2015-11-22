using UnityEngine;
using System.Collections;

public class MainCamere : MonoBehaviour {


    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
