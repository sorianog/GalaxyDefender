using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rigBod;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHort = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHort, 0.0f, moveVert);
        rigBod.velocity = movement * speed;

        rigBod.position = new Vector3
        (
            Mathf.Clamp(rigBod.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigBod.position.z, boundary.zMin, boundary.zMax)
        );

        rigBod.rotation = Quaternion.Euler(0.0f, 0.0f, rigBod.velocity.x * -tilt);
    }
}
