using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameModel
{
    //the beginning stage of the game
    public static Location currentLocation;
    public static Player currentPlayer;
    public static string Name;
    //the starting page when the player first arrive to the game
    public static void CreateGame()
    {
        Location home, town;
        currentLocation = new Location
        {
            LocationName = "Home",
            Story = "You are in a world that there are humans and monsters." + "\n" + "You had been abused by your stepmother, one day you decided to escape from home"
                    + "\n" + "There is only one way out of the village, you can head to north to go to the town."
        };

        home = currentLocation;

        home.updateLocation("North", "Town", "You are about to start your advanture! Let's go to get some food before the long journey, " +
            "the BreadMaster Bakery sells delicious bread in the town.");

        town = home.getLocation("North");
        town.updateLocation("South", home);
    }
}
