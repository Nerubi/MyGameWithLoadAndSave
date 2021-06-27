using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] treePrefabs;
    [SerializeField] private float startAfterSeconds = 2;
    [SerializeField] private float repeatAfterSeconds = 2;
    [SerializeField] private int randomTrees;
    [SerializeField] private int randomTreesLocation;
    [SerializeField] private int minRangeTrees = 0;
    [SerializeField] private int maxRangeTrees = 4;
    [SerializeField] private float treeSpawnLeft = -0.9f;
    [SerializeField] private float treeSpawnRight = 1.7f;
    [SerializeField] private Vector3 treeSpawn;

    public GameObject[] carsPrefabs;
    [SerializeField] private float startAfterSecondsCars = 2;
    [SerializeField] private float repeatAfterSecondsCars = 1;
    [SerializeField] private int randomCars;
    [SerializeField] private int minRangeCars = 0;
    [SerializeField] private int maxRangeCars = 6;
    [SerializeField] private float maxLeftCarSpawn = -0.07f;
    [SerializeField] private float maxRightCarSpawn = 0.74f;
    [SerializeField] private float randomLeftRightForCars;
    [SerializeField] private Vector3 carSpawn;
    [SerializeField] private Vector3 powerUpSpawn;
    [SerializeField] private float randomPowerUps;

    [SerializeField] private float ycord = 1;
    [SerializeField] private float zcord = 8;

    public GameObject road;
    [SerializeField] private Vector3 roadPosition;
    [SerializeField] private float startAfterSecondsRoad = 0;
    [SerializeField] private float repeatAfterSecondsRoad = 2;

    public GameObject[] powerUpsPrefabs;


    private PlayerControl PlayerContolScript;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public GameObject GameOverText;
    public GameObject HighScoreButton;
    public GameObject RestartButton;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        HighScoreButton.SetActive(false);
        RestartButton.SetActive(false);

        InvokeRepeating("SpawnTrees", startAfterSeconds, repeatAfterSeconds);
        InvokeRepeating("SpawnCars", startAfterSecondsCars, repeatAfterSecondsCars);
        InvokeRepeating("SpawnRoads", startAfterSecondsRoad, repeatAfterSecondsRoad);
        PlayerContolScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerContolScript.playerHealth <= 0)
        {
            CancelInvoke();
            GameOverText.SetActive(true);
            HighScoreButton.SetActive(true);
            RestartButton.SetActive(true);
        }

        healthText.text = "Health: " + PlayerContolScript.playerHealth;
        coinText.text = "Coins: " + PlayerContolScript.coinsAmount;



    }


    void SpawnTrees()
    {
        randomTrees = Random.Range(minRangeTrees, maxRangeTrees);
        randomTreesLocation = Random.Range(0, 2);
        if(randomTreesLocation == 1)
        {
            treeSpawn = new Vector3(treeSpawnLeft, ycord, zcord);
        }
        else
        {
            treeSpawn = new Vector3(treeSpawnRight, ycord, zcord);
        }
        


        Instantiate(treePrefabs[randomTrees], treeSpawn, treePrefabs[randomTrees].gameObject.transform.rotation);
    }

    void SpawnCars()
    {
        randomCars = Random.Range(minRangeCars, maxRangeCars);
        randomLeftRightForCars = Random.Range(maxLeftCarSpawn, maxRightCarSpawn);
        carSpawn = new Vector3(randomLeftRightForCars, ycord, zcord);
        randomPowerUps = Random.Range(0, 2);
        Instantiate(carsPrefabs[randomCars], carSpawn, carsPrefabs[randomCars].gameObject.transform.rotation);

        if(randomCars == 1 )
        {
            if(randomPowerUps == 0)
            {
                powerUpSpawn = new Vector3 (0, 1, 10);
                Instantiate(powerUpsPrefabs[0], powerUpSpawn, powerUpsPrefabs[0].gameObject.transform.rotation);
            }

            if(randomPowerUps == 1)
            {
                powerUpSpawn = new Vector3(0.63f, 1, 10);
                Instantiate(powerUpsPrefabs[0], powerUpSpawn, powerUpsPrefabs[0].gameObject.transform.rotation);
            }
            
        }

        if(randomCars == 2)
        {
            if (randomPowerUps == 0)
            {
                powerUpSpawn = new Vector3(0, 1, 10);
                Instantiate(powerUpsPrefabs[1], powerUpSpawn, powerUpsPrefabs[1].gameObject.transform.rotation);
            }

            if (randomPowerUps == 1)
            {
                powerUpSpawn = new Vector3(0.63f, 1, 10);
                Instantiate(powerUpsPrefabs[1], powerUpSpawn, powerUpsPrefabs[1].gameObject.transform.rotation);
            }
        }
    }

    void SpawnRoads()
    {
        roadPosition = new Vector3(0.34f, 0.98f, 19);
        Instantiate(road, roadPosition, road.transform.rotation);
    }


}
