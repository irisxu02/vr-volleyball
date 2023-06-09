using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
	private AudioSource s;
    // Start is called before the first frame update
    void Start()
    {
    	s = GameObject.Find("BounceSound").GetComponent<AudioSource>();
        //s = GetComponent<AudioSource>();
    }

    

    void OnCollisionEnter(Collision collision){
    	s.PlayOneShot(s.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
