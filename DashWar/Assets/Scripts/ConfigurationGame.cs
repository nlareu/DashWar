using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationGame : MonoBehaviour
{
    private int WiningScore;
    public Text textWiningScore;
    public GameObject buttonSubstract;

    private void Start()
    {
        WiningScore = 1;
        textWiningScore.text = WiningScore.ToString();
        //buttonSubstract.SetActive(false);
    }

    public void SetWiningScoreDataLevel()
    {
        DataLevel.InstanceDataLevel.SetWiningScore(WiningScore);
    }

    /// <summary>
    /// Increases the winning score for the round.
    /// </summary>
    public void AddWiningScore()
    {
        buttonSubstract.SetActive(true);
        WiningScore++;
        textWiningScore.text = WiningScore.ToString();
    }

    /// <summary>
    /// Decreases the winning score for the round.
    /// </summary>
    public void SubstractWiningScore()
    {
        // No se permite un score menor a 1 porque dentro de la partida se anunciaría al ganador nada más entrar
        if(WiningScore > 1)
        {
            //buttonSubstract.SetActive(true);
            WiningScore--;
            textWiningScore.text = WiningScore.ToString();
        }

        if(WiningScore <= 1)
        {
            buttonSubstract.SetActive(false);
        }
    }
}
