using UnityEngine;
using System.Collections;
using System.IO;

public class CharParser : MonoBehaviour
{
    string path;
    public string[] _charData;
    string[] _tempCD;
    public string[,] _tempCD2 = new string[200, 15];

    void Start()
    {

        path = "Assets/Resources/Datas/DataChar.txt";
        _charData = System.IO.File.ReadAllLines(path);

        if (_charData.Length > 0)
        {
            for (int i = 0; i < _charData.Length; i++)
            {
                //Debug.Log("Text : " + (i + 1).ToString() + "번째 줄.");
                //Debug.Log(_charData[i]);
            }
        }

        Debug.Log(_charData[_charData.Length - 1]);
        //_tempUD2 = new string[_charData.Length, 14];
        Parse();
         

    }

    public void Parse()
    {


        for (int i = 0; i < _charData.Length; i++)
        {

            string source = _charData[i];
            _tempCD = source.Split(',');

            for (int y = 0; y < _tempCD.Length; y++)
            {
                //Debug.Log(_tempCD.Length);
                _tempCD2[i, y] = _tempCD[y];
                //if (y == 13 && _tempCD[y] != "")
                //{ Debug.Log(_tempCD[y]); }

            }

        }

        //Debug.Log(_tempCD2[5, 11]);
        //Debug.Log(_tempCD2[5, 12]);
        //Debug.Log(_tempCD2[5, 13]);
    }



}