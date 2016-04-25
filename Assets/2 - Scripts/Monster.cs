using UnityEngine;
using System.Collections;
using System.IO;

public class Monster : MonoBehaviour
{

    //public string[] unitData;
    public string[,] unitData2 = new string[200,15];
    public string[,] charData2 = new string[200, 15];
    public string[,] locData2 = new string[400, 15];
    public int charcount;
    public int unitcount;
    public int loccount;

    // Use this for initialization
    void Start()
    {

        SetCharData();
        SetUnitData();
        SetLocData();

    }


    void SetCharData()
    {
        CharParser Char1 = this.GetComponent<CharParser>();
        charData2 = Char1._tempCD2;
        charcount = Char1._charData.Length;
        //Debug.Log(charData2[1, 1]);
        //Debug.Log(charcount);
    }

    void SetUnitData()
    {
        UnitParser Unit1 = this.GetComponent<UnitParser>();
        unitData2 = Unit1._tempUD2;
        unitcount = Unit1._unitData.Length;
        //Debug.Log(unitData2[1,1]);
        //Debug.Log(unitcount);
    }

    void SetLocData()
    {
        LocalizationParser Loc1 = this.GetComponent<LocalizationParser>();
        locData2 = Loc1._tempLD2;
        loccount = Loc1._localizationData.Length;
        //Debug.Log(locData2[1, 1]);
        //Debug.Log(loccount);
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    

}