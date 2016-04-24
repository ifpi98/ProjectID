using UnityEngine;
using System.Collections;
using System.IO;

public class Monster : MonoBehaviour
{

    public int hp;
    public string text;
    public bool monstersummon;
    //public string[] unitData;
    public string[,] unitData2 = new string[200,15];


    // Use this for initialization
    void Start()
    {

        hp = 50;
        SetUnitData();

    }


    void SetUnitData()
    {
        UnitParser Unit = this.GetComponent<UnitParser>();
        unitData2 = Unit._tempUD2;
        //Debug.Log(unitData2[5,12]);
    }



    // Update is called once per frame
    void Update()
    {
       
    }

    void OnGUI()
    {
        if (monstersummon == false)
        {
            GUI.Button(new Rect(10, 10, 200, 100), "HP : " + hp);
        }

        if (monstersummon == false)
        {
            GUI.Button(new Rect(10, 210, 200, 100), "Text : " + unitData2[5, 12]);
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