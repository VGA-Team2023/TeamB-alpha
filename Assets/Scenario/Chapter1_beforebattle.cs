// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Chapter1_beforebattle : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [FadeScreen,0,1]

                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE04_attack1,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「リアム！まだいけるか？」,0.05]
                    [EndGroup]

                    [BeginGroup]                    
                    [ChangeCaption,？？？]
                    [PrintText,「当たり前です。私じゃなくて自分の心配をしてください。」,0.05]
                    [SoundVoice,unit1,VOICE04_attack1,1.0]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（…何か声が聞こえる。),0.1]

                    [BeginGroup]
                    [ChangeCaption,？？？]
                    [PrintText,「フェリくん、このポーションを！,0.05]
                    [SoundVoice,unit5,VOICE05_damage5,1.0]
                    [EndGroup]

                    [BeginGroup]
                    [ChangeCaption,？？？]
                    [PrintText,「…くっ」,0.05]
                    [SoundVoice,unit3,VOICE04_attack3,1.0]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（誰かが戦っている…？）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（うーん……。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,燦々とした日差しが目をつむっている瞼の隙間に入る。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（眩しい…。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,時間帯は昼間あたりだろうか。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,ぽかぽかとした日光が浴びているせいか、体は温かい。,0.1]

                    [BeginGroup]
                    [ChangeCaption,？？？]
                    [PrintText,「なんだこの数…！なんでこんなにいるんだよ！」 ,0.1]
                    [SoundVoice,unit3,VOICE11_scenario3_9,1.0]
                    [EndGroup]  

                    [ChangeCaption,ルナ]
                    [PrintText,先ほどよりもはっきりとした形で耳に入ってくる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（やっぱりどこかで誰かが戦っている…？）,0.1]

                    [BeginGroup]
                    [ChangeCaption,？？？]
                    [PrintText,「そっち行ったぞ。一匹も通すな！」,0.1]
                    [SoundVoice,unit4,VOICE05_damage4,1.0]
                    [EndGroup]  

                    [BeginGroup]
                    [ChangeCaption,？？？]
                    [PrintText,「へーい…」,0.1]
                    [SoundVoice,unit6,VOICE11_scenario6_8,1.0]
                    [EndGroup]  

                    [ChangeCaption,ルナ]
                    [PrintText,寝ている場合ではないとゆっくりと体を起こす。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,＿＿カサッ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（？？！　草むらの上…？） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…っ」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,重く感じる瞼を開くと緑色が目に入った。 草特有のにおいが鼻をかすめる。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（あれ…ここはどこだろう…） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,まだ頭が働いていないせいか、状況を理解できない。,0.1]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]

                    [ChangeCaption,ルナ]
                    [PrintText,（たしか…昨日は家に帰ってからすぐに小説を書き始めて…）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（気が付いたら寝てしまって、 目が覚めたら夜中だったんだっけ…） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（それで確か、箱にあった石を…）,0.1]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE04_attack1,1.0]
                    [DisplayActor,1,1]
                    [ChangeCaption,？？？]
                    [PrintText,「はあっ！！」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,先ほどよりも近くで声が聞こえた。 草の間から顔を出し、声がした方向を見る… ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE03_craft2,1.0]
                    [DisplayActor,2,2]
                    [ChangeCaption,？？？]
                    [PrintText,「大分減ってきましたね・・・。このまま一気に終わらせますよ！」,0.1]
                    [DarkenActor,1]
                    [EndGroup]

                    [ChangeCaption,獣]
                    [PrintText,「グルル…」,0.1]

                    [BeginGroup]
                    [DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「アル！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE03_craft1,1.0]
                    [DisplayActor,1,1]
                    [ChangeCaption,？？？]
                    [PrintText,「任せろ！」,0.1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [EndGroup]

                    [ChangeCaption,]
                    [PrintText,ザシュッ,0.1]

                    [DarkenActor,0]
                    [DarkenActor,2]
                    [DisplayActor,6,1]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_7,1.0]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [DisplayActor,6,1]
                    [ChangeCaption,？？？]
                    [PrintText,「…ッチ、めんどくさ…。」,0.1]
                    [EndGroup]

                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DisplayActor,5,2]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_8,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「ケヴィンくん、集中しなさい。」,0.1]
                    [EndGroup]

                    [ChangeCaption,]
                    [PrintText,ダンッ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE04_attack4,1.0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [DisplayActor,4,0]
                    [ChangeCaption,？？？]
                    [PrintText,「今だ！」,0.1]
                    [EndGroup]

                    [ChangeCaption,]
                    [PrintText,そこには６人の青年が、動物と思わしき何かと戦っている。,0.1]


                    [BeginGroup]
                    [SoundVoice,unit6,VOICE03_craft6,1.0]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…準備できた。ほらよっ」,0.1]
                    [EndGroup]

                    [ChangeCaption,]
                    [PrintText,ドゴンッ,0.1]

                    [ChangeCaption,プレイヤー]
                    [PrintText,（大砲…？）,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE04_attack5,1.0]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DisplayActor,5,2]
                    [ChangeCaption,？？？]
                    [PrintText,「ハッ！」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,(剣、銃、ナイフに斧、弓とブーメラン...?) ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼らはそれらの武器を器用に使いこなして戦っていた。,0.1]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_12,1.0]
                    [DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「このままいけば魔石を守り切れるはずだ！」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（…魔石？） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,よく見ると彼らが立つ背後には大きな石みたいなものがそびえたっていた。 どうやらその大きな石を守るために魔獣と戦っているようだ。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（あれ！あの石って…） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,あたりを見渡す。 寝ていた場所のそばに転がっているものがある。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「あった…！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「っ！」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,石を拾い上げた瞬間、石は突然点滅したように光り始めた。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（なんで急に点滅し出したんだろう…）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…えっ！？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼らの背後にあった大きい石も手の中にある石とまるで共鳴するように点滅していた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（さっきまでは光ってなかったのに…なんで。）,0.1]

                    [BeginGroup]
                    [DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「…何とか乗り切れましたね。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,その瞬間に大きな石も、手にしていた石も点滅が鎮まり、元の石の輝きに戻った。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（…一体何だったんだろう？） ,0.1]

                    [BeginGroup]
                    [DisplayActor,3,1]       
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「ああ～～、やっと終わった！」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,戦いを終えたらしく彼らは戦いの疲れをほぐしている。 ,0.1]


                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_9,1.0]
                    [DisplayActor,1,0]       
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「・・・なあ、気のせいか敵の数が多くなかったか？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_12,1.0]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DisplayActor,2,2]
                    [ChangeCaption,？？？]
                    [PrintText,「気のせいではないと思いますよ。今日はいつもと何かが違うようです。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,3,1]       
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「あー、疲れた。もうさっさと帰ろうぜ。」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,徐々に彼らはこちらの方向へ近づいてきた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（まずい、このままだと見つかってしまう！）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（制服のままだし、どう考えても不審者だと思われちゃう！）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（早くここから離れなきゃ！）,0.1]

                    [ChangeCaption,]
                    [PrintText,カサッ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,その場から離れようとする際に草木が服をかすめた。 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE12_ending4_1,1.0]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [DisplayActor,4,1]
                    [ChangeCaption,？？？]
                    [PrintText,「待て….。おい、そこにいるのは誰だ」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（き、気づかれた…？。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（なんとか風の音だと勘違いしてくれないかな…。） ,0.1]

                    [ChangeCaption,？？？]
                    [PrintText,「…おい。誰かいんだろ、出てこい。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE01_summon4,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「出てこねぇなら…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [DisplayActor,1,0]
                    [ChangeCaption,？？？]
                    [PrintText,「なっ、待てよグラウスさん！何も敵だと決まったわけじゃないだろ？」 ,0.05]
                    [EndGroup]


                    [DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_11,1.0]
                    [DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「そうですね、そんな言い方をしては出るに出られなくなってしまうじゃないですか。」,0.1]
                    [EndGroup]

                    [DisplayActor,6,1]
                    [DarkenActor,0]
                    [DarkenActor,2]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_3,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「居た。こんなところで何してるの。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「うわぁ！！！」,0.1]

                    [ChangeCaption,]
                    [PrintText,カサッ,0.1]

                    [BeginGroup]
                    [DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「ケヴィンくん…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,6,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「いいじゃん、見つかったんだから。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「誰だコイツ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [SoundVoice,unit4,VOICE11_scenario4_9,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「…ここは立入禁止区域だ。一人でそんな場所に隠れて、見つかったら困ることでもあんのか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…！い、いえ私そんなつもりではなくて…！」,0.1]

                    [BeginGroup]
                    [DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「グラウスくん、言い方を改めましょう。彼女怖がってますから。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_12,1.0]
                    [ChangeCaption,？？？]
                    [PrintText,「でもさ、コイツスッゲー変な格好してんじゃん。」,0.1]
　　　　　　　　　　[DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,6,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「まあ、都市では見たことない顔だよねー…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「あんた皆の顔知ってんの…？」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,6,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「う～わ、生意気…。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_9,1.0]
　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…だけど、敵意は無さそうだし、少しくらい話を聞いてあげてもいいんじゃないか？」,0.1]              
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,4,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「…ったく。甘ぇんだよ、お前は。」,0.1]
                    [EndGroup]


                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_11,1.0]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「そうですね。今回はグラウスさんの言うことが最もだと思いますよ。」,0.1]              
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「リアム。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「危険区域なのにも関わらず、一般人が、しかも女性が護衛もつけずに城壁の外に出るなんて、おかしな人でしょう？」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…その、えっと…」 ,0.1]

                    [ChangeCaption,？？？]
                    [PrintText,「通行許可証は持っていますか？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…。」,0.1]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「お、おいリアム…っ」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（なんて答えればいいんだろう…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（私はこの世界の者ではないです…とか、夢の中の世界なんです…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（駄目だ、答えられない。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…あの…それは。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「気づいたらここにいて…。」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「気づいたら？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「自分ではここに来ていないということですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…そうです。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_8,1.0]
