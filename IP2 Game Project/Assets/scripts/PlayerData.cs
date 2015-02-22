using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{

    public int profileID;
    public ProfileData data;

    void Awake()
    {
        Load(data, profileID);
    }

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
        int[] deck2 = new int[5];
        int[] deck3 = new int[5];
    }

}
