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
        if(selectAvatarDefinitive.spriteSelectAvatar1.numChosenLevel <= NameLevels.Length - 1 && selectAvatarDefinitive.spriteSelectAvatar1.numChosenAvatar >= 0)
        {
            if (NameLevels[selectAvatarDefinitive.spriteSelectAvatar1.numChosenLevel] != null)
            {
                textNameLevel.text = NameLevels[selectAvatarDefinitive.spriteSelectAvatar1.numChosenLevel];
            }
        }
        else
        {
            textNameLevel.text = " ";
        }
    }
}
