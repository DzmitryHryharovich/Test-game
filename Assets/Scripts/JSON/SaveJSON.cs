using UnityEngine;
using System.IO;

public class SaveJSON : MonoBehaviour
{
    static public void SaveFileJSON(object obj)
    {
        File.WriteAllText(PlayerJSON.path, JsonUtility.ToJson(obj));
    }
}
