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

    // Start is called before the first frame update
    void Start()
    {
        pillarInitialPosition = pilarMesh.transform.position;
        rig = pilarMesh.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider pisoTrigger)
    {
        if(!isDown)
        {
            if(pisoTrigger.tag == "piso")
            {
                pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.green;
                isDown = true;
                puntaje.GetComponent<Puntos>().pinos = puntaje.GetComponent<Puntos>().pinos - 1;
                puntaje.GetComponent<Puntos>().allPoints = puntaje.GetComponent<Puntos>().allPoints + 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(pilarMesh.GetComponent<Collider>(), GetComponent<Collider>());
        
        transform.position = pilarMesh.transform.position;
        transform.rotation = pilarMesh.transform.rotation;

        if (resetReady && !isDown)
        {
            if (puntaje.GetComponent<Puntos>().pinos <= 0)
            {
                puntaje.GetComponent<Puntos>().pinos = 0;
            }
            else puntaje.GetComponent<Puntos>().pinos = puntaje.GetComponent<Puntos>().pinos;

            pilarMesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            pilarMesh.transform.position = pillarInitialPosition;
            pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.white;
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
