// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Fix_Chapter2_afterbattle : MonoBehaviour
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
                    [PrintText,魔獣を倒したことで、魔石の光が消えて元の石へと姿を変えた。 ,0.1]

　　  　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,（やっぱり他に人には見えていないのか……。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（なんでなんだろう…。） ,0.1]

 　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（やっぱり何か理由があるのかな…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,その瞬間、頭に電撃が走った。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「・・・っ!」,0.1]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]
 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,（…頭が…い、痛い……。） ,0.1]

                    [BeginGroup]
                    [ChangeCaption,ルナ]
                    [PrintText,すぐに視界は真っ白になって、 そのまま私は気を失っていた。 ,0.1]
                    [FadeScreen,2,2]
                    [EndGroup]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]

                    [BeginGroup]
                    [SoundVoice,narration,VOICE13_narration_1,1.0]
                    [ChangeCaption,ナレーション]
                    [PrintText, ある時、この世界の各地にミラリ・ラピスと呼ばれる大きな魔石が生まれた。,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,narration,VOICE13_narration_5,1.0]
                　　[ChangeCaption,ナレーション]
                    [PrintText,そこからは魔獣が生まれ、人々に危害を与える存在になっていた。,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,narration,VOICE13_narration_9,1.0]
                　　[ChangeCaption,ナレーション]
                    [PrintText,ラピスを錬成した者は後に錬金術師と呼ばれ、人々から多くの憧れと尊敬を抱かれた。,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,narration,VOICE13_narration_11,1.0]
                　　[ChangeCaption,ナレーション]
                    [PrintText,そんな錬金術師の存在を象徴したような都市がある。その名もベネディクティア。,0.1]
                    [EndGroup]

　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,小さい頃に見た誰かの影がうっすらと現れる 。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（＿＿これは…、小さい頃にみた夢？）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（＿＿あれは、だれだろう？）,0.1]

 　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（あの時も誰かに助けてもらった気がする。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（その時に、彼から宝物をもらって…。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（それで＿＿＿＿）,0.1]

                    [ChangeBG,9]

                    [BeginGroup] 　　　　　　　　　
                    [FadeScreen,0,1.2]                     　　　　　　　　　　　
　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,目を開くと木製の天井が見えた。,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,どうやらまた寝てしまったみたいだ。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（まだ元の世界には戻れていないか…。）,0.1]

　　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,窓の外には夕焼けが広がっている。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（昼間はあんなに賑やかだったけど、もう夕方かー。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,窓からは城がそびえたっている。,0.1]
 　　　　　　　　　　　
　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,城の中心の大きな魔石であるミラリ・ラピスは、夜が近づくと一層輝きが増し、 天まで光を届かせていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（綺麗だな……。）,0.1]

                    [ChangeCaption,]
                    [PrintText,キュイーン…,0.1]

 　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,ミラリ・ラピスに反応したのか、首から下げていた魔石が輝きだす。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,しかし、それは魔獣の襲撃を知らせていた輝き方とは違って、とても淡く、優しく光り輝い ていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「あの光っている場所…なんだろう？」,0.1]
 　　　　　　　　　　　
　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,「何か呼ばれているような気がする。」,0.1]

                    [ChangeCaption,]
                    [PrintText,＿＿ガタッ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText, 魔石に導かれるままに外へ飛び出した。,0.1]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]

 　　　　　　　　　 [ChangeCaption,]
                    [PrintText,＿＿＿ッタッタッタッタ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,城門まで行くとなぜか警備はいない。,0.1]

                    [ChangeCaption,]
                    [PrintText,＿＿＿ギギギ ,0.1]
 　　　　　　　　　　　
　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,門を開け、城壁の外へ出ると魔石が導く場所はすぐそこだ。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（＿＿ここって。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,輝いている場所へ行くと、そこは見覚えのある場所だった。,0.1]

                    [SoundBGM,BGM,BGM_005_scenario3,1.0]

                    [ChangeBG,4]

 　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（私がこの世界に初めて来たときの場所だ。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,光り輝いているその場所は、城壁の中からも輝きが見えるほど、まっすぐに光を放つ。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,その先を見ようと、空を見上げると、ちょうどそこには月があった。,0.1]
 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,城の真ん中に立つ石の輝きと共に輝く月は幻想的に見える。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（そういえば、私がこの世界に来る前もこんな感じで月が綺麗だったような。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,地球で見ていた月と輝き方は全く一緒で、この異世界に来た私を安心させてくれる。,0.1]

 　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,（私は本当に夢の中にいるのかな…？）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,ここに来てから見たもの。それはなぜか初めての感じがしなかった…。）,0.1]

 　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（ここは昔に見た夢の中？）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,風が吹いて、髪が揺れる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そのとき、柔軟剤のにおいが鼻をかすめた。,0.1]
 　　　　　　　　　　　
　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,（私の部屋が恋しいな。 どうしたら戻れるんだろう…）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,私は、見慣れた月を眺めながら、元の世界へと思いを馳せた。,0.1]

                    [LoadScene,Scenario End]
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