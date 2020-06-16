using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject CuboAgua;
    public GameObject Fuego;
    public GameObject stop;

    public Text puntos;
    public Text puntos2;
    
    public float tiempoEntreSpawns = 4f; // tiempo entre oleadas
    private float tiempoParaSpawn = 2f; // despues de 2 segundos spawnearemos al empezar
    public float Oleadas = 0f;

    void Update()
    {
        if (Time.time >= tiempoParaSpawn && !stop.activeSelf)
        {
            Spawn();         

            tiempoParaSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    void Spawn () {

    int randomfuego = Random.Range(0, spawnPoints.Length);
    int reandomIndex = Random.Range(0, spawnPoints.Length); // Buscamos un index random del array

        for (int i = 0; i < spawnPoints.Length; i ++)   
        {   
            if (reandomIndex != i)          // Si el random no es igual al index del array creamos cubo
            {   
                Instantiate(CuboAgua, spawnPoints[i].position, Quaternion.identity);
            }
            if( reandomIndex == i && randomfuego == i)                        // si el random es diferente creamos fuego
            {
                Instantiate(Fuego, spawnPoints[i].position, Quaternion.identity);
            }

        }

        Oleadas++;
        puntos.text = "" + Oleadas;
        puntos2.text = "" + Oleadas;
    }
}

   
