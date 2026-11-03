using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorMeta : MonoBehaviour
{
    [SerializeField]
    GameObject pantallaFinal;

    [SerializeField]
    TextMeshProUGUI textLabelTime;

    float tiempoDePartida = 0.0f;
    bool estaJugando = true;

    private void Update()
    {
        if (estaJugando == true)
        {
            tiempoDePartida = tiempoDePartida + Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador llegó a la meta");

            estaJugando = false;

            if (pantallaFinal != null)
            {
                pantallaFinal.SetActive(true);
            }

            if (textLabelTime != null)
            {
                textLabelTime.text = tiempoDePartida.ToString("F2") + " s";
                Debug.Log("Tiempo escrito: " + textLabelTime.text);
            }
            else
            {
                Debug.LogError("Text Label Time no está asignado en el Inspector");
            }

            MovimientoJugador movimiento = other.GetComponent<MovimientoJugador>();
            if (movimiento != null)
            {
                movimiento.enabled = false;
            }
        }
    }
}