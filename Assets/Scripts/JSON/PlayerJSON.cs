using UnityEngine;
using System.IO;
using System;

public class PlayerJSON : MonoBehaviour
{
    [Serializable]
    public class Data
    {
        public GameObject OShip;
        public string _name;
        public float healthMax;
        public float health;
        public float reloadFire;
        public float moveSpeedship;
        public Vector3 ShipPos;
    }
    static public string path;
    public Data data = new Data();

    void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        data = LoadJSON.LoadingJSON<Data>();
    }


    public void OnApplicationQuit()
    {
        SaveJSON.SaveFileJSON(data);
    }
}