using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    //attributes of a location
    private string locationName;
    private string story;
    //private image locationImage;

    private Dictionary<string, Location> Locations = new Dictionary<string, Location>();

    public string LocationName { get => locationName; set => locationName = value; }
    public string Story { get => story; set => story = value; }
    //public image LocationImage { get => locationImage; set => locationImage = value; }



    //method to update the next location as current location
    public void updateLocation(string pDirection, string pLocationName, string pStory)
    {
        Location nextLocation = new Location
        {
            LocationName = pLocationName,
            Story = pStory
        };

        Locations.Add(pDirection, nextLocation);
    }

    //player can choose to go back to the pervious location
    public void updateLocation(string pDirection, Location pLocation)
    {
        Locations.Add(pDirection, pLocation);
    }


    public Location getLocation(string pDirection)
    {
        Location thisLocation = null;

        if (!Locations.TryGetValue(pDirection, out thisLocation))
        {
            Debug.Log("Do not understand");
        }

        return thisLocation;
    }
}
