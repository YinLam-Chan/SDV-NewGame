﻿using SQLite4Unity3d;
using UnityEngine;
using System.Linq;
// DataService is a bridge to SQlite 
// =================================
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{

    private SQLiteConnection _connection;
    public SQLiteConnection Connection { get { return _connection; } }
    public DataService(string WorldAdventure)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", WorldAdventure);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, WorldAdventure);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + WorldAdventure);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + WorldAdventure;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + WorldAdventure;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + WorldAdventure;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + WorldAdventure;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + WorldAdventure;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }


    public void SaveLocations(List<Location> Locations)
    {
        _connection.DropTable<Location>();
        _connection.CreateTable<Location>();
        _connection.InsertAll(Locations);
    }

    public List<Location> LoadLocations()
    {
        return _connection.Table<Location>().ToList<Location>();
    }

    public bool HaveLocations()
    {
        try
        {
            return LoadLocations().Count > 0;
        }
        catch
        {
            return false;
        }

    }


    /* ====== */
    public void CreateDB()
    {
        // remove these once testing is sorted
        //_connection.DropTable<Location>();
        //_connection.DropTable<ToFrom>();
        //_connection.DropTable<Player>();

        // creating the schema
        _connection.CreateTable<Location>();
        _connection.CreateTable<ToFrom>();
        _connection.CreateTable<Player>();
        _connection.CreateTable<Person>();

        //networkcreate
    }

    // Locations and their relationships 
    public IEnumerable<Location> GetLocations()
    {
        return _connection.Table<Location>();
    }

    public Location GetFirstLocation()
    {
        Location aLocation = _connection.Table<Location>().FirstOrDefault<Location>();
        return aLocation;
    }

    public bool haveLocations()
    {
        return _connection.Table<Location>().Count() > 0;
    }

    public ToFrom GetToFrom(int pFromID, string pDirection)
    {
        return _connection.Table<ToFrom>().Where(tf => tf.FromID == pFromID
                                                      && tf.Direction == pDirection).FirstOrDefault();
    }

    public Location GetLocation(int pLocationID)
    {
        return _connection.Table<Location>().Where(l => l.LocationId == pLocationID).FirstOrDefault();
    }

    public Location GetPlayerLocation(Player aPlayer)
    {
        return GetLocation(aPlayer.LocationID);
    }

    public Player GetScore(int pScore)
    {
        return _connection.Table<Player>().Where(s => s.Score == pScore).FirstOrDefault();
    }

    public Player GetPlayerScore(Player aPlayer)
    {
        return GetScore(aPlayer.Score);
    }

    public Location storeNewLocation(string pName, string pStory)
    {
        Location newLocation = new Location
        {
            LocationName = pName,
            Story = pStory
        };
        _connection.Insert(newLocation); // Store the location 
        return newLocation;  // return the location
    }
    public Location storeLocation(Location pLocation)
    {

        _connection.InsertOrReplace(pLocation); // Store the location 
        return pLocation;
    }


    public void storeFromTo(int pFromID, int pToID, string pDirection)
    {
        ToFrom f = new ToFrom
        {
            ToID = pToID,
            FromID = pFromID,
            Direction = pDirection
        };
        _connection.Insert(f);

    }


    // Player
    public Player storeNewPlayer(string pUsername, string pPassword,
                            int pLocationId, int pScore)
    {
        Player player = new Player
        {
            Username = pUsername,
            Password = pPassword,
            LocationID = pLocationId,
            Score = pScore
        };
        _connection.Insert(player);
        return player;
    }

    public void storePlayer(Player pPlayer)
    {
        _connection.InsertOrReplace(pPlayer);
        
    }

    public Player getPlayer(string pUsername)
    {
        return _connection.Table<Player>().Where(x => x.Username == pUsername).FirstOrDefault();
    }
    
}
