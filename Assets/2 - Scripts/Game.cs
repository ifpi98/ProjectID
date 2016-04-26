using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public int[] cardSlot;
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
            
            for (int i = 0; i < 5; i++)
            {
                tempnum = Random.Range(1, mon.charcount);
                //tempnum = i+1;
                //Debug.Log(mon.charcount);
                cardSlot[i] = tempnum;
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
                    Debug.LogError(i + 1);                    
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
        GUI.Button(new Rect(160, 10, 150, 100),cardSlot1);
        GUI.Button(new Rect(310, 10, 150, 100),cardSlot2);
        GUI.Button(new Rect(460, 10, 150, 100),cardSlot3);
        GUI.Button(new Rect(610, 10, 150, 100),cardSlot4);        
        GUI.Button(new Rect(10, 120, 150, 50), "Remain Turn : " + remainturncardslot0);
        GUI.Button(new Rect(160, 120, 150, 50), "Remain Turn : " + remainturncardslot1);
        GUI.Button(new Rect(310, 120, 150, 50), "Remain Turn : " + remainturncardslot2);
        GUI.Button(new Rect(460, 120, 150, 50), "Remain Turn : " + remainturncardslot3);
        GUI.Button(new Rect(610, 120, 150, 50), "Remain Turn : " + remainturncardslot4);

       
        if (Input.GetKey(KeyCode.A) || GUI.Button(new Rect(310, 250, 150, 100), "restart!"))
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
