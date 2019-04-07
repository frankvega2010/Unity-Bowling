using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPelota : MonoBehaviour
{
    public float force;
    public bool useGravity;
    private Vector3 ballPosition;

    private bool isLaunched = false;

    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       if (!isLaunched) transform.position = new Vector3(transform.position.x + horizontal * 10 * Time.deltaTime, transform.position.y, transform.position.z);
        //rig.AddForce(transform.position, ForceMode.Impulse);

        // ballPosition = new Vector3(horizontal * 1, 0, 0);

        // rig.AddForce(ballPosition, ForceMode.VelocityChange);

        //rig.AddForce(Physics.gravity * rig.mass);

        if (vertical == 1) force = force + 10 * Time.deltaTime;
        else if (vertical == -1)force = force - 10 * Time.deltaTime;

        if (force >= 100) force = 100;
        else if (force <= 0) force = 0;

        if (Input.GetKeyUp("space") && !isLaunched)
        {
            rig.AddForce(Vector3.forward*force,ForceMode.Impulse);
            isLaunched = true;
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
