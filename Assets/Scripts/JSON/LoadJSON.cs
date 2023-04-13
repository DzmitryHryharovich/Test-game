using UnityEngine;
using System.IO;


public class LoadJSON : MonoBehaviour
{
    static public T LoadingJSON<T>()
    {
        PlayerJSON.Data zeroData = new PlayerJSON.Data();

        if (File.Exists(PlayerJSON.path))
        {
            T result = JsonUtility.FromJson<T>(File.ReadAllText(PlayerJSON.path));
            return result;
        }
        else
        {
            File.Create(PlayerJSON.path);
            SaveJSON.SaveFileJSON(zeroData);
        }
        return default(T);
    }
}
