using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameLevelController : MonoBehaviour {

    // Use this for initialization
    //public SpriteRenderer fondo;
    public SelectAvatarDefinitive selectAvatarDefinitive;
    public string[] NameLevels;
    public Text textNameLevel;

	// Update is called once per frame
	void Update () {
        CheckLevel();

    }
    public void CheckLevel()
    {
        if(selectAvatarDefinitive.playerSelectorsDefinitive[0].numChosenLevel <= NameLevels.Length - 1 && selectAvatarDefinitive.playerSelectorsDefinitive[0].numChosenAvatar >= 0)
        {
            if (NameLevels[selectAvatarDefinitive.playerSelectorsDefinitive[0].numChosenLevel] != null)
            {
                textNameLevel.text = NameLevels[selectAvatarDefinitive.playerSelectorsDefinitive[0].numChosenLevel];
            }
        }
        else
        {
            textNameLevel.text = " ";
        }
    }
}
