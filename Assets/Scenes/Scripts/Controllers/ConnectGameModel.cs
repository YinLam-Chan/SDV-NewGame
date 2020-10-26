using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectGameModel : MonoBehaviour
{
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
            
    }

    
}
