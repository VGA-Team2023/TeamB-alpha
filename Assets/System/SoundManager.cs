﻿using UnityEngine;
using CriWare;
using System.Threading.Tasks;

/// <summary>
/// CriAtomで音を再生させるSoundManager
/// </summary>
public class SoundManager// : Singleton<SoundManager>
{
    /// <summary>
    /// SE/ME用のAtomSorce
    /// </summary>
    CriAtomSource _criAtomSource;

    /// <summary>
    /// BGM用のAtomSorce
    /// </summary>
    CriAtomSource _criAtomBGMSource;

    /// <summary>
    /// BGMが切り替わるまでの時間
    /// </summary>
    float _changeSpeed = 0.5f;

    const string BGMCueSheet = "BGM";

    static public SoundManager Instance = new SoundManager();

    SoundManager() { }

    /// <summary>
    /// SoundManegerの初期設定
    /// </summary>
    /// <param name="attachment"></param>
    public void Setup(SoundManagerAttachment attachment)
    {
        _criAtomSource = attachment.AtomSource;
        _criAtomBGMSource = attachment.AtomBGMSource;
        _changeSpeed = attachment.ChangeBGMSpeed;
    }

    /// <summary>
    /// BGMの切り替えを行う
    /// </summary>
    /// <param name="cueName"></param>
    void ChangeBGM(string cueName)
    {
        _criAtomBGMSource.Stop();
        //Volumeのフェードアウト
        _criAtomBGMSource.cueName = cueName;
        _criAtomBGMSource.Play();
    }

    /// <summary>
    /// SE/MEを再生する為の関数
    /// </summary>
    /// <param name="cueSheet"></param>
    /// <param name="cueName"></param>
    public void CriAtomPlay(CueSheet cueSheet, string cueName)
    {
        if (!_criAtomSource)
        {
            Debug.Log("CriAtomSorceがありません");
            return;
        }

        //設定して再生
        _criAtomSource.cueSheet = cueSheet.ToString();
        _criAtomSource.cueName = cueName;
        _criAtomSource.Play();
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="cueName"></param>
    public void CriAtomBGMPlay(string cueName)
    {
        if (!_criAtomBGMSource)
        {
            Debug.Log("CriAtomBGMSorceがありません");
            return;
        }

        //CueSheetがBGMでなければ設定
        if (_criAtomBGMSource.cueSheet != BGMCueSheet)
            _criAtomBGMSource.cueSheet = BGMCueSheet;

        ChangeBGM(cueName);
    }

    //音停止。今後コードの更新
    public void CriAtomStop()
    {
        if (!_criAtomSource)
        {
            Debug.Log("CriAtomSorceがありません");
            return;
        }
        _criAtomSource.Stop();
    }
}

public enum CueSheet
{
    CueSheet_0,
    ME,
    SE
}
