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
    public int coinsSaved;

    public void Save()
    {
        //create an instance of the class and save the amount of gold to 5
        coinsSaved = MainManager.Instance.coinsCollected;
        SaveObject saveObject = new SaveObject();
        saveObject.playerName = inputFieldSaved;
        saveObject.coins = coinsSaved;

        //save the class into a JSON string and print it out
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        Debug.Log(json);
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
            userText.text = saveObject.playerName;
            coinsText.text = saveObject.coins.ToString();
        }
        else
        {
            Debug.Log("No Save File Found");
        }



    }

    public void ReadStringInput()
    {
        inputFieldSaved = userInputField.text;
        userText.text = inputFieldSaved;
        coinsSaved = MainManager.Instance.coinsCollected;
        coinsText.text = coinsSaved.ToString();
        Debug.Log(inputFieldSaved); //shows the input field
    }

    //this will contain the data we wish to save
    private class SaveObject
    {
        public string playerName;
        public int coins;
    }
}
