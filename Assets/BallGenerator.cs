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

	GameObject spawnBall;

	IEnumerator downcount(){
		spawnBall = Instantiate(Volleyball, spawnPoint.position, spawnPoint.rotation);
        spawnBall.GetComponent<Rigidbody>().isKinematic = true;
		Downcount.alpha = 1;
		Downcount.text = "3";
		yield return new WaitForSeconds(1f);
		Downcount.text = "2";
		yield return new WaitForSeconds(1f);
		Downcount.text = "1";
		yield return new WaitForSeconds(1f);
		Downcount.text = "GO!";
		yield return new WaitForSeconds(1f);
		Downcount.alpha = 0;
		spawnBall.GetComponent<Rigidbody>().velocity = spawnPoint.forward * 5;
        spawnBall.GetComponent<Rigidbody>().isKinematic = false;
	}
    // Start is called before the first frame update
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        
    }
}