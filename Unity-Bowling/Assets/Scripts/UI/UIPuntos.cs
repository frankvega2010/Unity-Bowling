using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPuntos : MonoBehaviour
{
    public int pinos = 0;
    public int allPoints = 0;
    public bool isMatchFinished = false;
    public Text pinosText;
    public Text finishText;

    private bool changeTextOnce = false;
    void mostrarPuntajeFinal()
    {
        finishText.text = "Has terminado con : " + allPoints.ToString() + " puntos! Felicidades!";
        changeTextOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        pinosText.text = "Pinos: " + pinos.ToString();

        if (isMatchFinished && !changeTextOnce) mostrarPuntajeFinal();
    }
}
