using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] meteorites = new GameObject[6];

    void Start()
    {
        Invoke("SpawnMeterites", 1);
    }

    void SpawnMeterites()
    {
        Instantiate(meteorites[Random.Range(0,5)], meteorites[Random.Range(0, 5)].transform.position = new Vector3(10.0f, Random.Range(-4.5f, 4.5f), 0), transform.rotation);
        Invoke("SpawnMeterites", Random.Range(1, 4));
    }

}
