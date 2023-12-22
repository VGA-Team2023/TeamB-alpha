using System.IO;
using UnityEngine;
using TeamB_TD;
using TeamB_TD.SaveData;


namespace TeamB_TD
{
    namespace SaveData
    {
        public class DataManager
        {
            static private DataManager _instance = new DataManager();

            static public DataManager Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new DataManager();
                    }
                    return _instance;
                }
            }

            private SaveData _pData;
            string _filepath;
            public static string _fileName = "SaveData.json";
            public static string _json;

            public SaveData PlayerData => _pData;

            public static string GetPDataFileName()
            {
                return _fileName;
            }
            public static string GetPDataJson()
            {
                return _json;
            }
            public void Initialize()
            {
                _pData = new SaveData();    
                _filepath = Application.streamingAssetsPath + "/SaveData/" + _fileName;

                if (!File.Exists(_filepath))
                {
                    Save(_pData);
                }
                _pData = Load();
            }
            public void Save(SaveData data)
            {
                _json = JsonUtility.ToJson(data);

                StreamWriter wr = new StreamWriter(_filepath, false);                
                wr.WriteLine(_json);
                wr.Flush();
                wr.Close();
                _pData = Load();
            }
            //public SaveData Load(string path) //セーブデータを複数取り扱う場合はDictionary
            //{
            //    StreamReader rd = new StreamReader(path);
            //    _json = rd.ReadToEnd();
            //    rd.Close();

            //    return JsonUtility.FromJson<SaveData>(_json);
            //}
            public SaveData Load()
            {
                StreamReader rd = new StreamReader(_filepath);
                _json = rd.ReadToEnd();
                rd.Close();

                return JsonUtility.FromJson<SaveData>(_json);
            }
            public void Reset()
            {
                SaveData memory = Load();
                for (int i = 0; i < memory._isClear.Length; i++)
                {
                    memory._isClear[i] = false;
                }
                memory._favoriteUnitId = 0;
                Save(memory);
            }

            // 以下デバッグ用
            // TODO:機能整い次第削除
            public void OverWrite(int stagenum) //特定のステージのクリア状況を変更する
            {
                SaveData memory = Load();
                for (int i = 0; i < stagenum + 1; i++)
                {
                    memory._isClear[i] = true;
                }
                Save(memory);
            }
            public void OverWriteAll()
            {
                SaveData memory = Load();
                for (int i = 0; i < memory._isClear.Length; i++)
                {
                    memory._isClear[i] = true;
                }
                Save(memory);
            }
            public void ChangeFavchar(int num)
            {
                SaveData memory = Load();
                memory._favoriteUnitId = num;
                Save(memory);
            }          
            
        }
    }
}

    





