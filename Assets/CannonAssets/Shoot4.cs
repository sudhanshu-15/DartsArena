﻿// Shoot4.cs
// Create and shoot into the air a new cannonball instance when "Fire1" input is triggered
// Split the shooting operation into a separate method ("Shoot"), which can be called from other scripts
// Now add a new material that the Cannon will temporarily have when fired.
// Now make sure to not overwrite original material, and store renderer.

using UnityEngine;
using System.Collections;

public class Shoot4 : MonoBehaviour {
	public GameObject projectilePrefab;	// Copies of this prefab will be the ammo (e.g. "cannonball")
	public Material fireMaterial;		// The temporary material used when Cannon is fired
	private Material normMaterial;		// Store the normal material of the Cannon for restoration
	private float shootSpeed = 30.0f;	// A speed to give the newly created projectiles
	private Renderer myRenderer;

	// Store the normal material and the renderer
	void Start() {
		myRenderer = this.GetComponent<Renderer> ();
		normMaterial = myRenderer.material;
	}

	// Update routine now just watches for the "Fire1" button
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot() {
		GameObject newBall;		// A variable to store the newly created projectile

		//Debug.Log ("Fire");

		// Create a new cannonball, name it, give it an initial velocity pointed in the direction
		//   of our "cannon", and then set it to self-destruct after 15 seconds.
		newBall = (GameObject)Instantiate (projectilePrefab, transform.position, transform.rotation);
		newBall.name = "CannonBall";
		newBall.GetComponent<Rigidbody>().velocity = transform.up * shootSpeed;
		Destroy (newBall.gameObject, 15);

		// Temporarily change the Cannon's material
		myRenderer.material = fireMaterial;
		Invoke("RestoreMaterial", 0.15f);
	}

	void RestoreMaterial() {
		myRenderer.material = normMaterial;
	}
}