using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
	public AudioSource s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision){
    	if (collision.gameObject.CompareTag("Ball")){
    		s.PlayOneShot(s.clip);
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
