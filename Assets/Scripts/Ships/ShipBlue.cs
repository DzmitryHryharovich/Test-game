using UnityEngine;

public class ShipBlue : MonoBehaviour
{
    public string nameShip = "Blue";
    public float healthMax = 100;
    public float reloadFire = 0.9f;
    public float moveSpeedship = 7;

    void Update()
    {
        if (transform.position == new Vector3(-1, 0, 0))
        transform.Rotate(Vector3.up *Time.deltaTime * 100);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MeteoreBig")
            Camera.main.GetComponent<ControlShip>().health -= 20;
        if (other.tag == "MeteoreSmall")
            Camera.main.GetComponent<ControlShip>().health -= 10;
    }
}
