using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public int pinos = 0;
    public int allPoints = 0;
    public bool isMatchFinished = false;
    public Text pinosText;
    public Text finishText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pinosText.text = "Pinos: " + pinos.ToString();

        if(isMatchFinished) finishText.text = "Has terminado con : " + allPoints.ToString() + " puntos! Felicidades!";
    }
}
