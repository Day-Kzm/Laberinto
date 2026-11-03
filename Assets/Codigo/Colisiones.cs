using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionPared : MonoBehaviour
{
    [SerializeField]
    Material materialPorDefecto;

    [SerializeField]
    Material materialParedTocada;

    [SerializeField]
    float duracionEnRojo = 3f;

    bool paredRoja = false;
    float tiempoEnRojo;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //Funcion que se ejecuta por cada imagen del juego
    private void Update()
    {
        if (paredRoja)
        {
            tiempoEnRojo -= Time.deltaTime;
            if (tiempoEnRojo < 0.0f)
            {
                meshRenderer.material = materialPorDefecto;
                paredRoja = false;
            }
        }
    }

    //Funcion que se ejecuta al chocar un objeto con este GameObject.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            meshRenderer.material = materialParedTocada;
            paredRoja = true;
            tiempoEnRojo = duracionEnRojo;
        }
    }
}