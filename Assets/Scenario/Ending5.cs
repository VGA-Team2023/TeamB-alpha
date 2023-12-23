// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Ending5 : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [FadeScreen,0,1]
                    [EndGroup]

                    [SoundBGM,BGM,BGM_005_scenario3,1.0]

                    [ChangeCaption,ルナ]
                    [PrintText,燃える空の下、私は元の世界への思いを馳せていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（この世界も地球と同じように、夜は訪れるんだよね…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（ここは地球と似ているけれど、魔獣の姿やサイラスさんたちの術はどう考えても地球ではあり得ないし…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（私はどうしてこんなところに来てしまったんだろう。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,それに…どうしてこの魔石を私は持っていたのか…。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そう思い、胸元できらびやかに光る魔石を見つめていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,空の橙色が反射して、魔石はいつもとは違う輝き方を見せる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,私は、地面から光り輝くその場所に近づくために、足を進めた。,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_1,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「大丈夫ですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（この世界は、まるで本の中の話のようで、小さい頃に見たお話に似ているような気がする。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（まさか、小さい頃に見た夢の世界にまた来ることができた…っていうことなのかな。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（だけどここは夢なんかじゃなくて、現実。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（きっと今頃、家族も心配しているだろうし。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…どうしよう。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_2,1.0]
　　　　　　　　　　[DisplayActor,5,1]
                    [ChangeCaption,サイラス]
                    [PrintText,「聞こえてます？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,突然耳元でささやかれ、びっくりして肩を上げる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,呼ばれた方を見るとサイラスがいた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「ごめんなさい、サイラスさん。呼ばれてたの気が付かなかったです。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_3,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「驚かせるつもりは全くなかったんです。すみません…。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（そういえば、私。誰にも何も言わずにここまで来ちゃったんだっけ…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（私の姿が見えなくて探してくれてたのかな、だとしたら心配かけちゃったな…。）,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_4,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「どうかしたのですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…え？」,0.1]
                   
                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_5,1.0]
 　　　　　　　　　 [ChangeCaption,サイラス]
                    [PrintText,「先ほどまで真剣に考えていたように見えたので…。何かあったのではと思いまして。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…いや、そんなことは…。」,0.1] 

　　　　　　  　　　[ChangeCaption,ルナ]
                    [PrintText,私がそう彼に伝えると、彼は表情を曇らせた,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_6,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「こう見えても結構長く生きてるんです。人が何を悩んでいるかなんてわかってしまうものなんですよ。」,0.1]
                    [EndGroup]

　　　　　　　　　　[ChangeCaption,ルナ]
　　　　　　 　　　 [PrintText,「…えっ。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（そういえば、サイラスさんはエルフだった。）,0.1]

　　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,（もしかして、今考えていることとか、私が実はこの世界の人間じゃないこととかもバレちゃってたりするのかな…！）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（だとしたらどうしよう、変な人とか思われてないかな…。）,0.1]

　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,サイラスの言葉を信じた私は、今までの心情が筒抜けだったことに焦り、目を泳がせた。,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_7,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「ふふ…冗談ですよ。今あなたが何を考えているかなんてわかりません。…ただですね…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_8,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「私とだけ共有してくれる秘密くらいあってもいいんですよ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,夕日を背に、彼はそう言って私を見た。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,その姿があまりにも幻想的でしばらく目が離せなかった。,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE12_ending5_9,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「さぁ、今日はもう遅いですから早く帰りましょう。何か悩める時にはハーブティが一番効くんですよ。」,0.1]
                    [EndGroup]

　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,そう言うとサイラスは私の手を引いて、街の中へと連れていく。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（しばらくは元の世界に戻れないかもしれないけれど、それでも、彼らと…サイラスさんと一緒にいられたらとても心強いな…。）,0.1]

                    [ChangeCaption,]
                    [PrintText,＿＿ギギギ…,0.1]

                    [ChangeCaption,]
                    [PrintText,街へ入るための門を開ける音が響く。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…あ！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,門を開けると、彼らが待っていた。,0.1]

　　　　　　　　　　[ChangeCaption,アル]
                    [BeginGroup]
                    [SoundVoice,unit1,VOICE12_ending1_10,1.0]
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「おーいおいてくぞー？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE12_ending2_11,1.0]
                    [ChangeCaption,リアム]
                    [PrintText,「何してるんですか？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE12_ending3_10,1.0]
　　　　　　　　　　[ChangeCaption,フェリ]
                    [PrintText,「おっせぇよー！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE12_ending4_10,1.0]
　　　　　　　　　　[ChangeCaption,グラウス]
                    [PrintText,「早くしろ。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit6,VOICE12_ending6_10,1.0]
　　　　　　　　　　[ChangeCaption,ケヴィン]
                    [PrintText,「まだー？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,不安なことも多いけれど、彼らがいれば乗り越えられるかもしれないと思った。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,今日からの私の居場所はここなんだと彼が教えてくれたから。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,私はまた月を見ようと空を眺める。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,先ほどよりも日が傾いた空は、うっすらと星空が見え始めていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,この世界の星空は、私が住んでいた都会の空よりも澄んでいる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（この世界の月も、地球と同じだ…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,私は地球への思いを心の奥へしまい込んで、彼らに笑顔を向けた。,0.1]

                    [ChangeCaption,]
                    [PrintText,To be continued…,0.1]

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