using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject ballCamera;
    public GameObject ball;
    public bool freezeCamera;

    private LanzarPelota mainBall;
    // Start is called before the first frame update
    void Start()
    {
        mainBall = ball.GetComponent<LanzarPelota>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainBall.resetReady)
        {
            mainCamera.SetActive(true);
            ballCamera.SetActive(false);
            freezeCamera = false;
        }

        if (!mainBall.switchOnce && mainBall.isLaunched)
        {
            mainCamera.SetActive(false);
            ballCamera.SetActive(true);
            mainBall.switchOnce = true;
            freezeCamera = false;
        }

        if (mainBall.isLaunched && !freezeCamera)
        {
            ballCamera.transform.position = ball.transform.position + new Vector3(0, 1.5f, -5);
            ballCamera.transform.rotation = Quaternion.Euler(20, 0, 0);
        }
    }
}
