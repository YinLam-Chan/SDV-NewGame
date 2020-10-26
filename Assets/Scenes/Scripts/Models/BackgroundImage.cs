using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    //public GameObject LocationImage;
    public GameObject[] LocationImages;

    public void changeBackground()
    {
        if (GameModel.currentPlayer != null)
        {
            if (GameModel.currentPlayer.LocationID == 1)
            {
                LocationImages[0].SetActive(true);
                LocationImages[1].SetActive(false);
                LocationImages[2].SetActive(false);

                //LocationImage = Resources.Load<GameObject>("Resources/Home");
            }
            else if (GameModel.currentPlayer.LocationID == 2)
            {
                LocationImages[0].SetActive(false);
                LocationImages[1].SetActive(true);
                LocationImages[2].SetActive(false);
                //LocationImage = Resources.Load<GameObject>("Resources/Town");
            }
            else if (GameModel.currentPlayer.LocationID == 3)
            {
                LocationImages[0].SetActive(false);
                LocationImages[1].SetActive(false);
                LocationImages[2].SetActive(true);
            }
        }
    }

    private void Update()
    {
        changeBackground();
    }

}

