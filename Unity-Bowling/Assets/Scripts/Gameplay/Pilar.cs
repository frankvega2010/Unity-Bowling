using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
    public GameObject puntaje;
    public GameObject pisoTrigger;
    public GameObject pilarMesh;
    public bool isDown = false;
    public bool resetReady = false;

    private Vector3 pillarInitialPosition;
    private Rigidbody rig;
    private Puntos puntajeJugador;
    private Renderer pilarBrush;
    private Collider pilarCollider;
    private Collider triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        pillarInitialPosition = pilarMesh.transform.position;
        rig = pilarMesh.GetComponent<Rigidbody>();
        puntajeJugador = puntaje.GetComponent<Puntos>();
        pilarBrush = pilarMesh.gameObject.GetComponent<Renderer>();
        pilarCollider = pilarMesh.GetComponent<Collider>();
        triggerCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider pisoTrigger)
    {
        if(!isDown)
        {
            if(pisoTrigger.tag == "piso")
            {
                pilarBrush.material.color = Color.green;
                isDown = true;
                puntajeJugador.pinos = puntajeJugador.pinos - 1;
                puntajeJugador.allPoints = puntajeJugador.allPoints + 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(pilarCollider, triggerCollider);
        
        transform.position = pilarMesh.transform.position;
        transform.rotation = pilarMesh.transform.rotation;

        if (resetReady && !isDown)
        {
            if (puntajeJugador.pinos <= 0)
            {
                puntajeJugador.pinos = 0;
            }

            pilarMesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            pilarMesh.transform.position = pillarInitialPosition;
            pilarBrush.material.color = Color.white;
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
            resetReady = false;
            isDown = false;
        }
        else if (resetReady && isDown)
        {
            pilarMesh.SetActive(false);
        }
    }
}
