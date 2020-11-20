using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWraper : MonoBehaviour
{
    public Text scoreDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        GameModel.scoreDisplay = scoreDisplayer;
        ScoreManager Scorer = new ScoreManager();
        GameModel.currentPlayer = Scorer.applyScoreRule(GameModel.currentPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
