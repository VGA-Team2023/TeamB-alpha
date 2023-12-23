// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Fix_Chapter1_afterbattle : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [FadeScreen,0,1]
                    [EndGroup]

                    [SoundBGM,BGM,BGM_005_scenario1,1.0]

                    [ChangeBG,3]


                    [ChangeCaption,ルナ]
                    [PrintText,「すごい…！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼らはあっという間に魔獣たちを倒してしまった 。,0.1]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,2,1]
                    [ChangeCaption,リアム]
                    [PrintText,「どうにか凌げましたね。…それにしても、魔獣による襲撃場所と攻撃予測も出来るなんて…不思議なものですね」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「この石に引っ張られるような感覚があって…  それを従っていたらこの場所までたどり着けたんです。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_12,1.0]
　　　　　　　　　  [DisplayActor,3,0]
                    [ChangeCaption,フェリ]
                    [PrintText,「へー、すげぇ。」 ,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,5,1]
                    [DarkenActor,0]
                    [ChangeCaption,サイラス]
                    [PrintText,「やはり、その魔石の力は…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_9,1.0]
　　　　　　　　　  [DisplayActor,6,2]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「魔石の力？なんそれ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,5,1]
                    [ChangeCaption,サイラス]
                    [PrintText,「…なんでもないですよ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,3,0]
                    [ChangeCaption,フェリ]
                    [PrintText,「出たよ、サイラスいつもそうやって誤魔化す。」,0.1]
                    [EndGroup]
                    
                    [BeginGroup]
　　　　　　　　　  [DisplayActor,5,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「そんなことないですよ、フェリくん。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,3,0]
                    [DarkenActor,1]
                    [ChangeCaption,フェリ]
                    [PrintText,「うざ！」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_2,1.0]
　　　　　　　　　  [DisplayActor,1,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,アル]
                    [PrintText,「すごいなルナは。君のおかげで魔獣に勝てることが出来た。君には助けてもらったな。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「いや、そんなことは…。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_7,1.0]
　　　　　　　　　  [DisplayActor,5,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「体調とかは大丈夫ですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「あ、はい！大丈夫です！」,0.1]

                    [ChangeCaption,サイラス]
                    [PrintText,「でも、記憶なくしてるんですよね、頭とかぶつけてたりとか…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「いえ！そういったことは無いので…。」,0.1]

　　　　　　　　　  [DisplayActor,1,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,アル]
                    [PrintText,「怪我はしてないんだな？良かった。」,0.1]

　　　　　　　　　  [DisplayActor,3,0]
                    [ChangeCaption,フェリ]
                    [PrintText,「なあ、これから病院に行くんだよね？この時間だと商店街の方の町医者があいてるんじゃないか？」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_10,1.0]
　　　　　　　　　  [DisplayActor,2,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,リアム]
                    [PrintText,「当初の予定ではそうでしたが、まずはこのことを上官に報告しにいかないといけませんね。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「え？」,0.1]

　　　　　　　　　  [DisplayActor,4,2]

                    [ChangeCaption,グラウス]
                    [PrintText,「魔石のことがあるからな。」,0.1]

　　　　　　　　　  [DisplayActor,5,1]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「そうですね…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「あ…私…」,0.1]

　　　　　　　　　  [DisplayActor,1,2]

                    [ChangeCaption,アル]
                    [PrintText,「大丈夫、心配しないで。絶対に悪いようにはしないから。」,0.1]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,2,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,リアム]
                    [PrintText,「上官はいい人ですよ。あなたを取って食おうなんてことはしません。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_5,1.0]
　　　　　　　　　  [DisplayActor,6,2]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「あの人顔はいかついけどねー。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_1,1.0]
　　　　　　　　　  [DisplayActor,3,0]
                    [ChangeCaption,フェリ]
                    [PrintText,「はは、言えてる。」,0.1]
                    [EndGroup]

　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]

                    [ChangeCaption,アル]
                    [PrintText,「それに、拠点に行けば都市でも腕のいい医者に診てもらえる。服だって汚れちゃったしな。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE07_chapter4_1,1.0]
　　　　　　　　　  [DisplayActor,4,1]
                    [ChangeCaption,グラウス]
                    [PrintText,「魔獣がいつまた現れるとも限らねぇ。さっさと城壁内へ移動するぞ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,そうして彼ら錬金術師たちと拠点とする場所へ向かっていった。 ,0.1]
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