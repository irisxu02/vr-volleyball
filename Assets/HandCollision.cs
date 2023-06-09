using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.InputSystem;

public class HandCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource s;
    private Rigidbody rb;
    public bool CollisionFlag = false;
    public float SpeedupFactor = 1.2f;
    private XRNode controllerL = XRNode.LeftHand;
    private XRNode controllerR = XRNode.RightHand;
    private Vector3 velocity;
    private Bounds oppCourtBounds;
    private Bounds playerCourtBounds;
    public float movementSpeed = 10f;
    public float maxLandingDistance = 5f;
    public GameObject opponentSidePlane;
    public GameObject playerSidePlane;

    void Start()
    {
        s = GameObject.Find("BounceSound").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        opponentSidePlane = GameObject.Find("OpponentSide");
        playerSidePlane = GameObject.Find("PlayerSide");
        Renderer oppPlaneRenderer = opponentSidePlane.transform.GetComponent<Renderer>();
        oppCourtBounds = oppPlaneRenderer.bounds;
        Debug.Log(oppCourtBounds);
        Renderer playerPlaneRenderer = playerSidePlane.transform.GetComponent<Renderer>();
        playerCourtBounds = playerPlaneRenderer.bounds;
        Debug.Log(playerCourtBounds);
        //controllerL = InputDevices.GetDeviceAtXRNode(XRNode.leftHand);
        //controllerR = InputDevices.GetDeviceAtXRNode(XRNode.rightHand);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider hands){
        s.PlayOneShot(s.clip);
        if (hands.gameObject.CompareTag("Hand"))
        {
            //CollisionFlag = true;
            //Vector3 Normal = transform.position-hands.transform.position;
            //rb.velocity = Vector3.Reflect(rb.velocity,hands.transform.up.normalized) * SpeedupFactor;
            //rb.velocity = rb.velocity.magnitude * velocity * SpeedupFactor;
            Vector3 ballvelocity;
            if (rb.velocity.y < 0) ballvelocity.y = -rb.velocity.y;
            else ballvelocity.y = rb.velocity.y;
            // Randomize the distance within the maximum range
            Vector3 oppPosition = new Vector3(0,0,9);
            Vector3 randomizedHitPosition = oppPosition + Random.insideUnitSphere * maxLandingDistance;
            Debug.Log(randomizedHitPosition);
            if (randomizedHitPosition.z>5 && randomizedHitPosition.z<15 && randomizedHitPosition.x<5 && randomizedHitPosition.x>-5)
            {
                Debug.Log("True");
                Vector3 ballDirection = (randomizedHitPosition - transform.position).normalized;
                ballvelocity.x = ballDirection.x * movementSpeed;
                ballvelocity.z = ballDirection.z * movementSpeed;
                rb.velocity = ballvelocity;
            }
            else
            {
                Debug.Log("False");
                // Randomize a new hit position within the player side bounds
                Vector3 validHitPosition = oppCourtBounds.ClosestPoint(transform.position);
                Vector3 ballDirection = (validHitPosition - transform.position).normalized;
                ballvelocity.x = ballDirection.x * movementSpeed;
                ballvelocity.z = ballDirection.z * movementSpeed;
                rb.velocity = ballvelocity;
            }
        }
    }


    void Update()
    {
/*         InputDevice targetDeviceL = InputDevices.GetDeviceAtXRNode(controllerL);
        InputDevice targetDeviceR = InputDevices.GetDeviceAtXRNode(controllerR);
        if(targetDeviceL.TryGetFeatureValue(CommonUsages.velocity, out Vector3 velocityL) && targetDeviceR.TryGetFeatureValue(CommonUsages.velocity, out Vector3 velocityR))
        {
            if(controllerL.velocity.magnitude < controllerR.velocity.magnitude){
                velocity = controllerR.velocity;
            }else{
                velocity = controllerL.velocity;
            }
        } */
    }
}
