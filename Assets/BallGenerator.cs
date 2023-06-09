using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallGenerator : MonoBehaviour
{
	public GameObject Volleyball; // Reference to the ball prefab
    public Transform spawnPoint; // Spawn point for the new ball
	public ScoreManager ScoreManager;
	public TMPro.TextMeshProUGUI Downcount;
    public AudioSource whistle;
	public AudioSource hitSound;


	GameObject spawnBall;

	IEnumerator downcount(){
		//yield return new WaitForSeconds(2f);
		

		Downcount.alpha = 1;
		Downcount.text = "3";
		yield return new WaitForSeconds(1f);
		Downcount.text = "2";
		yield return new WaitForSeconds(1f);
		Downcount.text = "1";
		yield return new WaitForSeconds(1f);
		spawnBall = Instantiate(Volleyball, spawnPoint.position, spawnPoint.rotation);
		spawnBall.GetComponent<Rigidbody>().isKinematic = true;
		Downcount.text = "GO!";
		yield return new WaitForSeconds(1f);
		Downcount.alpha = 0;
		Vector3 v = new Vector3(0,1,0);
		
		spawnBall.GetComponent<Rigidbody>().velocity = v * 8;
		spawnBall.GetComponent<Rigidbody>().isKinematic = false;
		//whistle.Play();
	}
    // Start is called before the first frame update
    void Start()
    {
        whistle = GetComponent<AudioSource>();
        StartCoroutine(downcount());
    }


    public void GenerateBall()
    {
        StartCoroutine(downcount()); 
    }

    public void DestroyBall()
    {
    	Destroy(spawnBall);
    }
    
	void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Play the bounce sound effect
            hitSound.Play();
        }
    }
}