using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPelota : MonoBehaviour
{
    public float force;
    public bool useGravity;

    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rig.AddForce(Physics.gravity * rig.mass);
        if (Input.GetKeyUp("space"))
        {
            rig.AddForce(Vector3.forward*force,ForceMode.Impulse);
        }

        if (Input.GetKey("q"))
        {
            transform.position = new Vector3(12.71f, 2.407f, -24.65f);
        }
    }

    void FixedUpdate()
    {
        rig.useGravity = false;
       // rig.AddForce(Physics.gravity * rig.mass);
        if (useGravity) rig.AddForce(Physics.gravity * (rig.mass * rig.mass), ForceMode.Force);
    }
}
