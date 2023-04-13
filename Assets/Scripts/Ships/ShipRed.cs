using UnityEngine;

public class ShipRed : MonoBehaviour
{
    public string nameShip = "Red";
    public float healthMax = 140;
    public float reloadFire = 1.0f;
    public float moveSpeedship = 5;

    void Update()
    {
        if (transform.position == new Vector3(-1, 0, 0))
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MeteoreBig")
            Camera.main.GetComponent<ControlShip>().health -= 20;
        if (other.tag == "MeteoreSmall")
            Camera.main.GetComponent<ControlShip>().health -= 10;
    }
}
