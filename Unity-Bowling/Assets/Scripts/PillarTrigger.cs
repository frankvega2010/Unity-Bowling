using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public float timer;

    public GameObject bola;
    public GameObject[] pinos;

    private bool timeStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        timeStart = true;
        ball.GetComponent<LanzarPelota>().freezeCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeStart)
        {
            timer += Time.deltaTime;
            if (timer >= 6)
            {
                bola.GetComponent<LanzarPelota>().resetReady = true;
                for (int i = 0; i < pinos.Length; i++)
                {
                    pinos[i].GetComponent<Pilar>().resetReady = true;
                }
                timeStart = false;
                timer = 0;
            }
        }
        
    }
}
