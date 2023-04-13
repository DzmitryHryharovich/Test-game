using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class ControlShip : MonoBehaviour
{
    public GameObject Ship;
    public Text healthText;
    public Image Health;
    public GameObject bullet;
    public float health;
    float healthMax;
    Vector3 shipPos,touchPos;
    public float reloadFire;
    public float moveSpeedship;
    public float shipSize = 10;
    bool isFire;
    bool isFireReloadReady = true;
    bool shipAreaTouch;
    PlayerJSON playerJSONScript;
    public AudioSource shoot;
    public static Event damage;

    void Start()
    {
        playerJSONScript = GetComponent<PlayerJSON>();
        LoadJSON.LoadingJSON<PlayerJSON.Data>();
        Instantiate(playerJSONScript.data.OShip, playerJSONScript.data.ShipPos, transform.rotation);
        Ship = GameObject.FindWithTag("Ship");
        healthMax = playerJSONScript.data.healthMax;
        health = playerJSONScript.data.health;
        shipPos = playerJSONScript.data.ShipPos;
        reloadFire = playerJSONScript.data.reloadFire;
        moveSpeedship = playerJSONScript.data.moveSpeedship;
    }
    public void ButtonFireStart()
    {
        if (isFireReloadReady) Fire();//либо отзонить, либо переделать
    }
    public void Fire()
    {
        Instantiate(bullet, Ship.transform.position + Vector3.right, bullet.transform.rotation);
        isFireReloadReady = false;
        Invoke("FireReloadReady",reloadFire);
    }
    public void FireReloadReady()
    {
        isFireReloadReady = true;
    }

    public void ButtonExit()
    {
        SaveJSON.SaveFileJSON(playerJSONScript.data);
        SceneManager.LoadScene("MainMenu");
    }
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            Vector2 Control = Camera.main.ScreenToWorldPoint(new Vector2(x, y));
            Ship.transform.position = Vector3.MoveTowards(Ship.transform.position, Control, Time.deltaTime * moveSpeedship);
        }

        Health.fillAmount = health/healthMax;
        healthText.text = "" + health;
        if (health <= 0)
        {
            GameObject.Find("Oy").GetComponent<AudioSource>().Play();
            SaveJSON.SaveFileJSON(playerJSONScript.data);
            SceneManager.LoadScene("MainMenu");
        }

        playerJSONScript.data.health = health;
        playerJSONScript.data.ShipPos = Ship.transform.position;
    }
}
