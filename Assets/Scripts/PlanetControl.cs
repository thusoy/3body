using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetControl : MonoBehaviour {
	private List<Rigidbody> celestialBodies;
	// gravitational constant
	private double G = 1.6 * Mathf.Pow(10, 0);

	void Start () {
		// Set initial velocities
		Rigidbody sola = GameObject.Find ("solb").GetComponent<Rigidbody> ();
		Rigidbody solb = GameObject.Find ("sola").GetComponent<Rigidbody> ();
		Rigidbody solc = GameObject.Find ("solc").GetComponent<Rigidbody> ();
		Rigidbody planet = GameObject.Find ("planet").GetComponent<Rigidbody> ();
		sola.AddForce (3000.0f, 5066.0f, -2005.0f);
		solb.AddForce (-3000.0f, -9000.0f, 1000.0f);
		solc.AddForce (20.0f, 00.0f, -7000.0f);
		planet.AddForce (20.0f, 00.0f, 20.0f);
		GameObject.Find ("planetcam").GetComponent<Camera> ().transform.parent = planet.transform;

		celestialBodies = new List<Rigidbody> ();
		celestialBodies.Add (sola);
		celestialBodies.Add (solb);
		celestialBodies.Add (solc);
		celestialBodies.Add (planet);
	}

	// Use this for initialization
	void FixedUpdate () {
		foreach (Rigidbody body in celestialBodies) {
			foreach (Rigidbody otherBody in celestialBodies) {
				if (otherBody == body) {
					continue;
				}
				Vector3 distance = otherBody.position - body.position;
				Vector3 force = (float) G * otherBody.mass * body.mass * distance / distance.sqrMagnitude;

				body.AddForce(force);
			}
		}
	}
}