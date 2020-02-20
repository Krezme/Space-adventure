using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float minX, maxX, minZ, maxZ;
	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;


	private Rigidbody rb;
	private float nextFire;
	private AudioSource audio;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update(){
	
		if (Input.GetButton("Fire1") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}

	}

	void FixedUpdate()
	{ 

		float MoveHorizontal = Input.GetAxis("Horizontal");
		float MoveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
		rb.velocity = movement * speed;

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

		rb.position = new Vector3 (

			Mathf.Clamp (rb.position.x, minX, maxX),
			0.0f,
			Mathf.Clamp (rb.position.z, minZ, maxZ)

		);

	}
}