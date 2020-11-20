using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConnectGameModel : MonoBehaviour
{
    public Text PlayerHereDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if (GameModel.Started == false)
        {
            GameModel.Name = "World Adventure";
            GameModel.SetupGame();
            GameModel.MakeGame();
            GameModel.Started = true;
        }

        else
        {
            GameModel.PlayerHereDisplay = PlayerHereDisplay;
        }
            
    }

    
}
