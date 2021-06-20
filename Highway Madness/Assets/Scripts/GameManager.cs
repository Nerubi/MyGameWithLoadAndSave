using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private float ycord = 1;
    [SerializeField] private float zcord = 8;

    public GameObject road;
    [SerializeField] private Vector3 roadPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTrees", startAfterSeconds, repeatAfterSeconds);
        InvokeRepeating("SpawnCars", startAfterSecondsCars, repeatAfterSecondsCars);
    }

    // Update is called once per frame
    void Update()
    {
        if(road.transform.position.z < -16)
        {
            Destroy(road);
            roadPosition = new Vector3(0, 0, 43);
            Instantiate(road, roadPosition, road.transform.rotation);
        }
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
        Instantiate(carsPrefabs[randomCars], carSpawn, carsPrefabs[randomCars].gameObject.transform.rotation);
    }

}
