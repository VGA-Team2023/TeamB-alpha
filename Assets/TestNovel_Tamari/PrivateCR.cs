// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class PrivateCR : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [DisplayActor,1,1]
                    [ChangeCaption,Unit1]
                    [FadeScreen,0,1]
                    [PrintText,Unit1参上,0.1]
                    [EndGroup]
                    
                    [BeginGroup]
                    [ChangeCaption,Unit2]
                    [DisplayActor,2,2]
                    [PrintText,Unit2です,0.1]
                    [SoundVoice,SE,SE_002_attack1,1.0]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [EndGroup]

                    [BeginGroup]
                    [ChangeCaption,Unit3]
                    [DisplayActor,3,0]
                    [PrintText,Unit3だ！,0.1]
                    [SoundBGM,BGM,BGM_001_battle,0.5]
                    [DarkenActor,2]
                    [EndGroup]

                    [ChangeCaption,Unit4]
                    [DisplayActor,4,1]
                    [DarkenActor,0]
                    [PrintText,Unit4ですよ,0.1]

                    [ChangeCaption,Unit5]
                    [DisplayActor,5,2]
                    [DarkenActor,1]
                    [PrintText,Unit5だよ,0.1]

                    [ChangeCaption,Unit6]
                    [DisplayActor,6,0]
                    [DarkenActor,2]
                    [PrintText,Unit6さ,0.1]

                    [ChangeCaption,Unit1.2.3]
                    [DisplayActor,1,1]
                    [DisplayActor,2,2]
                    [DisplayActor,3,0]
                    [PrintText,こんにちは！,0.1]
                    [SoundBGM,BGM,BGM_001_battle,0.5]

                    [DarkenActor,0] 
                    [DarkenActor,2]
                    [ChangeCaption,Unit1]
                    [PrintText,Stage2も頑張ってね,0.1]
                    [LoadScene,Stage 2]
                    ");

                var executable = MakeExecutable(commands);
                RunCommands(executable);
            }

            public async void RunCommands(List<List<ICommand>> executable)
            {
                var token = this.GetCancellationTokenOnDestroy();
                for (int i = 0; i < executable.Count; i++)
                {
                    UniTask[] tasks = new UniTask[executable[i].Count];
                    for (var j = 0; j < executable[i].Count; j++)
                    {
                        tasks[j] = executable[i][j].RunCommand(token);
                    }
                    await UniTask.WhenAll(tasks);
                    if (token.IsCancellationRequested) return;
                }
            }

            private List<List<ICommand>> MakeExecutable(ICommand[] commands)
            {
                bool groupFlag = false;
                List<List<ICommand>> result = new List<List<ICommand>>();
                List<ICommand> currentCollection = null;
                SelectableContainer currentSelectableContainer = null;
                TeamB_TD.NovelGameEditor5.Commands.Selectable lastSelectable = null;

                currentCollection = new List<ICommand>();
                result.Add(currentCollection);

                for (int i = 0; i < commands.Length; i++)
                {
                    var command = commands[i];

                    if (command is BeginGroup)
                    {
                        groupFlag = true;
                        command = null;
                    }
                    else if (command is EndGroup)
                    {
                        groupFlag = false;
                        command = null;
                    }
                    else if (command is BeginSelectGroup)
                    {
                        currentSelectableContainer = new SelectableContainer();
                        command = currentSelectableContainer;
                    }
                    else if (command is TeamB_TD.NovelGameEditor5.Commands.Selectable)
                    {
                        lastSelectable = command as TeamB_TD.NovelGameEditor5.Commands.Selectable;
                        command = null;
                        currentSelectableContainer.Selectables.Add(lastSelectable);
                    }
                    else if (command is EndSelectGroup)
                    {
                        lastSelectable = null;
                        currentSelectableContainer = null;
                    }

                    if (currentSelectableContainer != null && lastSelectable != null)
                    {
                        currentCollection = lastSelectable.Commands;
                    }
                    else if (!groupFlag)
                    {
                        if (currentCollection.Count != 0)
                        {
                            currentCollection = new List<ICommand>();
                            result.Add(currentCollection);
                        }
                    }

                    if (command != null) currentCollection.Add(command);
                }

                return result;
            }
        }
    }
}