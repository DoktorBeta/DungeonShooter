using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour {

	public bool canBounce = false;
	public int bounces = 0;
	public int maxBounces = 1;
	public float speed = 1.0f;
	public float maxLifetime = 5f;

	public Rigidbody rigidbody;
	public Transform originalObject;
	public Vector3 lookPos;

	private float lifetime = 0f;

	private Vector3 oldVelocity;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		lifetime = lifetime + Time.deltaTime;
		if (lifetime >= maxLifetime) {
			Destroy (gameObject);
		}
		oldVelocity = rigidbody.velocity;
		transform.LookAt (rigidbody.position + rigidbody.velocity);
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Solid") {
			Debug.Log("Hit!" + collision.gameObject.name);
			if (canBounce == false) {
				Destroy (gameObject);
			} else if (canBounce == true && bounces < maxBounces) {
				rigidbody.velocity = rigidbody.velocity.normalized * speed;
				Debug.Log ("Bounce!" + collision.gameObject.name);
				bounces = bounces + 1;
			} else if (bounces >= maxBounces) {
				Destroy (gameObject);
			}
		}
	}
}
