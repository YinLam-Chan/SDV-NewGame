using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CommandProcessor
{
    //private Sprite newImage;
    //public GameObject image;
    public CommandProcessor()
    {
        
    }

    public string Parse(string pCommand)
    {
        //convert the text input into lowercase,split words into parts of the command string
        string strResult = "Do not understand";
        pCommand = pCommand.ToLower();
        string[] parts = pCommand.Split(' ');
        Location nextLocation;

        if (parts.Length > 0)
        {
            //parse the first word of the command
            switch (parts[0])
            {
                case "go":
                    //parse the second word of the command, then do something
                    if (parts[1] == "north")
                    { 
                        Debug.Log("You are going to north");
                        nextLocation = GameModel.currentLocation.getLocation("North");
                        //if the game does not allow player to go there, then tell the player cannot go there
                        if (nextLocation == null)
                        {
                            strResult = "Sorry cannot go there" + "\n" + GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                        }
                        else
                        {
                            GameModel.currentLocation = nextLocation;
                            GameModel.currentPlayer.LocationID = nextLocation.LocationId;
                            
                            strResult = GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                        }
                        
                    }


                    if (parts[1] == "south")
                    { 
                        Debug.Log("You are going south");
                            nextLocation = GameModel.currentLocation.getLocation("South");
                            if (nextLocation == null)
                            {
                                strResult = "Sorry cannot go there" + "\n" + GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                            }
                            else
                            {
                                GameModel.currentLocation = nextLocation;
                                GameModel.currentPlayer.LocationID = nextLocation.LocationId;
                                
                                strResult = GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                            }
                           
                    }

                    if (parts[1] == "east")
                    {
                        Debug.Log("You are going east");
                        nextLocation = GameModel.currentLocation.getLocation("East");
                        if (nextLocation == null)
                        {
                            strResult = "Sorry cannot go there" + "\n" + GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                        }
                        else
                        {
                            GameModel.currentLocation = nextLocation;
                            GameModel.currentPlayer.LocationID = nextLocation.LocationId;
                            
                            strResult = GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;
                        }
                    }
                    break;
                case "pick":
                    strResult = "Pick up something";
                    break;
                    //default:
                    //    strResult = "I don't know";
                    //    break;
            }

            //Storing the current location and player scores
            ScoreManager Scorer = new ScoreManager();
            GameModel.currentPlayer = Scorer.applyScoreRule(GameModel.currentPlayer);
            GameModel.ds.storePlayer(GameModel.currentPlayer);

            return strResult;

        }
        //if neither of the above cases, then return "do not understand"
        else
        {
            Debug.Log("Do not understand");
            return strResult;
        }
    }


}
