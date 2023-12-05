// 日本語対応
using Cysharp.Threading.Tasks;
using System.Threading;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class SoundVoice : ICommand
        {
            private string _cueSheetName;
            private string _cueName;
            private float _volume;

            public SoundVoice(string[] commandArgs)
            {
                _cueSheetName = commandArgs[0];
                _cueName = commandArgs[1];
                _volume = float.Parse(commandArgs[2]);
            }

            public async UniTask RunCommand(CancellationToken token = default)
            {
                var audioManager = CriAudioManager.Instance;
                await audioManager.SoundVoice(_cueSheetName, _cueName, _volume);
            }
        }
    }
}