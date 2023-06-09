using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpponentAI : MonoBehaviour
{
    public GameObject ball;
    public XRDirectInteractor leftHand;
    public XRDirectInteractor rightHand;
    public float movementSpeed = 1.5f;
    public float maxLandingDistance = 1.2f;
    public GameObject opponentSidePlane;
    public GameObject playerSidePlane;
    private Bounds movementBounds;
    private Bounds playerCourtBounds;
    private Rigidbody rb;
    private bool towardOpp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Renderer oppPlaneRenderer = opponentSidePlane.transform.GetComponent<Renderer>();
        movementBounds = oppPlaneRenderer.bounds;
        Renderer playerPlaneRenderer = playerSidePlane.transform.GetComponent<Renderer>();
        playerCourtBounds = playerPlaneRenderer.bounds;

    }

    void Update()
    {
        // go to ball
        ball = GameObject.Find("volleyball Variant(Clone)");
        if(ball){
            if(!towardOpp && ball.transform.position.z > 4.7){ // ball going toward opponent
                towardOpp = true;
            }
            if(towardOpp && ball.transform.position.z < 5.3){ // ball going to player
                towardOpp = false;
            }
        } else {
            towardOpp = false;
        }
        if(towardOpp) { //chase after ball
            Vector3 direction = ball.transform.position - transform.position;
            Vector3 MoveDirection;
            MoveDirection.x = direction.x; MoveDirection.z = direction.z; MoveDirection.y = 0f;
            MoveDirection.Normalize();
            rb.velocity = MoveDirection * movementSpeed;
            // stay in bounds
            Vector3 clampedPosition = movementBounds.ClosestPoint(transform.position);
            transform.position = clampedPosition;
        } else {
            if(transform.position.z < 10 && transform.position.z > 8){
                rb.velocity = new Vector3(0,0,0);
            }else{
                Vector3 direction = new Vector3(0,0,9);
                direction = direction - transform.position;
                Vector3 MoveDirection;
                MoveDirection.x = direction.x; MoveDirection.z = direction.z; MoveDirection.y = 0f;
                MoveDirection.Normalize();
                rb.velocity = MoveDirection * movementSpeed;
            }
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ball = GameObject.Find("volleyball Variant(Clone)");
            Vector3 ballvelocity;
            ballvelocity.y = -ball.gameObject.GetComponent<Rigidbody>().velocity.y;
            Vector3 hitPosition = ball.transform.position + (leftHand.attachTransform.position - rightHand.attachTransform.position).normalized;
            // Randomize the distance within the maximum range
            Vector3 randomizedHitPosition = hitPosition + Random.insideUnitSphere * maxLandingDistance;
            if (randomizedHitPosition.z>3 && randomizedHitPosition.z<-1 && randomizedHitPosition.x<3 && randomizedHitPosition.x>-3)
            {
                Vector3 ballDirection = (randomizedHitPosition - transform.position).normalized;
                ballvelocity.x = ballDirection.x * movementSpeed;
                ballvelocity.z = ballDirection.z * movementSpeed;
                ball.gameObject.GetComponent<Rigidbody>().velocity = ballvelocity;
            }
            else
            {
                // Randomize a new hit position within the player side bounds
                Vector3 validHitPosition = playerCourtBounds.ClosestPoint(transform.position);
                Vector3 ballDirection = (validHitPosition - transform.position).normalized;
                ballvelocity.x = ballDirection.x * movementSpeed;
                ballvelocity.z = ballDirection.z * movementSpeed;
                ball.gameObject.GetComponent<Rigidbody>().velocity = ballvelocity;
            }
            
        }
    }

}
