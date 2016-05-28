using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    private Rigidbody rigBod;
    public float tumble;

	// Use this for initialization
	void Start () {
        rigBod = GetComponent<Rigidbody>();
        rigBod.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
