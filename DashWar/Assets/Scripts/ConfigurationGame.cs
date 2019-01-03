using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationGame : MonoBehaviour {

    // Use this for initialization
    private int WiningScore;
    public Text textWiningScore;
    public GameObject buttonSubstract;
    private void Start()
    {
        WiningScore = 0;
        textWiningScore.text = "" + WiningScore;
        buttonSubstract.SetActive(false);
    }
    public void SetWiningScoreDataLevel()
    {
        DataLevel.InstanceDataLevel.SetWiningScore(WiningScore);
    }
    public void AddWiningScore()
    {
        buttonSubstract.SetActive(true);
        WiningScore++;
        textWiningScore.text = "" + WiningScore;
    }
    public void SubstractWiningScore()
    {
        if(WiningScore > 0)
        {
            buttonSubstract.SetActive(true);
            WiningScore--;
            textWiningScore.text = "" + WiningScore;
        }
        if(WiningScore <= 0)
        {
            buttonSubstract.SetActive(false);
        }
    }
}
