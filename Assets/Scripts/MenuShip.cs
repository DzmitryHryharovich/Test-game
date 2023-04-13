using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuShip : MonoBehaviour
{
    public int numberShip = 0, numberShipMax = 2, numberShipMin = 0;
    GameObject[] Ship = new GameObject[3];
    public GameObject ship;
    public Text nameShip, healthText, reloadText, moveSpeedText;
    PlayerJSON playerJSONScript;
    public GameObject Blue, Red, Green;
    public AudioSource NextPrev;

    void Start()
    {
        Ship[0] = Blue;
        Ship[1] = Red;
        Ship[2] = Green;

        playerJSONScript = GetComponent<PlayerJSON>();
        ship = Instantiate(Ship[numberShip], new Vector3(-1, 0, 0), transform.rotation);
    }
    void Update()
    {
        if (numberShip == 0)
        {
            healthText.text = "HEALTH: " + Ship[numberShip].GetComponent<ShipBlue>().healthMax;
            reloadText.text = "RELOAD: " + Ship[numberShip].GetComponent<ShipBlue>().reloadFire;
            moveSpeedText.text = "MOVE SPEED: " + Ship[numberShip].GetComponent<ShipBlue>().moveSpeedship;
            nameShip.text = "NAME: " + Ship[numberShip].GetComponent<ShipBlue>().nameShip;
        }
        if (numberShip == 1)
        {
            healthText.text = "HEALTH: " + Ship[numberShip].GetComponent<ShipRed>().healthMax;
            reloadText.text = "RELOAD: " + Ship[numberShip].GetComponent<ShipRed>().reloadFire;
            moveSpeedText.text = "MOVE SPEED: " + Ship[numberShip].GetComponent<ShipRed>().moveSpeedship;
            nameShip.text = "NAME: " + Ship[numberShip].GetComponent<ShipRed>().nameShip;
        }
        if (numberShip == 2)
        {
            healthText.text = "HEALTH: " + Ship[numberShip].GetComponent<ShipGreen>().healthMax;
            reloadText.text = "RELOAD: " + Ship[numberShip].GetComponent<ShipGreen>().reloadFire;
            moveSpeedText.text = "MOVE SPEED: " + Ship[numberShip].GetComponent<ShipGreen>().moveSpeedship;
            nameShip.text = "NAME: " + Ship[numberShip].GetComponent<ShipGreen>().nameShip;
        }
    }
    public void NextButton()
    {
        NextPrev.Play();
        Destroy(ship);
        numberShip++;
        if (numberShip == numberShipMax + 1)
            numberShip = numberShipMin;
        ship = Instantiate(Ship[numberShip], new Vector3(-1, 0, 0), transform.rotation);
    }
    public void PreviousButton()
    {
        NextPrev.Play();
        Destroy(ship);
        numberShip--;
        if (numberShip == numberShipMin - 1)
            numberShip = numberShipMax;
        ship = Instantiate(Ship[numberShip], new Vector3(-1, 0, 0), transform.rotation);
    }
    public void PlayButton()
    {
        if (numberShip == 0)
        {
            playerJSONScript.data.OShip = Blue;
            playerJSONScript.data._name = "Blue";
            playerJSONScript.data.healthMax = Ship[numberShip].GetComponent<ShipBlue>().healthMax;
            playerJSONScript.data.health = Ship[numberShip].GetComponent<ShipBlue>().healthMax;
            playerJSONScript.data.reloadFire = Ship[numberShip].GetComponent<ShipBlue>().reloadFire;
            playerJSONScript.data.moveSpeedship = Ship[numberShip].GetComponent<ShipBlue>().moveSpeedship;
            playerJSONScript.data.ShipPos = new Vector3(-8.2f, 0, 0);
            SaveJSON.SaveFileJSON(playerJSONScript.data);
            SceneManager.LoadScene("Game");
        }
        if (numberShip == 1)
        {
            playerJSONScript.data.OShip = Red;
            playerJSONScript.data._name = "Red";
            playerJSONScript.data.healthMax = Ship[numberShip].GetComponent<ShipRed>().healthMax;
            playerJSONScript.data.health = Ship[numberShip].GetComponent<ShipRed>().healthMax;
            playerJSONScript.data.reloadFire = Ship[numberShip].GetComponent<ShipRed>().reloadFire;
            playerJSONScript.data.moveSpeedship = Ship[numberShip].GetComponent<ShipRed>().moveSpeedship;
            playerJSONScript.data.ShipPos = new Vector3(-8.2f, 0, 0);
            SaveJSON.SaveFileJSON(playerJSONScript.data);
            SceneManager.LoadScene("Game");
        }
        if (numberShip == 2)
        {
            playerJSONScript.data.OShip = Green;
            playerJSONScript.data._name = "Green";
            playerJSONScript.data.healthMax = Ship[numberShip].GetComponent<ShipGreen>().healthMax;
            playerJSONScript.data.health = Ship[numberShip].GetComponent<ShipGreen>().healthMax;
            playerJSONScript.data.reloadFire = Ship[numberShip].GetComponent<ShipGreen>().reloadFire;
            playerJSONScript.data.moveSpeedship = Ship[numberShip].GetComponent<ShipGreen>().moveSpeedship;
            playerJSONScript.data.ShipPos = new Vector3(-8.2f, 0, 0);
            SaveJSON.SaveFileJSON(playerJSONScript.data);
            SceneManager.LoadScene("Game");
        }
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene("Game");
    }
}
