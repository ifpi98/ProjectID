﻿using UnityEngine;
using System.Collections;

public class DataIni : MonoBehaviour {

    IniFile pIDIni;
    Monster mon;
    Game game;
    bool latestartcheck;

    // Use this for initialization
    void Start () {

        latestartcheck = false;
        pIDIni = new IniFile("ProjectID"); // ini extension appends to file name here
        

    }
	
	// Update is called once per frame
	void Update () {

        if (latestartcheck == false)
        {
            mon = GameObject.Find("GameObj").GetComponent<Monster>();
            game = GameObject.Find("GameObj").GetComponent<Game>();
            Debug.Log(game.score);
            latestartcheck = true;
        }
	
	}
        

    public void SetExpLv()
    {
        pIDIni.SetInt("Exp", game.score);
        pIDIni.SetInt("Level", game.level);        

        pIDIni.Save("ProjectID");
    }

    public int GetExp()
    {
        int exp = pIDIni.GetInt("Exp");        
        return exp;

    }

    public int GetLV()
    {
        int level = pIDIni.GetInt("Level");
        return level;
    }

}