using UnityEngine;
using System.Collections;
using System.IO;

public class LocalizationParser : MonoBehaviour
{
    string path;
    public string[] _localizationData;
    string[] _tempLD;
    public string[,] _tempLD2 = new string[400, 15];

    void Start()
    {

        path = "Assets/Resources/Datas/DataLocalization.txt";
        _localizationData = System.IO.File.ReadAllLines(path);

        if (_localizationData.Length > 0)
        {
            for (int i = 0; i < _localizationData.Length; i++)
            {
                //Debug.Log("Text : " + (i + 1).ToString() + "번째 줄.");
                //Debug.Log(_localizationData[i]);
            }
        }

        Debug.Log(_localizationData[_localizationData.Length - 1]);
        //_tempLD2 = new string[_localizationData.Length, 14];
        Parse();


    }

    public void Parse()
    {


        for (int i = 0; i < _localizationData.Length; i++)
        {

            string source = _localizationData[i];
            _tempLD = source.Split(',');

            for (int y = 0; y < _tempLD.Length; y++)
            {
                //Debug.Log(_tempLD.Length);
                _tempLD2[i, y] = _tempLD[y];
                //if (y == 13 && _tempLD[y] != "")
                //{ Debug.Log(_tempLD[y]); }

            }

        }

        //Debug.Log(_tempLD2[5, 11]);
        //Debug.Log(_tempLD2[5, 12]);
        //Debug.Log(_tempLD2[5, 13]);
    }



}







