using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteorSmall : MonoBehaviour
{
    public float moveSpeedMeteorSmall = 3.0f;
    public GameObject Babah,Oy;
    void Start()
    {
        Oy = GameObject.Find("Oy");
        Babah = GameObject.Find("Babah");
    }
    void Update()
    {
        transform.position += Vector3.left * moveSpeedMeteorSmall * Time.deltaTime;
        if (transform.position.x < -10.0f || transform.position.y < -4.3f || transform.position.y > 4.3f)
            Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Babah.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
            Oy.GetComponent<AudioSource>().Play();
        }
    }
}
