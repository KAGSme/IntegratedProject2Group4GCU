using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ProfileControl : MonoBehaviour {

    public static ProfileControl profiles;

    public string[] profile = new string[3];
    public bool[] isEmpty = new bool[3];

    public string mainActiveProfile;
    public string secondActiveProfile;

	/*This script is used to keep track of where a profile is stored through the name of the profile.
     *the load() function is automatically called when the the scene loads(rhe script should be in the first scene in the entire game).
     * thanks to singleton's design, this script exists through the game and can be accessed without the need of the 
     * usual unity reference methods like gameobject.find() or getcomponent<>(). 
     */ 
	void Awake () 
    {
        if (profiles == null)
        {
            DontDestroyOnLoad(gameObject);
            profiles = this;
            Load();
        }
        else if (profiles != this)
        {
            Destroy(gameObject);
        }
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/RubItPlayerProfiles.dat");
        ProfileNames data = new ProfileNames();
        for (int i = 0; i <= 2; i++) {
            data.profile[i] = profile[i];
            data.isEmpty[i] = isEmpty[i];
        }

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/RubItPlayerProfiles.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/RubitPlayerProfiles.dat", FileMode.Open);
            ProfileNames data = (ProfileNames)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i <= 2; i++) { 
                profile[i] = data.profile[i];
                isEmpty[i] = data.isEmpty[i]; 
            }

        }
    }

    [Serializable]
    public class ProfileNames
    {
       public bool[] isEmpty = new bool[3];
       public string[] profile = new string[3];
    }

}
