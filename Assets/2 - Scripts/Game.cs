﻿using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Game : MonoBehaviour {

    public int[] cardSlot;
    //public int[] cardSlotXXXX;
    string cardSlot0;
    string cardSlot1;
    string cardSlot2;
    string cardSlot3;
    string cardSlot4;
    int remainturncardslot0;
    int remainturncardslot1;
    int remainturncardslot2;
    int remainturncardslot3;
    int remainturncardslot4;
    bool firstcheck = false;
    bool secondcheck = false;
    Monster mon;
    int[,] unitArray;
    public List<int> madeSlotList = new List<int>();


    // Use this for initialization
    void Start ()
    {
        remainturncardslot0 = 3;
        remainturncardslot1 = 3;
        remainturncardslot2 = 3;
        remainturncardslot3 = 3;
        remainturncardslot4 = 3;
        cardSlot = new int[5];

    }
	
	// Update is called once per frame
	void Update () {


        if (firstcheck == false)
        {
            mon = GameObject.Find("GameObj").GetComponent<Monster>();
            unitArray = new int[mon.charcount, 5];
            unitArray = mon.unitData3;

            firstcheck = true;
        }

        int tempnum;

        if (secondcheck == false)
        {

            bool internalcheck = false;

            for (int i = 0; i < 5; i++)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                //if (tempnum == 69)
                //{
                //    Debug.LogError("ERROR" + tempnum);
                //}
                //Debug.Log(tempnum);
                //tempnum = i+1;
                //Debug.Log(mon.charcount);

                for (int y = 0; y < 5; y++)
                {
                    if (tempnum == cardSlot[y])
                    {
                        //Debug.LogError(y + "aaa" + tempnum);
                        cardSlot[i] = tempnum;
                        i = i - 1;
                        //Debug.Log(tempnum);
                        //cardSlotXXXX = new int[5];
                        //cardSlotXXXX = cardSlot;
                        internalcheck = true;
                        break;
                    }
                }

                if (internalcheck == false)
                {
                    cardSlot[i] = tempnum;
                }
                internalcheck = false;
                
            }

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (cardSlot[i] == cardSlot[y] && i != y)
                    {
                        Debug.LogError("ERROR");
                    }
                }

            }

            cardSlot0 = mon.charData2[cardSlot[0], 1];
            cardSlot1 = mon.charData2[cardSlot[1], 1];
            cardSlot2 = mon.charData2[cardSlot[2], 1];
            cardSlot3 = mon.charData2[cardSlot[3], 1];
            cardSlot4 = mon.charData2[cardSlot[4], 1];
            //cardSlot1 = Random.RandomRange(0, mon.charcount);
            //cardSlot2 = Random.RandomRange(0, mon.charcount);
            //cardSlot3 = Random.RandomRange(0, mon.charcount);
            //cardSlot4 = Random.RandomRange(0, mon.charcount);
            secondcheck = true;

            List<int> slotCardList = new List<int>();
            List<int> tempUnitList = new List<int>();
            //Debug.Log("initialize");

            for (int i = 0; i < 5; i++)
            { 
                slotCardList.Add(cardSlot[i]);
                //Debug.Log(slotCardList[i]);
            }

            for (int i = 0; i < mon.unitcount - 1; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (unitArray[i, y] == 0)
                    {
                        break;
                    }
                    tempUnitList.Add(unitArray[i, y]);
                    //Debug.Log(unitArray[i, y]);
                }

                bool isSubset = !tempUnitList.Except(slotCardList).Any();

                if (isSubset)
                {
                    //secondcheck = true;
                    Debug.Log(isSubset);
                    Debug.Log(i + 1);
                    madeSlotList.Add(i + 1);

                }

                tempUnitList.Clear();

                //Debug.Log("END");


            }
            slotCardList.Clear();
            
        }


    }

   


    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 150, 100), cardSlot0 );
        GUI.Button(new Rect(160, 10, 150, 100),cardSlot1
            );
        GUI.Button(new Rect(310, 10, 150, 100),cardSlot2);
        GUI.Button(new Rect(460, 10, 150, 100),cardSlot3);
        GUI.Button(new Rect(610, 10, 150, 100),cardSlot4);        
        GUI.Button(new Rect(10, 120, 150, 50), "Remain Turn : " + remainturncardslot0);
        GUI.Button(new Rect(160, 120, 150, 50), "Remain Turn : " + remainturncardslot1);
        GUI.Button(new Rect(310, 120, 150, 50), "Remain Turn : " + remainturncardslot2);
        GUI.Button(new Rect(460, 120, 150, 50), "Remain Turn : " + remainturncardslot3);
        GUI.Button(new Rect(610, 120, 150, 50), "Remain Turn : " + remainturncardslot4);

        if (madeSlotList.Count != 0)
        {
            mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str = new StringBuilder();
            str.Append(mon.unitData2[madeSlotList[0] + 1, 1]);
            str.AppendLine();            
            str.Append(mon.unitData2[madeSlotList[0] + 1, 9]);
            str.AppendLine();
            str.Append(mon.unitData2[madeSlotList[0] + 1, 10]);
            str.AppendLine();
            str.Append(mon.unitData2[madeSlotList[0] + 1, 11]);
            str.AppendLine();
            str.Append(mon.unitData2[madeSlotList[0] + 1, 12]);
            str.AppendLine();
            str.Append(mon.unitData2[madeSlotList[0] + 1, 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            GUI.Button(new Rect(285, 300, 200, 100), str.ToString());
        }

        if (Input.GetKey(KeyCode.A) || GUI.Button(new Rect(310, 200, 150, 100), "restart!"))
        {
            secondcheck = false;
        }
        //
        //        if (gameover == true && hp != 0)
        //        {
        //            if (GUI.Button(new Rect(10, 110, 200, 200), "Victory"))
        //           {
        //                Application.LoadLevel(Application.loadedLevel);
        //            }
        //        }
    }
}
