using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
    //Fetch the Renderer from the GameObject

    public GameObject pisoTrigger;
    public GameObject pilarMesh;
    private bool isDown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider pisoTrigger)
    {
        if(!isDown)
        {
            Debug.Log("COLISION + 1 point!");
            pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.green;
            isDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(pilarMesh.GetComponent<Collider>(), GetComponent<Collider>());
        transform.position = pilarMesh.transform.position;
        transform.rotation = pilarMesh.transform.rotation;
    }
}
