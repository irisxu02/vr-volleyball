using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ValleyballMovementControl : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Teammate;
	//public Transform spawnPoint;
	public float UnitSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(HitByPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitByPlayer(ActivateEventArgs arg){
    	//transform TargetPosition = Teammate.transform.position;
    	Ball.GetComponent<Rigidbody>().velocity = (Teammate.transform.position - Ball.transform.position) * UnitSpeed;
    }

    public void HitByTeammate(ActivateEventArgs arg){

    }


    //public void FireBullet(ActivateEventArgs arg){
    	//GameObject spawnedBullet = Instantiate(bullet);
    	//spawnedBullet.transform.position = spawnPoint.position;
    	//spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
    	//Destroy(spawnedBullet,5);
    //}
}
