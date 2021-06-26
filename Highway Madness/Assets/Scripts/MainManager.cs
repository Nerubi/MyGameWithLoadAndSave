using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    private PlayerControl playerControlScript;
    public int coinsCollected;

    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        coinsCollected = playerControlScript.coinsAmount;
    }

    private void Update()
    {
        coinsCollected = playerControlScript.coinsAmount;
    }



}
