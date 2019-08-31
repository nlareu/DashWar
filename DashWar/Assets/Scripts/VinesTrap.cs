using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinesTrap : MonoBehaviour
{
    #region Fields

    public GameObject[] vines;

    public float trapTimeLimit = 3f;
    private float elapsedTrapTime = 0f;

    private int randomVine;
    private int lastVineSelected;

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    private void Start()
    {
        // Así nos aseguramos de que al comenzar la partida, no sea siempre la misma que no pueda ser seleccionada
        lastVineSelected = Random.Range(0, vines.Length);
        randomVine = Random.Range(0, vines.Length);
    }

    /// <summary>
    /// Update is executed once per frame, the main logic goes here.
    /// </summary>
    private void Update()
    {
        // Las enredaderas atraparán a un jugador cada cierta cantidad de tiempo
        elapsedTrapTime += Time.deltaTime;

        if(elapsedTrapTime >= trapTimeLimit)
        {
            elapsedTrapTime = 0f;

            // Seleccionando solo una enredadera para que pueda atrapar
            while (lastVineSelected == randomVine)
            {
                randomVine = Random.Range(0, vines.Length);
            }

            lastVineSelected = randomVine;

            for (int i = 0; i < vines.Length; i++)
            {
                TrapVine currentVine = vines[i].GetComponent<TrapVine>();

                if (i == randomVine)
                {
                    currentVine.catchPlayer = true;
                    currentVine.SpriteColor = currentVine.trappingColor;
                    currentVine.ColliderEnabled = true;

                    //Debug.Log(vines[i].name + " can catch a Player");
                }
                else
                {
                    //currentVine.catchPlayer = false;
                    //currentVine.ResetColor();
                    currentVine.ReleasePlayer();
                    currentVine.ColliderEnabled = false;
                }
            }
        }
    }

    #endregion
}
