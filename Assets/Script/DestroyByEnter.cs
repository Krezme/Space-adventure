using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByEnter : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

 

    void OnTriggerEnter(Collider other){
		if (other.tag == "Arena"){
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player"){
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
        Destroy (gameObject);
		Destroy (other.gameObject);
	}
}
