using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{

    public void Save(ProfileData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/RubItPlayerProfiles.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    ProfileData Load(ProfileData data)
    {
        if (File.Exists(Application.persistentDataPath + "/RubItPlayerProfiles.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/RubitPlayerProfiles.dat", FileMode.Open);
            data = (ProfileData)bf.Deserialize(file);
            file.Close();

        }
        return data; 
    }

    [Serializable]
    public class ProfileData
    {
        string name;
        int ID;
        int level;
        float exp;
        bool[] planetsUnlocked = new bool[10];
    }

}
