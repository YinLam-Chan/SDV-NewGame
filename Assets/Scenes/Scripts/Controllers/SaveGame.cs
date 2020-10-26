using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGame
{
    public static void SavePlayerLocation (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerLocation data = new PlayerLocation(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player LoadPlayerLocation()
    {
        
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerLocation data = formatter.Deserialize(stream) as PlayerLocation;
            stream.Close();
            Player thePlayer = new Player
            {
                LocationID = data.LocationID,
                Password = data.Password,
                Username = data.Username
            };

            return thePlayer;
        }
        else
        {
            Debug.LogError("Cannot save file");
            return null;
        }
    }
}
