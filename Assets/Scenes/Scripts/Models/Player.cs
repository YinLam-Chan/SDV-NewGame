using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //attributes of a player
    private string email;
    private string password;
    private Location location;

    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public Location Location { get => location; set => location = value; }
}
