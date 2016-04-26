using UnityEngine;
using System.Collections;
using System.IO;

public class UnitParser : MonoBehaviour
{
    string path;
    public string[] _unitData;
    string[] _tempUD;
    public string[,] _tempUD2 = new string[200, 15];


    void Start()
    {

        path = "Assets/Resources/Datas/DataUnit.txt";
        _unitData = System.IO.File.ReadAllLines(path);

        if (_unitData.Length > 0)
        {
            for (int i = 0; i < _unitData.Length; i++)
            {
                //Debug.Log("Text : " + (i + 1).ToString() + "번째 줄.");
                //Debug.Log(_unitData[i]);
            }
        }

        //Debug.Log(_unitData[_unitData.Length - 1]);
        //_tempUD2 = new string[_unitData.Length, 14];
        Parse();


    }

    public void Parse()
    {


        for (int i = 0; i < _unitData.Length; i++)
        {

            string source = _unitData[i];
            _tempUD = source.Split(',');

            for (int y = 0; y < _tempUD.Length; y++)
            {
                //Debug.Log(_tempUD.Length);
                _tempUD2[i, y] = _tempUD[y];
                //if (y == 13 && _tempUD[y] != "")
                //{ Debug.Log(_tempUD[y]); }

            }

        }

        //Debug.Log(_tempUD2[5, 11]);
        //Debug.Log(_tempUD2[5, 12]);
        //Debug.Log(_tempUD2[5, 13]);
    }



}