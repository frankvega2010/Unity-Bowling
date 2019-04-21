using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzarPelota : MonoBehaviour
{
    public GameObject puntaje;
    public bool resetReady = false;
    public bool useGravity;
    public bool isLaunched = false;
    public bool switchOnce = false;
    public float force;
    public Text forceText;
    public Text tirosText;

    private Rigidbody rig;
    private int forceInt;
    private int tiros = 3;
    private Vector3 ballPosition;
    private Vector3 ballInitialPosition;
    private Puntos puntajeJugador;

    // Start is called before the first frame update
    void Start()
    {
        ballInitialPosition = transform.position;
        rig = GetComponent<Rigidbody>();
        puntajeJugador = puntaje.GetComponent<Puntos>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       if (resetReady)
       {
           if (puntajeJugador.pinos <= 0)
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
           switchOnce = false;
        }

        forceText.text = "Fuerza: " + forceInt.ToString();

        if (tiros > 0)
        {
            tirosText.text = "Tiros: " + tiros.ToString();
        } else
        {
            tirosText.text = "Sin Tiros restantes";
            puntajeJugador.isMatchFinished = true;
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
            switchOnce = true;
        }

        if (Input.GetKeyUp("space") && !isLaunched)
        {
            rig.AddForce(Vector3.forward*force,ForceMode.Impulse);
            isLaunched = true;
        }

        if (Input.GetKey("q"))
        {
            transform.position = new Vector3(12.71f, 2.407f, -24.65f); // magic numbers
        }       
    }

}
