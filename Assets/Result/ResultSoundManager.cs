using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSoundManager : MonoBehaviour
{
    public void ClearBGMPlay()
    {
        CriAudioManager.Instance.BGM.Play("BGM", "BGM_002_result");
    }

    public void ClearVoiceSelect(int charaID, int starCount)
    {
        int voiceID = 0;
        if (starCount == 5) voiceID = 1;
        else if (starCount == 4) voiceID = 2;
        else if (starCount == 3) voiceID = 3;
        else if (starCount == 2) voiceID = 4;
        else if (starCount == 1) voiceID = 5;
        if (voiceID != 0)
        {
            CriAudioManager.Instance.BGM.Play($"unit{charaID}", $"VOICE09_result{charaID}_{voiceID}");
        }
    }
}
