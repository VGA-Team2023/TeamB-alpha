// 日本語対応
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public static class SoundExtensions
        {
            public static async UniTask SoundBGM(this CriAudioManager audioManager, string cueSheetName, string cueName, float volume, CancellationToken token = default)
            {
                audioManager.BGM.Play(cueSheetName, cueName, volume);
                await UniTask.CompletedTask;
            }

            public static async UniTask SoundSE(this CriAudioManager audioManager, string cueSheetName, string cueName, float volume, CancellationToken token = default)
            {
                audioManager.SE.Play(cueSheetName, cueName, volume);
                await UniTask.CompletedTask;
            }

            public static async UniTask SoundVoice(this CriAudioManager audioManager, string cueSheetName, string cueName, float volume, CancellationToken token = default)
            {
                audioManager.SE.Play(cueSheetName, cueName, volume);
                await UniTask.CompletedTask;
            }
        }
    }
}