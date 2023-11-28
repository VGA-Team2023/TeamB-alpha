namespace TeamB_TD
{
    namespace SaveData
    {
        [System.Serializable]
        public class SaveData
        {
            public int _favoriteUnitId = 0;//推しキャラのユニットID
            //public int _stageNum = 3;
            public bool[] _isClear = {false, false, false, false};//各ステージのクリア状況の配列
        }
    }
}

