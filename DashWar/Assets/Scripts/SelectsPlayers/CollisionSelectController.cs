using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSelectController : MonoBehaviour {

    // Use this for initialization
    //public SelectorPlayer player1;
    //public SelectorPlayer player2;
    //public SelectorPlayer player3;
    //public SelectorPlayer player4;
    public SelectorPlayer[] players;
    public SpriteRenderer avatarSelector;
    public int numAvatar;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collision();
	}

    public void ControlCollision(SelectorPlayer player)
    {
        if (player.gameObject.transform.position.x >= transform.position.x && player.gameObject.transform.position.x <= transform.position.x+avatarSelector.sprite.texture.width
            && player.gameObject.transform.position.y >= transform.position.y && player.gameObject.transform.position.y <= transform.position.y + avatarSelector.sprite.texture.height)
        {
            Debug.Log("Colicion");
        }
    }
    public void Collision()
    {
        for(int i = 0; i< players.Length; i++)
        {
            ControlCollision(players[i]);
        }
    }
}
