using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class Player
{
    //attributes of a player
    private string username;
    private string password;
    private int locationID;
    private int score;

    [PrimaryKey, AutoIncrement]
    public int PlayerID { get; set; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public int LocationID { get => locationID; set => locationID = value; }
    public int Score { get => score; set => score = value; }

    public void SavePlayerLocation()
    {
        SaveGame.SavePlayerLocation(this);
    }

    public void LoadPlayerLocation()
    {
        Player data = SaveGame.LoadPlayerLocation();

        Username = data.Username;
        Password = data.Password;
        LocationID = data.LocationID;
        Score = data.Score;
    }
}
