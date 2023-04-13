using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteorBig : MonoBehaviour
{
    public GameObject MeteoreSmall;
    public float moveSpeedMeteorBig = 2f;
    public GameObject Babah, Oy;
    void Start()
    {
        Oy = GameObject.Find("Oy");
        Babah = GameObject.Find("Babah");
    }
    void Update()
    {
        transform.position += Vector3.left * moveSpeedMeteorBig * Time.deltaTime;
        if (transform.position.x < -10.0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
            Oy.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "Bullet")
        {
            float rnd1 = Random.Range(-1.7f, 1.7f);
            float rnd2 = Random.Range(-1.7f, 1.7f);
            Instantiate(MeteoreSmall, transform.position + new Vector3(rnd1, rnd2, 0), transform.rotation);
            Instantiate(MeteoreSmall, transform.position + new Vector3(rnd1* -1, rnd2* -1,0), transform.rotation);
            if(rnd1 >= 1.2 && rnd2 >= 1.2 || rnd1 <= 1.2 && rnd2 <= 1.2)
                Instantiate(MeteoreSmall, transform.position + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0), transform.rotation);
            Babah.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