　　　　　　　　　  [DisplayActor,4,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「自分ではここに来てないにしろ、許可なく城壁を出ることは違反行為だぞ。…ったく門番のやつらは何してやがんだ。」,0.1]              
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「いや、その…。」,0.1]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…なんだか色々あったみたいだな。魔獣もすぐ近くにいたから…怖かっただろ？皆、とりあえず彼女を家まで送ろう。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「どうやらその方がよさそうですね。家に行けば少しは落ち着くでしょう。話はそれから聞いても遅くはありません。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_12,1.0]
　　　　　　　　　  [DisplayActor,5,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「あなたはどちらに住まれているのですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「えーと…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…その……。」,0.1]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…もしかして、記憶がないのか？」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「あ…。」,0.1]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「確かにその可能性はありますね。言動から見ても混乱している様子ですし。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　  [DisplayActor,3,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…記憶喪失ってやつ？」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,6,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「へー、記憶喪失とか初めて見た。」 ,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,5,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「頭を強く打ってしまったのでしょうか。見たところ外傷はありませんが。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「どうしますか？アル。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「そうだな…。いったん街に戻って医者に診てもらおう。 それでいいか、グラウスさん？」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…はぁ。勝手にしろ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「やっぱり、グラウスさんってなんだかんだ言って優しいよな。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「はい。不器用、ですがね。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_1,1.0]
　　　　　　　　　　[DisplayActor,5,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「ふふ。」,0.1]              
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…うるせぇ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「あ。そういえば俺たち、君に自己紹介してなかったよな。」,0.1]
                    [EndGroup]


                    [SoundBGM,BGM,BGM_005_scenario1,0.5]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「今さらですか？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_5,1.0]
                    [ChangeCaption,アル]
                    [PrintText,「うっ…。オ、オレはアル！気軽に呼び捨てで呼んでくれ。ほら、皆も自己紹介しろよ！」,0.1]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_3,1.0]
                    [ChangeCaption,リアム]
                    [PrintText,「私はリアムです。」 ,0.1]  
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_3,1.0]
　　　　　　　　　　[DisplayActor,3,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,フェリ]
                    [PrintText,「えぇ～…。…フェリ…。」 ,0.1]              
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,？？？]
                    [PrintText,「…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [ChangeCaption,アル]
                    [PrintText,「グラウスさんも名前。彼女、待ってるだろ？」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,3,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,フェリ]
                    [PrintText,「…今アルが言っちゃったじゃん。」,0.1]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,1,0]

                    [ChangeCaption,アル]
                    [PrintText,「あ。」,0.1]

