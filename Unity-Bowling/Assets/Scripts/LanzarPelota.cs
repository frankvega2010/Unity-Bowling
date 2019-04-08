using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzarPelota : MonoBehaviour
{
    public GameObject puntaje;
    public GameObject mainCamera;
    public GameObject ballCamera;
    public bool freezeCamera = false;
    public bool resetReady = false;
    public bool useGravity;
    public float force;
    public Text forceText;
    public Text tirosText;

    private Rigidbody rig;
    private int forceInt;
    private int tiros = 3;
    private Vector3 ballPosition;
    private Vector3 ballInitialPosition;
    private bool isLaunched = false;
    private bool switchOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        ballInitialPosition = transform.position;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       if (resetReady)
       {
           if (puntaje.GetComponent<Puntos>().pinos <= 0)
           {
               tiros = 0;
           }
           else tiros--;

           transform.position = ballInitialPosition;
           transform.rotation = Quaternion.Euler(0, 0, 0);
           rig.velocity = Vector3.zero;
           rig.angularVelocity = Vector3.zero;
           force = 50;
           resetReady = false;
           isLaunched = false;
           mainCamera.SetActive(true);
           ballCamera.SetActive(false);
           switchOnce = false;
           freezeCamera = false;
        }

        forceText.text = "Fuerza: " + forceInt.ToString();

        if (tiros > 0)
        {
            tirosText.text = "Tiros: " + tiros.ToString();
        } else
        {
            tirosText.text = "Sin Tiros restantes";
            puntaje.GetComponent<Puntos>().isMatchFinished = true;
            isLaunched = true;
            switchOnce = true;
        }


        if (!isLaunched)
        {
            forceInt = (int)force;

            transform.position = new Vector3(transform.position.x + horizontal * 10 * Time.deltaTime, transform.position.y, transform.position.z);

            if (vertical == 1) force = force + 30 * Time.deltaTime;
            else if (vertical == -1) force = force - 30 * Time.deltaTime;

            if (force >= 100) force = 100;
            else if (force <= 0) force = 0;
        }
        else if(!switchOnce && isLaunched)
        {
            mainCamera.SetActive(false);
            ballCamera.SetActive(true);
            switchOnce = true;
            freezeCamera = false;
        }

        if(isLaunched && !freezeCamera)
        {
            ballCamera.transform.position = transform.position + new Vector3(0, 1.5f, -5);
            ballCamera.transform.rotation = Quaternion.Euler(20, 0, 0);
        }

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
        if (useGravity) rig.AddForce(Physics.gravity * (rig.mass * rig.mass), ForceMode.Force);
    }
}
