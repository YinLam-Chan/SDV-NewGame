using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void SavePlayerLocation()
    {
       GameModel.ds.storePlayer(GameModel.currentPlayer);
    }

    public void LoadPlayerLocation()
    {
        GameModel.currentLocation = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
        GameModel.currentPlayer = GameModel.ds.GetPlayerScore(GameModel.currentPlayer);
    }
}
