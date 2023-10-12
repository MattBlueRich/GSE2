using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class Words : MonoBehaviour
{
    public List<string> Adjectives;
    public List<string> Nouns;
    public List<string> TransistiveVerbs;
    public TextAsset textFile;
    public TMP_Text fortuneText;
    // figure out how to get the max value of an array
    // Google Unity Random Random.range
    // learn how to define the size of an array
    //function MaxValue

    private void Awake()
    {
        LoadStrings(); //Creating a load string variable
    }

    void LoadStrings()
    {
        textFile = Resources.Load<TextAsset>("TextFiles/Adjectives"); // Loads the text file

        foreach (var myString in textFile.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            Adjectives.Add(myString.Trim());

        textFile = Resources.Load<TextAsset>("TextFiles/Nouns");

        foreach (var myString in textFile.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            Nouns.Add(myString.Trim());

        textFile = Resources.Load<TextAsset>("TextFiles/Verbs");

        foreach (var myString in textFile.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            TransistiveVerbs.Add(myString.Trim());

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) //Changes the words when the player presses the A Key (Will be removed)
        {
            fortuneText.SetText(GetRandomAdjective() + " " + GetRandomVerb() + " " + GetRandomNouns()); //printing the chosen words onto the canvas including spaces
        }
    }
    
    private string GetRandomAdjective() //Gets a random adjective from the list
    {
        var randomIndex = UnityEngine.Random.Range(0, Adjectives.Count);

        return Adjectives[randomIndex];
    }

    private string GetRandomVerb() //Gets a random verb from the list
    {
        var randomIndex = UnityEngine.Random.Range(0, TransistiveVerbs.Count); //Generates a random verb between 0 and the max amount of verbs in the text file

        return TransistiveVerbs[randomIndex]; //Prints the random verb
    }

    private string GetRandomNouns() //Gets a new noun from the list
    {
        var randomIndex = UnityEngine.Random.Range(0, Nouns.Count);

        return Nouns[randomIndex];
    }

}