　　　　　　　　　　[DisplayActor,2,2]

                    [ChangeCaption,リアム]
                    [PrintText,「そもそも、皆さん大分前から名前で呼び合ってますけどね。」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「い、いいだろ！改めて自己紹介しても。」,0.1]
                    [EndGroup]


　　　　　　　　　　[DisplayActor,3,2]

                    [ChangeCaption,フェリ]
                    [PrintText,「しっかりしろよ～アル。」,0.1]

　　　　　　　　　　[DisplayActor,2,2]

                    [ChangeCaption,リアム]
                    [PrintText,「しっかりしてください。」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「お前ら～～っ！」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,？？？]
                    [PrintText,「ふふっ。…グラウスさん？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_1,1.0]
                    [ChangeCaption,グラウス]
                    [PrintText,「…。分かったよ。…グラウスだ。」,0.1]    
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_1,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「私はサイラスと申します。彼は…。」,0.1]      
　　　　　　　　　　[DisplayActor,5,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_3,1.0]
　　　　　　　　　　[DisplayActor,6,1]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「………ケヴィン。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…私はルナっていいます。」 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,その瞬間、また手に持っていた石が強く反応した。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…あれ、この石…また。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_7,1.0]
                    [ChangeCaption,アル]
                    [PrintText,「！！ それって、魔石…！？ なんでそんなもの…。」,0.1]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,5,2]

                    [ChangeCaption,サイラス]
                    [PrintText,「っ・・・！」 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（魔石…？）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…あっ、これは私が小さい頃からもっていたもので…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「あれ…？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,今もなお光続けている石だったが、 街の入り口にそびえたっている大きな石には先ほどのような反応はなかった。,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「どうした？」 ,0.1]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,2,1]

                    [ChangeCaption,リアム]
                    [PrintText,「もしかして、その魔石に何か反応がありましたか？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「え…？はい…光ってます。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼らにその石を見えるように差し出す。,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,3,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,フェリ]
                    [PrintText,「はぁ！？光ってる？光ってねぇだろ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,グラウス]
                    [PrintText,「お前にはこれが光って見えてんのか？」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「はい、点滅しているように見えます。でもさっきまで反応していた大きな石は点滅していないみたいで…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText, 先ほどまで点滅していた大きな石の方にも目線を送る。 ,0.1]

                    [ChangeCaption,グラウス]
                    [PrintText,「…っ！」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「これは……。」,0.1]
                    [EndGroup]


