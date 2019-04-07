using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
    //Fetch the Renderer from the GameObject

    public GameObject pisoTrigger;
    public GameObject pilarMesh;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider pisoTrigger)
    {
        Debug.Log("COLISION");
        pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(pilarMesh.GetComponent<Collider>(), GetComponent<Collider>());
        transform.position = pilarMesh.transform.position;
        transform.rotation = pilarMesh.transform.rotation;
    }
}
