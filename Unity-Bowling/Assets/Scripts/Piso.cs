using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    //Fetch the Renderer from the GameObject
    //Renderer rend = gameObject.GetComponent<Renderer>();

    //public GameObject piso;
   // public GameObject pilarMesh;
   public GameObject pisoTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider pisoTrigger)
    {
        //pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.green;

        if (pisoTrigger.gameObject.tag == "piso")
        {
            Debug.Log("COLISION");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (piso.gameObject.tag == "pilar")
        //{
        //    //pilarMesh.gameObject.GetComponent<Renderer>().material.color = Color.green;
        //    Debug.Log("el tag es pilar");
        //}
        //pilar2.transform.position = transform.position + Vector3.up * 1.1f;
        //pilar2.transform.rotation = transform.rotation;
        //
        //if (transform.rotation.x >= 90 || transform.rotation.x <= -90)
        //{

        //    gameObject.GetComponent<Renderer>().material.color = Color.green;
        //}
    }
}
