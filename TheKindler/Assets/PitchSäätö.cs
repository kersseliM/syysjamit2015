using UnityEngine;
using System.Collections;

public class PitchSäätö : MonoBehaviour
{
    AudioSource audiosourse;

    // Use this for initialization
    void Start()
    {
        audiosourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
            audiosourse.pitch = audiosourse.pitch + 0.25f;

        if (Input.GetKeyDown(KeyCode.B))
            audiosourse.pitch = audiosourse.pitch - 0.25f;
    }
}
