using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

    public AvatarController PlayerSource;
    public int PlayersCount = 4;
    public List<GameObject> RespawnPositions = new List<GameObject>();

    private List<AvatarController> players = new List<AvatarController>();
    private List<AvatarController> playersDead = new List<AvatarController>();


    // Use this for initialization
    void Start () {
        for (int i = 0; i < this.PlayersCount; i++)
        {
            AvatarController player = Instantiate(this.PlayerSource, this.RespawnPositions[i].transform.position, Quaternion.identity);

            player.AppController = this;
            player.PlayerNumber = this.AddPlayer(player);
            player.Died += this.Player_Died;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Reset static.
            this.players.Clear();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public int AddPlayer(AvatarController avatar)
    {
        this.players.Add(avatar);

        return this.players.Count;
    }
    private bool CheckRoundEnded()
    {
        return (this.players.Count - this.playersDead.Count <= 1);
    }
    public List<AvatarController> GetPlayers()
    {
        //Return a copy to prevent reference and not desired changes on the list.
        return new List<AvatarController>(this.players);
    }
    private void RestartRound()
    {
        this.playersDead.Clear();

        for (int i = 0; i < this.players.Count; i++)
        {
            var player = this.players[i];
            var respawnPos = this.RespawnPositions[i].transform.position;

            player.transform.position = new Vector2(respawnPos.x, respawnPos.y);

            player.gameObject.SetActive(true);
        }
    }


    private void Player_Died(object sender, EventArgs e)
    {
        AvatarController avatar = (AvatarController)sender;

        playersDead.Add(avatar);



        if (this.CheckRoundEnded() == true)
            this.RestartRound();
    }
}
