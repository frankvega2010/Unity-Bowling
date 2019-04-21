using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text restartText;
    public GameObject puntaje;

    private UIPuntos puntajeJugador;
    private bool switchOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        restartText.text = "";
        puntajeJugador = puntaje.GetComponent<UIPuntos>();
    }

    void SwitchText()
    {
        restartText.text = "Presiona la tecla R para reiniciar!";
        switchOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (puntajeJugador.isMatchFinished && !switchOnce) SwitchText();

        if(puntajeJugador.isMatchFinished)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("BowlingStage");
            }
        }
    }
}
