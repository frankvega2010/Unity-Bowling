using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrigger : MonoBehaviour
{
    public GameObject bola;
    public float timer;

    private bool timeStart = false;
    private LanzarPelota ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = bola.GetComponent<LanzarPelota>();
    }

    void OnTriggerEnter(Collider cameraFollow)
    {
        timeStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {
            timer += Time.deltaTime;
            if (timer >= 6)
            {
                ball.resetReady = true;
                timeStart = false;
                timer = 0;
            }
        }

    }
}