　　　　　　　　　　[DisplayActor,3,2]

                    [ChangeCaption,フェリ]
                    [PrintText,「…は！？」,0.1]


                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_12,1.0]
　　　　　　　　　　[DisplayActor,5,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「なるほど…。」,0.1]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,1,0]

                    [ChangeCaption,アル]
                    [PrintText,「…まさか。」,0.1]

　　　　　　　　　　[DisplayActor,6,2]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_9,1.0]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「…うそだろ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…え。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（なんでこんなに驚いているんだろう。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（もしかして、この光っている様子は私にしか見えない…？）,0.1]

                    [DarkenActor,1]
                    [DarkenActor,2]

                    [ChangeCaption,アル]
                    [PrintText,「ああ、ごめんな。その魔石はすごく貴重なものだから。君が持っているとは思わなくて。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_5,1.0]
　　　　　　　　　　[DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「それより、その魔石が光り出したということは都市に危険が迫っているという事です。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_5,1.0]
　　　　　　　　　　[DisplayActor,5,1]
                    [ChangeCaption,サイラス]
                    [PrintText,あなたが持っている魔石は、都市を囲う東西南北の魔石と共鳴しています。それによって、今どこに危険が迫っているかが分かるはずです。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（この石にはそんな不思議な力があるの…？） ,0.1]

                    [ChangeCaption,サイラス]
                    [PrintText,「今、その魔石がどこを指し示しているのかはあなたにしか分かりません。」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「アル。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_6,1.0]
                    [ChangeCaption,アル]
                    [PrintText,「 …分かってる。ごめん、＿＿。俺たちをそこまで案内してくれないかな？」,0.1]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,（いまでも言われていることについて、にわかには信じられない… けど…）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「は、はい！わかりました！」,0.1]

                    [BeginGroup]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,ルナ]
                    [PrintText,石の導きのまま、彼らを案内すると、そこには先ほどまで戦っていた魔物と思われる動物たちが群がっていた。,0.1]
                    [EndGroup]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]

                    [ChangeCaption,ルナ]
                    [PrintText,「動物みたいなのがあんなにたくさん…！」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,グラウス]
                    [PrintText,「あれは都市にある魔石を狙ってる魔獣だ」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE07_chapter6_1,1.0]
