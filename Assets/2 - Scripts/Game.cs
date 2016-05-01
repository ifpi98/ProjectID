using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Game : MonoBehaviour
{
    const int basicRemainTurn = 5;
    
    public int[] cardSlot;
    string cardSlot0;
    string cardSlot1;
    string cardSlot2;
    string cardSlot3;
    string cardSlot4;
    int[] remainturncardslot;
    public bool[] checkremainTurncardslot;
    bool firstcheck = false;
    bool secondcheck = false;
    bool thirdcheck = false;
    Monster mon;
    int[,] unitArray;
    public List<int> madeSlotList = new List<int>();
    int tempnum;
    int[] tempnumarray;
    //public Texture tex1;
    int score = 0;
    public List<int> slotCardList;


    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(Screen.width* 16 / 9, Screen.width , false);
        //Screen.SetResolution(1280, 720, false);
        remainturncardslot = new int[5];

        for (int i = 0; i < 5; i++)
        {            
            remainturncardslot[i] = basicRemainTurn;
        }        
        cardSlot = new int[5];

        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        unitArray = new int[mon.charcount, 5];
        unitArray = mon.unitData3;

        checkremainTurncardslot = new bool[5];

        for (int i = 0; i < 5; i++)
        {
            checkremainTurncardslot[i] = true;
        }

        tempnumarray = new int[5];

        while (firstcheck== false)
        { 
            for (int i = 0; i < 5; i++)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                tempnumarray[i] = tempnum;           
            }

            firstcheck = true;

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (i != y)
                    {
                        if (tempnumarray[i] == tempnumarray[y])
                        {
                            firstcheck = false;
                            Debug.Log("CHECKING");
                            break;
                        }
                        
                    }
                }
            }
            
        }

        for (int i = 0; i < 5; i++)
        {
            cardSlot[i] = tempnumarray[i];
        }
        
        secondcheck = true;
        SlotCardMaKe();

    }

 
    


    // Update is called once per frame
    void Update()
    {
                
        if (secondcheck == false && thirdcheck == false)
        {

            PassTurnWithoutMake(checkremainTurncardslot[0], checkremainTurncardslot[1],checkremainTurncardslot[2],
                checkremainTurncardslot[3],checkremainTurncardslot[4]);
            SlotCardMaKe();
            secondcheck = true;
        }


    }




    void OnGUI()
    {

        cardSlot0 = mon.charData2[cardSlot[0], 1];
        cardSlot1 = mon.charData2[cardSlot[1], 1];
        cardSlot2 = mon.charData2[cardSlot[2], 1];
        cardSlot3 = mon.charData2[cardSlot[3], 1];
        cardSlot4 = mon.charData2[cardSlot[4], 1];
        
        GUI.Button(new Rect(10, 10, 150, 100), cardSlot0);
        GUI.Button(new Rect(160, 10, 150, 100), cardSlot1);
        GUI.Button(new Rect(310, 10, 150, 100), cardSlot2);
        GUI.Button(new Rect(460, 10, 150, 100), cardSlot3);
        GUI.Button(new Rect(610, 10, 150, 100), cardSlot4);
        

        if (madeSlotList.Count != 0)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str0 = new StringBuilder();
            str0.Append(mon.unitData2[madeSlotList[0], 1]);
            str0.Append(" : ");
            str0.Append(mon.unitData2[madeSlotList[0], 9]);
            str0.Append(" ");
            str0.Append(mon.unitData2[madeSlotList[0], 10]);
            str0.Append(" ");
            str0.Append(mon.unitData2[madeSlotList[0], 11]);
            str0.Append(" ");
            str0.Append(mon.unitData2[madeSlotList[0], 12]);
            str0.Append(" ");
            str0.Append(mon.unitData2[madeSlotList[0], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 310, 770, 30), str0.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[0]);
            }
        }

        if (madeSlotList.Count > 1)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str1 = new StringBuilder();
            str1.Append(mon.unitData2[madeSlotList[1], 1]);
            str1.Append(" : ");
            str1.Append(mon.unitData2[madeSlotList[1], 9]);
            str1.Append(" ");
            str1.Append(mon.unitData2[madeSlotList[1], 10]);
            str1.Append(" ");
            str1.Append(mon.unitData2[madeSlotList[1], 11]);
            str1.Append(" ");
            str1.Append(mon.unitData2[madeSlotList[1], 12]);
            str1.Append(" ");
            str1.Append(mon.unitData2[madeSlotList[1], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 350, 770, 30), str1.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[1]);
            }
        }

        if (madeSlotList.Count > 2)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str2 = new StringBuilder();
            str2.Append(mon.unitData2[madeSlotList[2], 1]);
            str2.Append(" : ");
            str2.Append(mon.unitData2[madeSlotList[2], 9]);
            str2.Append(" ");
            str2.Append(mon.unitData2[madeSlotList[2], 10]);
            str2.Append(" ");
            str2.Append(mon.unitData2[madeSlotList[2], 11]);
            str2.Append(" ");
            str2.Append(mon.unitData2[madeSlotList[2], 12]);
            str2.Append(" ");
            str2.Append(mon.unitData2[madeSlotList[2], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 390, 770, 30), str2.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[2]);
            }

        }

        if (madeSlotList.Count > 3)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str3 = new StringBuilder();
            str3.Append(mon.unitData2[madeSlotList[3], 1]);
            str3.Append(" : ");
            str3.Append(mon.unitData2[madeSlotList[3], 9]);
            str3.Append(" ");
            str3.Append(mon.unitData2[madeSlotList[3], 10]);
            str3.Append(" ");
            str3.Append(mon.unitData2[madeSlotList[3], 11]);
            str3.Append(" ");
            str3.Append(mon.unitData2[madeSlotList[3], 12]);
            str3.Append(" ");
            str3.Append(mon.unitData2[madeSlotList[3], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 430, 770, 30), str3.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[3]);
            }

        }

        if (madeSlotList.Count > 4)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str4 = new StringBuilder();
            str4.Append(mon.unitData2[madeSlotList[4], 1]);
            str4.Append(" : ");
            str4.Append(mon.unitData2[madeSlotList[4], 9]);
            str4.Append(" ");
            str4.Append(mon.unitData2[madeSlotList[4], 10]);
            str4.Append(" ");
            str4.Append(mon.unitData2[madeSlotList[4], 11]);
            str4.Append(" ");
            str4.Append(mon.unitData2[madeSlotList[4], 12]);
            str4.Append(" ");
            str4.Append(mon.unitData2[madeSlotList[4], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 470, 770, 30), str4.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[4]);
            }

        }

        if (madeSlotList.Count > 5)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str5 = new StringBuilder();
            str5.Append(mon.unitData2[madeSlotList[5], 1]);
            str5.Append(" : ");
            str5.Append(mon.unitData2[madeSlotList[5], 9]);
            str5.Append(" ");
            str5.Append(mon.unitData2[madeSlotList[5], 10]);
            str5.Append(" ");
            str5.Append(mon.unitData2[madeSlotList[5], 11]);
            str5.Append(" ");
            str5.Append(mon.unitData2[madeSlotList[5], 12]);
            str5.Append(" ");
            str5.Append(mon.unitData2[madeSlotList[5], 13]);

            //Debug.Log(mon.unitData2[madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(madeSlotList[0]);
            if (GUI.Button(new Rect(10, 510, 770, 30), str5.ToString()))
            {
                score = score + 1;
                PassTurnWithMake(madeSlotList[5]);
            }

        }

        //if (madeSlotList.Count > 4)
        //{
        //     thirdcheck = true;

        //}

        if (madeSlotList.Count > 5 && thirdcheck == false)
        {
            thirdcheck = true;
            Debug.Log(madeSlotList.Count);
            for (int i = 5; i < madeSlotList.Count; i++)
            {
                Debug.Log(mon.unitData2[madeSlotList[i], 1]);
            }

        }

        if (Input.GetKey(KeyCode.A) || GUI.Button(new Rect(310, 200, 150, 100), "restart!"))
        {
            if (thirdcheck == false)
            {
                madeSlotList.Clear();
                secondcheck = false;
            }
        }

        GUI.Button(new Rect(100, 200, 150, 100), "Score : " + score);


        if (thirdcheck == true)
        {
            if (GUI.Button(new Rect(500, 200, 150, 100), "Restart!"))
            {
                Application.LoadLevel(Application.loadedLevel);

            }
        }

        var oldcolor = GUI.color;


        if (checkremainTurncardslot[0] == false || remainturncardslot[0] == 0)
        {
            GUI.color = Color.red;
            if (GUI.Button(new Rect(10, 120, 150, 50), "Remain Turn : " + remainturncardslot[0]))
            {
                checkremainTurncardslot[0] = !checkremainTurncardslot[0];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(10, 120, 150, 50), "Remain Turn : " + remainturncardslot[0]))
            {
                checkremainTurncardslot[0] = !checkremainTurncardslot[0];
            }
        }

        if (checkremainTurncardslot[1] == false || remainturncardslot[1] == 0)
        {
            GUI.color = Color.red;
            if (GUI.Button(new Rect(160, 120, 150, 50), "Remain Turn : " + remainturncardslot[1]))
            {
                checkremainTurncardslot[1] = !checkremainTurncardslot[1];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(160, 120, 150, 50), "Remain Turn : " + remainturncardslot[1]))
            {
                checkremainTurncardslot[1] = !checkremainTurncardslot[1];
            }
        }

        if (checkremainTurncardslot[2] == false || remainturncardslot[2] == 0)
        {
            GUI.color = Color.red;
            if (GUI.Button(new Rect(310, 120, 150, 50), "Remain Turn : " + remainturncardslot[2]))
            {
                checkremainTurncardslot[2] = !checkremainTurncardslot[2];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(310, 120, 150, 50), "Remain Turn : " + remainturncardslot[2]))
            {
                checkremainTurncardslot[2] = !checkremainTurncardslot[2];
            }
        }


        if (checkremainTurncardslot[3] == false || remainturncardslot[3] == 0)
        {
            GUI.color = Color.red;
            if (GUI.Button(new Rect(460, 120, 150, 50), "Remain Turn : " + remainturncardslot[3]))
            {
                checkremainTurncardslot[3] = !checkremainTurncardslot[3];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(460, 120, 150, 50), "Remain Turn : " + remainturncardslot[3]))
            {
                checkremainTurncardslot[3] = !checkremainTurncardslot[3];
            }
        }

        if (checkremainTurncardslot[4] == false || remainturncardslot[4] == 0)
        {
            GUI.color = Color.red;
            if (GUI.Button(new Rect(610, 120, 150, 50), "Remain Turn : " + remainturncardslot[4]))
            {
                checkremainTurncardslot[4] = !checkremainTurncardslot[4];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(610, 120, 150, 50), "Remain Turn : " + remainturncardslot[4]))
            {
                checkremainTurncardslot[4] = !checkremainTurncardslot[4];
            }
        }





    }


    void PassTurnWithoutMake(bool check0, bool check1, bool check2, bool check3, bool check4)
    {

        //bool internalcheck = false;
        bool[] checkIsExisted = new bool[5];

        if (check0 == false || remainturncardslot[0] == 0)
        {
            checkIsExisted[0] = true;
            while (checkIsExisted[0] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[0] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[0] = true;
                        break;
                    }
                }
            }
            cardSlot[0] = tempnum;
            remainturncardslot[0] = basicRemainTurn + 1;
        }

        if (check1 == false || remainturncardslot[1] == 0)
        {
            checkIsExisted[1] = true;
            while (checkIsExisted[1] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[1] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[1] = true;
                        break;
                    }
                }
            }
            cardSlot[1] = tempnum;
            remainturncardslot[1] = basicRemainTurn + 1;
        }

        if (check2 == false || remainturncardslot[2] == 0)
        {
            checkIsExisted[2] = true;
            while (checkIsExisted[2] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[2] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[2] = true;
                        break;
                    }
                }
            }
            cardSlot[2] = tempnum;
            remainturncardslot[2] = basicRemainTurn + 1;
        }

        if (check3 == false || remainturncardslot[3] == 0)
        {
            checkIsExisted[3] = true;
            while (checkIsExisted[3] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[3] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[3] = true;
                        break;
                    }
                }
            }
            cardSlot[3] = tempnum;
            remainturncardslot[3] = basicRemainTurn + 1;
        }

        if (check4 == false || remainturncardslot[4] == 0)
        {
            checkIsExisted[4] = true;
            while (checkIsExisted[4] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[4] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[4] = true;
                        break;
                    }
                }
            }
            cardSlot[4] = tempnum;
            remainturncardslot[4] = basicRemainTurn + 1;
        }

        for (int i = 0; i < 5; i++)
        {
            remainturncardslot[i] = remainturncardslot[i] - 1;
            checkremainTurncardslot[i] = true;
        }



    }

    void SlotCardMaKe()
    {
        
        slotCardList = new List<int>();
        List<int> tempUnitList = new List<int>();
        //Debug.Log("initialize");

        //slotCardList.Clear();

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
                //Debug.Log(isSubset);
                Debug.Log(i + 1);
                madeSlotList.Add(i + 1);

            }

            tempUnitList.Clear();

            //Debug.Log("END");


        }
        
    }


    void PassTurnWithMake(int decideUnit)
    {
        List<int> findMember = new List<int>();
        List<int> findMemberplace = new List<int>();
        bool[] checkMakeUnitMemberplace = new bool[5];
        //Debug.Log(decideUnit);

        for (int i = 0; i < 5; i++)
        {
            if (mon.unitData3[decideUnit, i] != 0)
            {
                findMember.Add(mon.unitData3[decideUnit-1, i]);
                Debug.Log(findMember[i]);                
            }
            else
            {
                //Debug.Log(findMember.Count);
                break;
            }
        }

        for (int i = 0; i < findMember.Count; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                //Debug.Log(slotCardList[y]);
                if (findMember[i] == slotCardList[y])
                {
                    findMemberplace.Add(y);                    
                    Debug.Log("check : " + findMemberplace[i]);
                }
                
            }            
        }

        for (int i = 0; i < 5; i++)
        {
            checkMakeUnitMemberplace[i] = true;        
            if (findMemberplace.Contains(i))
            {
                checkMakeUnitMemberplace[i] = false;
            }
        }
        
        PassTurnWithMakeCardChange(checkMakeUnitMemberplace[0], checkMakeUnitMemberplace[1], 
            checkMakeUnitMemberplace[2], checkMakeUnitMemberplace[3], checkMakeUnitMemberplace[4]);
        
        madeSlotList.Clear();
        SlotCardMaKe();        
        
    }

    void PassTurnWithMakeCardChange(bool check0, bool check1, bool check2, bool check3, bool check4)
    {

        //bool internalcheck = false;
        bool[] checkIsExisted = new bool[5];

        if (check0 == false)
        {
            checkIsExisted[0] = true;
            while (checkIsExisted[0] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[0] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[0] = true;
                        break;
                    }
                }
            }
            cardSlot[0] = tempnum;
            remainturncardslot[0] = basicRemainTurn;
        }

        if (check1 == false)
        {
            checkIsExisted[1] = true;
            while (checkIsExisted[1] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[1] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[1] = true;
                        break;
                    }
                }
            }
            cardSlot[1] = tempnum;
            remainturncardslot[1] = basicRemainTurn;
        }

        if (check2 == false)
        {
            checkIsExisted[2] = true;
            while (checkIsExisted[2] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[2] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[2] = true;
                        break;
                    }
                }
            }
            cardSlot[2] = tempnum;
            remainturncardslot[2] = basicRemainTurn;
        }

        if (check3 == false)
        {
            checkIsExisted[3] = true;
            while (checkIsExisted[3] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[3] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[3] = true;
                        break;
                    }
                }
            }
            cardSlot[3] = tempnum;
            remainturncardslot[3] = basicRemainTurn;
        }

        if (check4 == false)
        {
            checkIsExisted[4] = true;
            while (checkIsExisted[4] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[4] = false;

                    if (tempnum == cardSlot[i])
                    {
                        checkIsExisted[4] = true;
                        break;
                    }
                }
            }
            cardSlot[4] = tempnum;
            remainturncardslot[4] = basicRemainTurn;
        }       

    }



}