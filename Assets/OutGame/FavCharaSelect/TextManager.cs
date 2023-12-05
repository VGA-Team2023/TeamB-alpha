using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


namespace TeamB_TD
{
    namespace OutGame
    {
        public class TextManager : MonoBehaviour
        {
            [SerializeField] DecideListener _dl;
            [SerializeField] TextMeshProUGUI _catchPhraseText;
            [SerializeField] TextMeshProUGUI _charNameText;
            [SerializeField] TextMeshProUGUI _backBornText;
            [SerializeField] TextAsset _csvFile;
            List<string[]> _csvDatas = new List<string[]>();
            int _currentNum;
            
            public static string _fileName = "unitProfileCSV";
            void Start()
            {
                _currentNum = _dl.GetNumber;
                StringReader reader = new StringReader(_csvFile.text);                           

                while (reader.Peek() != -1)
                {
                    string data = reader.ReadLine();
                    _csvDatas.Add(data.Split(','));
                }
            }

            void Update()
            {
                _currentNum = _dl.GetNumber;                
                _catchPhraseText.text = _csvDatas[_currentNum][1];
                _charNameText.text = _csvDatas[_currentNum][2];
                _backBornText.text = _csvDatas[_currentNum][3];                
            }
        }
    }
}
