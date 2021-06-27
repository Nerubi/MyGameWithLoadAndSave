using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveAndLoadHighScore : MonoBehaviour
{
    //used for input field
    public TMP_InputField userInputField;
    public TextMeshProUGUI userText;
    public TextMeshProUGUI coinsText;
    private string inputFieldSaved;
    [SerializeField] private int coinsCompare;
    public int coinsSaved;


    public void Awake()
    {
        Load();
    }
    public void Save()
    {
        //create an instance of the class and save the amount of gold to 5
        coinsSaved = MainManager.Instance.coinsCollected;
        SaveObject saveObject = new SaveObject();
        saveObject.playerName = inputFieldSaved;
        saveObject.coins = coinsSaved;

        if (coinsSaved > coinsCompare)
        {
            //save the class into a JSON string and print it out
            string json = JsonUtility.ToJson(saveObject);
            File.WriteAllText(Application.dataPath + "/save.txt", json);
            Debug.Log(json);
        }
        else
        {
            userText.text = "You did not make it past the highscore";
            coinsText.text = "Better luck next time!";
        }
    }

    public void ResetScore()
    {
        SaveObject saveObject = new SaveObject();
        saveObject.coins = 0;
        saveObject.playerName = "No Player";

        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);

        userText.text = "Highscore Reset to No Player";
        coinsText.text = "Coins reset to 0";

    }

   public  void Load()
    {
        //load from file (the class) from a JSON string

        /*
        string json = JsonUtility.FromJson(saveObject);
        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.goldAmount);
        */

        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            userText.text = "Player: " + saveObject.playerName;
            coinsText.text = "Coins: " + saveObject.coins.ToString();
            coinsCompare = saveObject.coins;
        }
        else
        {
            userText.text = "No Player holds the highest score yet";
            coinsText.text = "Coins: 0";
            Debug.Log("No Save File Found");
        }

    }


    public void ReadStringInput()
    {
        inputFieldSaved = userInputField.text;
        userText.text = "Player: " + inputFieldSaved;
        coinsSaved = MainManager.Instance.coinsCollected;
        coinsText.text = "Coins: " + coinsSaved.ToString();
        Debug.Log(inputFieldSaved); //shows the input field
        
    }

    //this will contain the data we wish to save
    public class SaveObject
    {
        public string playerName;
        public int coins;
    }
}
