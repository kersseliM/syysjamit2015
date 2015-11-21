using UnityEngine;
using System.Collections;

public class Grapper : MonoBehaviour
{
    void Start()
    {
        InitializeAim();
        InitializeHand();
    }
    // Update is called once per frame
    void Update()
    {
        AimUpdate();
        HandUpdate();
    }

    void HandUpdate()
    {
        if (isGrapped)
        {
            if (Input.GetMouseButtonUp(0))
                Toss();
        }
    }




    #region Aim
    void AimUpdate()
    {
        Ray ray = new Ray(aim.position, aim.transform.forward);
        RaycastHit rayHit;

        Debug.DrawRay(ray.origin, ray.direction * rayLenght);
        if (Physics.Raycast(ray, out rayHit, rayLenght, pickable))
        {
            if (!isAimActivated)
                ActiveAim();


            if (isAimActivated)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Grab(rayHit.collider.gameObject.GetComponent<Rigidbody>());
                }
            }
        }
        else
        {
            if (isAimActivated == true)
                DeActivateAim();
        }

    }
    private void DeActivateAim()
    {
        isAimActivated = false;
        aimRenderer.material = normiMat;
    }
    void ActiveAim()
    {
        isAimActivated = true;
        aimRenderer.material = aimActivated;
    }


    void InitializeAim()
    {
        aim = GameObject.Find("Aim").transform;
        aimRenderer = aim.GetComponent<Renderer>();
        normiMat = aimRenderer.material;
    }

    Transform aim;
    public Material aimActivated;
    public Material normiMat;
    Renderer aimRenderer;
    bool isAimActivated;
    public float rayLenght = 10;
    public LayerMask pickable;
    //end aim

#endregion
   
    #region hand
    public Vector3 TossForce;
    public float tossMultiplier;
    Rigidbody playerRigidBody;
    bool isGrapped;
    Transform hand;
    HingeJoint hj;
    void Grab(Rigidbody rb)
    {
        isGrapped = true;
        rb.MovePosition(hand.transform.position);
        rb.velocity = Vector3.zero;
        hj.connectedBody = rb;
    }
    void InitializeHand()
    {
        hand = GameObject.Find("Hand").transform;
        hj = hand.GetComponent<HingeJoint>();
        playerRigidBody = GameObject.Find("Hero").GetComponent<Rigidbody>();
    }

    private void Toss()
    {
        Rigidbody temp = hj.connectedBody;
        hj.connectedBody = null;

        float velocity = playerRigidBody.velocity.magnitude;
        velocity = velocity / 3.5f;

        if (velocity < 1)
            velocity = 1;

        temp.AddForce((hand.forward + TossForce) * tossMultiplier * velocity, ForceMode.Impulse);
        isGrapped = false;
    }

    #endregion hand
}
