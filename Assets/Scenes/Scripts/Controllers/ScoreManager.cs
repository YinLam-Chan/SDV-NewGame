using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    //if the players go to the next location, they can earn some scores
   public Player applyScoreRule(Player pPlayer)
    {


        if (GameModel.ds.GetPlayerLocation(pPlayer).LocationName == "Town")
        {
            pPlayer.Score = pPlayer.Score + 500;
            if (GameModel.scoreDisplay != null)
            {
                GameModel.scoreDisplay.text = pPlayer.Score.ToString();
            }
            
        }

        else if (GameModel.ds.GetPlayerLocation(pPlayer).LocationName == "BreadMaster Bakery")
        {
            pPlayer.Score = pPlayer.Score + 500;
            if (GameModel.scoreDisplay != null)
            {
                GameModel.scoreDisplay.text = pPlayer.Score.ToString();
            }
        }
        return pPlayer;
    }
}
