using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public GameObject[] pinos;
    public GameObject cameraFollow;
    public float timer;

    private bool timeStart = false;
    private FollowBall camaraFollowBall;
    // Start is called before the first frame update
    void Start()
    {
        camaraFollowBall = cameraFollow.GetComponent<FollowBall>();
    }

    void OnTriggerEnter(Collider cameraFollow)
    {
        timeStart = true;
        camaraFollowBall.freezeCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeStart)
        {
            timer += Time.deltaTime;
            if (timer >= 6)
            {
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
