using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerLocation
{
    public string Username;
    public string Password;
    public int LocationID;

    public PlayerLocation(Player player)
    {
        Username = player.Username;
        Password = player.Password;
        LocationID = player.LocationID;
    }
}
