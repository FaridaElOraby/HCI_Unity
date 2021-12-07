using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text currentWord;  //currently rendered Word
    private float readingTime = 0f; //current Reading Time
    private static int round= 0;
    private static string arrayToString= "{"; //string to print array in one line

    string[] words = {
        "Meetings are fun",
        "Get home quickly",
        "Trials and errors",
         "Someone is coming",
        "Bread and butter",
        "Rights and wrongs"
}; //Array of words
    float[] readingTimeArray = new float[6]; //Array of reading time

    //Function with mouse click
    void handleClick() {
        //if there are still words to be rendered
        if(round < (words.Length -1)){
            //save time of old word
            readingTimeArray[round] = readingTime + 0f;
            readingTime = 0f;   
            round += 1;
            //change word to new word
            currentWord.text = words[round] + "";
            //Change Font Size if needed
            currentWord.fontSize = currentWord.fontSize + 20;
        }
        else if(round == (words.Length -1)){
            //save time of last word
            readingTimeArray[round] = readingTime + 0f;
            readingTime = 0f;   
            round += 1;
            //Add array elements to String to print on one line
            for(int i=0; i < readingTimeArray.Length-1 ; i++)
            {
                arrayToString = arrayToString + readingTimeArray[i] + ", ";
            }
            //add last element in array to Sting
            arrayToString = arrayToString + readingTimeArray[readingTimeArray.Length-1] + "}";
            //print String
            Debug.Log(arrayToString);
            currentWord.text = "Thank you. You are done.";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Render First Word
     currentWord.text = words[round] + "";   
    }

    // Update is called once per frame
    void Update()
    {
        //Add difference in time to readingTime
        readingTime += Time.deltaTime; 
        //Capture mouse click anywhere
        if (Input.GetMouseButtonDown(0)){
            handleClick();
        }
    }
}
