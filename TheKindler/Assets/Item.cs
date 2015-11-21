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
            print("isburruerw");
            if (col.gameObject.tag == "Item")
            {
                print("dasasd");
             Global.Instanse.MakeFire(col.gameObject);
                col.gameObject.tag = "Used";
            }
        }
    }
    public LayerMask burningMask;


}
