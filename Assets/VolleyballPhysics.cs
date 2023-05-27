using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballPhysics : MonoBehaviour
{
    public float serveForce = 10f;
    public float hitForce = 10f;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public void ServeBall(Vector3 direction) {
        rb.AddForce(direction * serveForce, ForceMode.Impulse);
    }

    public void Hitall(Vector3 direction) {
        rb.AddForce(direction * hitForce, ForceMode.Impulse);
    }

    public void StopBall() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision) {
        Vector3 bounceDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
        rb.velocity = bounceDirection * rb.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
