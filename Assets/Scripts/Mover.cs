using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rigBod;
    public float speed;

	// Use this for initialization
	void Start () {
        rigBod = GetComponent<Rigidbody>();
        rigBod.velocity = transform.forward * speed;
	}
}
