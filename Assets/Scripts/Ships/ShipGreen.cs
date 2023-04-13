using UnityEngine;

public class ShipGreen : MonoBehaviour
{
    public string nameShip = "Green";
    public float healthMax = 70;
    public float reloadFire = 0.8f;
    public float moveSpeedship = 9;

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
