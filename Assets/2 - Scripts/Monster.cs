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
    public string[,] charData2 = new string[200, 15];
    public string[,] locData2 = new string[400, 15];

    // Use this for initialization
    void Start()
    {

        hp = 50;
        SetCharData();
        SetUnitData();
        SetLocData();

    }


    void SetCharData()
    {
        CharParser Char1 = this.GetComponent<CharParser>();
        charData2 = Char1._tempCD2;
        int charcount = Char1._charData.Length;
        //Debug.Log(charData2[1, 1]);
        //Debug.Log(charcount);
    }

    void SetUnitData()
    {
        UnitParser Unit1 = this.GetComponent<UnitParser>();
        unitData2 = Unit1._tempUD2;
        int unitcount = Unit1._unitData.Length;
        //Debug.Log(unitData2[1,1]);
        //Debug.Log(unitcount);
    }

    void SetLocData()
    {
        LocalizationParser Loc1 = this.GetComponent<LocalizationParser>();
        locData2 = Loc1._tempLD2;
        int loccount = Loc1._localizationData.Length;
        //Debug.Log(locData2[1, 1]);
        //Debug.Log(loccount);
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