using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{

    public int profileID;
    public ProfileData data;

    /* This Script deals with loading and saving a players profile data to a particular profile.
    *A profile data script should implemented in the scene for each player in the scene.
    *it is wise to have another script set the profile ID and call the Load() function when the scene first loads
    *and to have the Save function called before another scene is loaded.
    */

    public void Save(ProfileData data, int ID)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + ProfileControl.profiles.profile[ID] + "Profile.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(ProfileData data, int ID)
    {
        if (File.Exists(Application.persistentDataPath + "/" + ProfileControl.profiles.profile[ID] + "Profile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + ProfileControl.profiles.profile[ID] + "Profile.dat", FileMode.Open);
            data = (ProfileData)bf.Deserialize(file);
            file.Close();
        }
    }

    [Serializable]
    public class ProfileData
    {
        string name;
        int ID;
        int level;
        float exp;
        bool[] planetsUnlocked = new bool[10];
        int[] deck1 = new int[5];
    }

}
