using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public float burnValue;
    public float duration;
    bool isLerp;
    float timer = 0;
    public bool IsBurning;
    Vector3 startScale;
    Renderer myMat;

    public bool OnkoKaverit;
    public void checkIfKaverit()
    {
        if (OnkoKaverit == true)
            EnableKaverit();
    }
    void Start()
    {
        startScale = transform.localScale;
        myMat = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isLerp)
        {
            timer += Time.deltaTime;
            float percentage = timer / duration;
            transform.localScale = Vector3.Lerp(startScale, Vector3.one * 0.4f, percentage);

            if (percentage >= 1)
            {
                if(myMat != null)
                myMat.material = Global.Instanse.burnedTexture;
            }
        }
    }


    public void StartLerp()
    {
        isLerp = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (IsBurning)
        {
            if (col.gameObject.tag == "Item")
            {
                Global.Instanse.MakeFire(col.gameObject);
                col.gameObject.tag = "Used";
            }
        }
    }


    void OnCollisionEnter(Collision col)
    {

    }
    public LayerMask burningMask;


    void EnableKaverit()
    {
        foreach (Transform t in transform.parent)
        {
            t.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