　　　　　　　　　　[DisplayActor,6,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「…早く倒そ」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「君は危ないから、後ろに下がってて！」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,そういわれて、私は彼らの後ろに下がる。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そうしてる間に、遠くにいたはずの魔獣が襲ってくる。,0.1]


                    [BeginGroup]
                    [SoundVoice,unit4,VOICE04_attack4,1.0]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,グラウス]
                    [PrintText,「フンッ！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE04_attack5,1.0]
　　　　　　　　　　[DisplayActor,5,1]
                    [ChangeCaption,サイラス]
                    [PrintText,八ッ！,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_9,1.0]
　　　　　　　　　　[DisplayActor,6,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「やっぱり多いなぁ…。」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_9,1.0]
　　　　　　　　　　[DisplayActor,3,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,フェリ]
                    [PrintText,「このままじゃ仕留めきれないって…！」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「！！？ ケヴィン！危ない…！」,0.05]
                    [EndGroup]


　　　　　　　　　　[DisplayActor,6,2]

                    [ChangeCaption,ケヴィン]
                    [PrintText,「うっ…！」,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,2,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,リアム]
                    [PrintText,「大丈夫ですか！？」,0.1]
                    [EndGroup]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,6,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「いってぇ・・・」,0.1]
                    [EndGroup]


                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_7,1.0]
　　　　　　　　　　[DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,グラウス]
                    [PrintText,「こいつらの動き・・・いつもと違ぇ…」,0.1]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,2,1]

                    [ChangeCaption,リアム]
                    [PrintText,「先の行動が読めません…一体どうすれば…」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（どうやらいつも以上に苦戦しているみたい。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,手に持っている石を握りしめた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,すると石が獣たちの方向へ引っ張られる。,0.1]

                    [ChangeCaption,魔獣]
                    [PrintText,＿ガルル,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,するとその引っ張られた方向から獣が現れた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,手の中にある石が強く反応した。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（もしかしたら、この石は獣に引き寄せられている…？）,0.1]

                    [BeginGroup]
                    [ChangeCaption,ルナ]
                    [PrintText,（そうなると次に獣が現れる場所は…。）,0.1]
                    [EndGroup]
  
                    [BeginGroup]
                    [ChangeCaption,ルナ]
                    [PrintText,「あっ次、上の道から来ます…！」,0.1]
                    [EndGroup]


                    [BeginGroup]
　　　　　　　　　　[DisplayActor,1,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「え…？」,0.1]
                    [EndGroup]


                    [ChangeCaption,魔獣]
                    [PrintText,「ガルル…」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_1,1.0]
　　　　　　　　　　[DisplayActor,3,2]
                    [ChangeCaption,フェリ]
                    [PrintText,「うわ！マジで魔獣が来てんじゃん！」,0.1]
                    [EndGroup]

　　　　　　　　　　[DisplayActor,2,1]

                    [ChangeCaption,リアム]
                    [PrintText,「まさか、あなた魔獣の行動を予測出来るんですか？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「え…、いえ私というか、この石がそのような反応をしていて…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そういいながら、彼らに手の中にある石を見せる。,0.1]

                    [BeginGroup]
　　　　　　　　　　[DisplayActor,5,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_1,1.0]
                    [ChangeCaption,サイラス]
                    [PrintText,「何はともあれ助かりましたよ。良かったら、次もどこから魔獣が来るのか教えてください」,0.1]
                    [EndGroup]

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