using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using SQLite4Unity3d;
using UnityEngine.UI;

public static class GameModel
{
    public static Text PlayerHereDisplay;

    private static string name;

    //Don't start the default game stage
    public static bool Started = false;

    public static string Name { get => name; set => name = value; }

    //the beginning stage of the game
    public static Location currentLocation;
    public static Player currentPlayer;
    public static Text scoreDisplay;
    public static DataService ds = new DataService("WorldAdventure.db");

    public static JSONDropService jsDrop = new JSONDropService { Token = "0031b110-baf3-4988-86c3-122c2a770b46" };

//Possible scenarios of password checking
public enum PasswdMode
    {
        NeedUsername,
        NeedPassword,
        OK,
        AllBad
    }

    //Get username from the data service if the player had already registered, check whether the password matches with the data saved, bring the player to the current stage
    public static PasswdMode CheckPassword(string pUsername, string pPassword)
    {
        PasswdMode result = GameModel.PasswdMode.AllBad;

        Player aPlayer = ds.getPlayer(pUsername);
        if (aPlayer != null)
        {
            if (aPlayer.Password == pPassword)
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer;
                GameModel.currentLocation = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
                
            }
            else
            {
                result = GameModel.PasswdMode.NeedPassword;
            }
        }
        else
            result = GameModel.PasswdMode.NeedUsername;

        return result;
    }

    //Use the username and password that the player had typed in as his username and password
    public static void RegisterPlayer(string pUsername, string pPassword)
    {
        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pUsername, pPassword, GameModel.currentLocation.LocationId, 0);
        networkRegister();
    }

    //if the player didn't exist, then register the player to the network
    public static void networkRegister()
    {
        jsDrop.Create<Person, JsnReceiver>(new Person
        {
            Name = "UUUUUUUUUUUUUUUUUUUUUUUUUUU",
            Score = 0,
            Password = "***************************",
            LocationId = 1,
        }, jsnReceiverCreateDel);
    }

    //create delegate, create a new player in network
    public static void jsnReceiverCreateDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        StorePlayer();
        // To do: parse and produce an appropriate response
    }

    public static void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public static void jsnListReceiverDel(List<Person> pReceivedList)
    {
        GameModel.PlayerHereDisplay.text = "";
        Debug.Log("Received items " + pReceivedList.Count);
        foreach (Person lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.Name + "," + lcReceived.Password + "," + lcReceived.Score.ToString() + "}");
            GameModel.PlayerHereDisplay.text += lcReceived.Name + "\n";
        }// for

        // To do: produce an appropriate response
    }

    public static void jsnGetReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public static void jsnGetPlayerReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
        GameModel.PlayerHereDisplay.text = "";
    }

    public static void getPlayers()
    {
        jsDrop.Select<Person, JsnReceiver>("LocationID = " + GameModel.currentPlayer.LocationID, jsnListReceiverDel, jsnGetPlayerReceiverDel);
    }



    public static void StorePlayer()
    {
        jsDrop.Store<Person, JsnReceiver>(new List<Person>
        {
            new Person { Name = GameModel.currentPlayer.Username, Score = 0, Password = GameModel.currentPlayer.Password, LocationId = GameModel.currentLocation.LocationId }

         }, jsnReceiverStoreDel);
    }

    //store dalegate, store it in the network
    public static void jsnReceiverStoreDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        getPlayers();
    }
    
   

    

    public static void SetupGame()
    {
        
        ds.CreateDB();
        //createNetworkStorage
    }

    //the starting page when the player first arrive to the game
    public static void MakeGame()
    {
        if (!GameModel.ds.haveLocations())
        {
            Location home, town, breadshop;
            currentLocation = GameModel.ds.storeNewLocation("Home", "You are in a world that there are humans and monsters." + "\n" + "One day you decided to escape from home"
                    + "\n" + "There is only one way out of the village, you can head to north to go to the town.");

            home = currentLocation;

            home.addLocation("North", "Town", "You are about to start your advanture! Let's go to get some food before the long journey, " +
            "the BreadMaster Bakery sells delicious bread in the town.");

            
            town = home.getLocation("North");
            town.addLocation("South", home);

            town.addLocation("East", "BreadMaster Bakery", "Would you like to pick up some bread?");


            breadshop = town.getLocation("East");
            breadshop.addLocation("West", town);

            
        }
        else
            currentLocation = GameModel.ds.GetFirstLocation();
    }
}

    