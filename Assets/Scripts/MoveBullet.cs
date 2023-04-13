using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float moveSpeedBullet = 15.0f;
    void Update()
    {
        transform.position += Vector3.right * moveSpeedBullet * Time.deltaTime;
        if (transform.position.x > 10.0f)
            Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

