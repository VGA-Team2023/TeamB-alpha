// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Prologue : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [FadeScreen,0,1]
                    [EndGroup]
                    [BeginGroup]

                    [ChangeCaption,ナレーション]
                    [PrintText, ある時、この世界の各地にミラリ・ラピスと呼ばれる大きな魔石が生まれた。,0.1]

                    [EndGroup]

　　　　　　　　　　  [DisplayActor,1,1]

                    [ChangeCaption,ナレーション]
                    [PrintText,その魔石は不思議な力でエネルギーを生み出し、人々の生活を豊かにしたのであった。,0.1]

                    [ChangeCaption,ナレーション]
                    [PrintText,やがて文明は発達し、次々と新たな発明が生まれていった。,0.1]

                    [ChangeCaption,ナレーション]
                    [PrintText,しかしその最中、マルム・ラピスと呼ばれる邪気を放つ魔石が発見される。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,そこからは魔獣が生まれ、人々に危害を与える存在になっていた。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,マルム・ラピスを恐れる者たちが多く現れるなか、魔獣に対抗するため、それをを研究する者たちも現れた。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,そしてその内の一人はマルム・ラピスを採取し、加工をすることで浄化された魔石ラピスを錬成する。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,ラピスからは魔獣が生まれず、それどころか携帯できる新たなエネルギー源として、人々の生活を更に豊かにさせた。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,ラピスを錬成した者は後に錬金術師と呼ばれ、人々から多くの憧れと尊敬を抱かれた。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,次第に錬金術師を志す者が多くあらわれ、新たな錬金術師が続々と生まれていった。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,そんな錬金術師の存在を象徴したような都市がある。その名もベネディクティア。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,ベネディクティアはミラリ・ラピスの出現から発展した場所のひとつであり、魔獣からの襲撃に対して大きな防衛力を有していた。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,東西南北にはラピスの塔が建てられ、都市の外でもエネルギーを供給、周りには壁が錬成され、魔獣による都市への進入を許さなかった。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,またベネディクティアでは錬金術師の中でも特に優秀として、民から認められたものたち、通称アルケミスタが都市の防衛を行い、魔獣は都市に近づくことさえもできなかった。,0.1]

                　　[ChangeCaption,ナレーション]
                    [PrintText,そうして都市ベネディクティアは長い間安寧を築き、更なる発展を遂げていたのであった。,0.1]

                    [ChangeCaption, ]
                    [PrintText,深夜２時、世間では草木も眠る丑三つ時…,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「…んぅ。」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（勉強机に向かっていたはずが、いつの間にか眠ってしまっていたようだ。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（大きく背伸びをすると、机に広がっているものが目に入る。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「そうだ…本を書いていたんだ。」,0.1]

                    [ChangeCaption, ]
                    [PrintText,手元には紙とペン。少し離れたところに使い古した消しゴムが転がっている。,0.1]

                    [ChangeCaption, ]
                    [PrintText,紙には深い折れ目が付いていて、二度と戻りそうにない。,0.1]

                    [ChangeCaption, ]
                    [PrintText,数か月後、多くの有名作家が輩出している大手出版社主催の小説コンクールが行われる。,0.1]

                    [ChangeCaption, ]
                    [PrintText,受賞した作品はたちまち、映画化、ドラマ化、アニメ化。瞬く間に作品の名前は世間へ知れ渡っていた。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「賞を取れればいいな…」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（ここ最近は有名作家として歴史を刻むのを夢見て、コンクールを応募するための小説を描いていた。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（今回こそはとかなり気合を入れて筆を進めていた…が、完全に息詰まっていた。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（なんでも今回のお題は”異世界”。最近流行の異世界転生系の物語は、ノベルやアニメとして紹介されることが多い。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「異世界ものかぁ…」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（私は、小さい頃不思議な夢を見たことがあった。その世界は魔石と魔獣が存在する世界。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（魔獣から人々を守るため…アルケミスタと呼ばれる強い錬金術師たちが存在していた。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（魔獣、魔石、錬金術師など…まるでファンタジーの世界に入ったような場所。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（私はその夢の微かな記憶から小説を書いてみようと試みていたが思い出せないことも多く筆が進まなかった。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「今回のお題に合っていると思ったんだけどな…」,0.1]

                    [ChangeCaption, ]
                    [PrintText,バチッ。,0.1]

                    [ChangeCaption, ]
                    [PrintText,照明の明かりが、一瞬暗くなり、また元の明るさに戻る。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「びっくりした…今度新しい照明でも買いに行こう。」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（詰まった時は一度別のことをするのも手のひとつ。）,0.1]

                    [ChangeCaption,]
                    [PrintText,帰宅したまま放置していた荷物の類が乱れて置かれている。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「夢の内容を忘れないうちにと、この時間まで放置していたんだっけ…」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「何が入っているんだろう？」,0.1]

                    [ChangeCaption, ]
                    [PrintText,ガサッ,1]


                    [ChangeCaption,プレイヤー]
                    [PrintText,（寒くなり久々に取り出したひざ丈のコート。その流れのままハンガーにかけえるためクローゼットを開けた。）,0.1]

                    [ChangeCaption, ]
                    [PrintText,ガタッ。,0.1]

                    [ChangeCaption, ]
                    [PrintText,弾みで落ちた、足元に古びた箱。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「たしかこれは小さい頃に使っていた…？」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（そういえば…小学校の卒業文集の出来を教師にほめられたのがきっかけで今もこうして文章を書いたんだっけ。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（詰まった時は原点に戻るのも手のひとつ。）,0.1]

                    [ChangeCaption, ]
                    [PrintText,箱はクローゼットにしまっていたからか埃ひとつない。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「なにが入っていたかなぁ…」,0.1]

                    [ChangeCaption,]
                    [PrintText,ガサッ。,0.1]

                    [ChangeCaption,]
                    [PrintText,中には、卒業アルバムや小学生の頃に制作した懐かしいものがたくさん入っている。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「…これって。」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（箱の一番手前に入っていたきれいに光り輝く石に目が留まった。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「この石は確か、小さい頃に例の夢から覚めた時に手に持っていたもの…？」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（なぜそんなものを持っていたのか、どこから持ってきたのか、誰かにもらったのかは全く思い出せない…）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（ただとても綺麗で魅力的に感じた幼少期の私はそれを大切に飾っていて、なにか大事なことがあるたびに持ち歩いていた。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（中学へ進級するときに石は姿を消したので、どこかでなくしてしまったものとばかり思っていた…　まさかこんなところに入ってるなんて。）,0.1]

                    [ChangeCaption, ]
                    [PrintText,石は蛍光灯の反射で青色に見えたり、紫色に見えたりしている。,0.1]

                    [ChangeCaption, ]
                    [PrintText,（小学生の頃の手にはこの石は少し大きく感じたが、今となっては意外と小さく感じるな…）,0.1]

                    [ChangeCaption,]
                    [PrintText,ところどころ荒く削られているがその加工がよりこの石をきれいに輝かせていた。,0.1]

                    [ChangeCaption,]
                    [PrintText,角度によっていろんな光を帯びて見えるが、一際きれいに輝いている部分があった。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「なんだろうこれ…？」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,覗くと、その部分からは月が見える。,0.1]

                    [ChangeCaption,]
                    [PrintText,カーテンは開けっ放しになっていた。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「今夜は満月かぁ…」,0.1]

                    [ChangeCaption,]
                    [PrintText,月は暗闇の中ででとても幻想的に光っている。気温が低く、星明りも今日はより一層綺麗に映し出されていた。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「そういえば、あの夢の日も満月が光り輝いていたっけ？」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（ふとその輝きの先が気になって、石を通して月を眺めてみる。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（石を隔ててみる月は、光の屈折により姿かたちをいくつにも変えていった。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「きれいだな…」,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（しばらく眺めていると、だんだんと輝きを増しているのか。太陽のようにまぶしく感じてきた。）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,「…っ！」,0.1]

                    [ChangeCaption,]
                    [PrintText,目を開けていられず一瞬目を閉じる。,0.1]

                    [ChangeCaption,]
                    [PrintText,目を閉じたことでさえぎられるはずの光だったが暗闇は訪れない。,0.1]

                    [ChangeCaption,]
                    [PrintText,やがて視界全体が真っ白に染まる。,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（なんだか眠くなってきた…）,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（瞼が重い…）,0.1]

                    [ChangeCaption,]
                    [PrintText,ボサッ。,0.1]

                    [ChangeCaption,]
                    [PrintText,そのまま深夜の部屋で眠り落ちるように倒れる。,0.1]

                    [ChangeCaption,???]
                    [PrintText,「光り輝く石は何色でしたか？」,0.1]

                    [ChangeCaption,???]
                    [PrintText,「目を閉じて、想像してみてください。」,0.1]

                    [BeginSelectGroup]
                    [Selectable,Selectable 1]
                    [LoadScene,SampleScene1]
                    [Selectable,Selectable2]
                    [LoadScene,SampleScene2]
                    [Selectable,Selectable3]
                    [LoadScene,SampleScene3]
                    [EndSelectGroup]
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