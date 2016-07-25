using UnityEngine;
using System.Collections;

public class ShootAtTarget : MonoBehaviour {

	public GameObject bullet;

	public float shootDelay = 0.1f;
	public float spawnDistance = 1.0f;

	public bool canShoot = true;

	void ResetShot () {
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 shootDirection = (Vector3.right * Input.GetAxis (horizontalAxis) + Vector3.forward * Input.GetAxis (verticalAxis));
		if (canShoot && Input.GetMouseButton(0)) {
			//transform.rotation = Quaternion.LookRotation (shootDirection, Vector3.up);
			Instantiate (bullet, transform.position + spawnDistance * transform.forward, transform.rotation);

			canShoot = false;
			Invoke ("ResetShot", shootDelay);
		}
	}
}
