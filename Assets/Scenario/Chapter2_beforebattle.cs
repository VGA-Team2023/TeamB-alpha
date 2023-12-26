// 日本語対応
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TeamB_TD.NovelGameEditor5.Commands;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class Chapter2_beforebattle : MonoBehaviour
        {
            public void Start()
            {
                var commands = CommandLoader.LoadSheet(
                    @"
                    [BeginGroup]
                    [FadeScreen,0,1]
                    [EndGroup]

                    [SoundBGM,BGM,BGM_005_scenario1,1.0]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_9,1.0]
                    [DisplayActor,1,1]
                    [ChangeCaption,アル]
                    [PrintText,「＿＿というわけです…。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,都市の中へ案内された私は、記憶喪失だと疑われていたためそのまま町医者に罹った。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,ただ、医者からは特に異常なしと診断される。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（記憶はあるけど……、なんて説明したらいいんだろう。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そのまま診断は終わり、 私は彼らに連れられて都市の中の錬金術師が集まる拠点にいた。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（そもそも錬金術師ってなんだろう、凄いファンタジーな世界みたいだなぁ。） ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,しかも彼らはアルケミスタとよばれる特別な錬金術師らしく、 先ほどの戦闘のことで呼び出されていた。 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_5,1.0]
                    [DisplayActor,2,0]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「どうやら魔石には、彼女の力を持ってして働く力があるようでして。」,0.1]
                    [EndGroup]

                    [ChangeCaption,リアム]
                    [PrintText,「私たちが視認することはできませんでしたが、魔獣が現れたことを知らせる役目を持っているようです。彼女にしか見えない信号があるようです。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼らは上司らしき人物になにかを説明している。 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_12,1.0]
                    [DisplayActor,3,2]
                    [ChangeCaption,フェリ]
                    [PrintText,「あとー、あぁ記憶喪失？なんで外にいたかわからねぇんだっけ？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「え…。あ、はい！」,0.1]

                    [ChangeCaption,上司]
                    [PrintText,「…なるほどな、まさかそんなことがあったとは」 ,0.1]

                    [BeginGroup]
                    [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「にわかには信じがたいですが、実際に彼女のおかげで魔獣の進軍を退けることが できました。」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,アル]
                    [PrintText,「そして、その魔石というのが…。」 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,彼に目配せされ、意図を読み取った私はポケットの中からその”魔石”を取り出した。 ,0.1]

                    [ChangeCaption,上司]
                    [PrintText,「これが…あれか。」,0.1]

                    [ChangeCaption,アル]
                    [PrintText,「はい、恐らく。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,手にしている石をまじまじと見つめている。 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（もしかするとこの石はかなり貴重なのかな…。） ,0.1]

                    [ChangeCaption,アル]
                    [PrintText,「…なので、本来であれば市長へ報告する義務があるとは思うのですが…。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_8,1.0]
                    [DisplayActor,3,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,フェリ]
                    [PrintText,「え、てことはあいつにも報告すんの？」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,フェリ]
                    [PrintText,「あいつの秘書に会うの嫌なんだけど。」 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_7,1.0]
                    [DisplayActor,6,0]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「こないだ、すれ違った時に挨拶をしなかっただけでくどくど言われてよ、まじでめんどかった。」,0.1]
                    [EndGroup]

                    [ChangeCaption,フェリ]
                    [PrintText,「あー、おれもよく言われる。」,0.1]
 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,ケヴィン]
                    [PrintText,「なんで市長のやつあんな秘書雇ってんだよ…。」 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_11,1.0]
                    [DisplayActor,5,1]
                    [ChangeCaption,サイラス]
                    [PrintText,「こらこら、二人とも。上官の目の前ですよ。」 ,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,上司]
                    [PrintText,「…あまり言うなよ、この会話を聞かれたら首が飛ぶのは俺の方だ。」,0.1]
                    [EndGroup]

 　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（市長の秘書はかなり嫌われているみたい。） ,0.1]

                    [BeginGroup]
                    [DisplayActor,1,1]
                    [ChangeCaption,アル]
                    [PrintText,「とにかく、彼女は記憶喪失ですし、このまま放っておく訳にはいきません。 城壁の外へ出ていたことも本来であれば懲罰扱いですが、この魔石のこともあります。」,0.1]
                    [EndGroup]

                    [ChangeCaption,アル]
                    [PrintText,「みんなと相談して彼女を匿おうという結論に至ったのですが…。」 ,0.1]
 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,上司]
                    [PrintText,「そうか…、確かにその方が嬢ちゃんのためにも良いしな… 。わかった、俺からは上手く話しておく。」 ,0.1]

                    [ChangeCaption,アル]
                    [PrintText,「ありがとうございます！」 ,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,どうやらうまく説得できたようで、私は彼らと共に行動することとなった。,0.1]

 　　　　　　　 　　[ChangeCaption,]
                    [PrintText,その後、街にて…。,0.1]

                    [BeginGroup]
                    [DisplayActor,5,1]
　　 　　　　　　　 [ChangeCaption,サイラス]
                    [PrintText,「町医者で診てもらいましたが、特に外傷はなさそうで良かったですね。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [ChangeCaption,ルナ]
                    [PrintText,「はい、すみません。何から何までありがとうございました。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_8,1.0]
                    [DisplayActor,1,2]
                    [DarkenActor,1]
                    [ChangeCaption,アル]
                    [PrintText,「そうかしこまるなよ。さっきはルナに助けられたからな。むしろお礼を言うのはオレ達の方だろ？」,0.1]
                    [EndGroup]
　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,「そんな、私なんて何もしてないですよ…アルさん。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（実際には記憶喪失でも何でもないのに、心配させてしまって申し訳ないな…。）,0.1]


                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_9,1.0]
                    [ChangeCaption,アル]
                    [PrintText,「…ん～なんだかな。これから一緒に戦う仲間にさん付けは、かた苦しいよなぁ。」,0.1]
                    [EndGroup]

 　　　　　　　　　 [ChangeCaption,アル]
                    [PrintText,「…そうだ！年齢も近そうだし、もっと気楽に「アル」とか、敬語もなしにするってのはどうだ？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…え、いや。でも…。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_11,1.0]
                    [DisplayActor,2,1]
                    [DarkenActor,2]
                    [ChangeCaption,リアム]
                    [PrintText,「…アル。それは…。」,0.1]
                    [EndGroup]
 　　　　　　　　　　　
                    [BeginGroup]
                    [DisplayActor,1,2]
                    [DarkenActor,1]
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「大丈夫だって…！別に気づかれてないだろ、父さんもこの辺に来ることなんてないんだし。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_8,1.0]
                    [DisplayActor,2,1]
                    [DarkenActor,2]
                    [ChangeCaption,リアム]
                    [PrintText,「だからって...！…ちょっとこっち来て。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,2]
                    [ChangeCaption,アル]
                    [PrintText,「うわっ…、リアム、袖が伸びんだろ！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_9,1.0]
                    [DarkenActor,2]
                  　[ChangeCaption,リアム]
                    [PrintText,「伸びません。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,そういってリアムはアルを引っ張って私達とは少しを距離を取った所まで連れていく。,0.1]

                    [BeginGroup]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,ルナ]
                    [PrintText,「…大丈夫かな。」,0.1]
                    [EndGroup]


                    [BeginGroup]　　　
                    [SoundVoice,unit5,VOICE11_scenario5_1,1.0]
                    [DisplayActor,5,0]
　　　　　　　　　　[ChangeCaption,サイラス]
                    [PrintText,「…気にしなくて大丈夫ですよ、彼らはいつもあんな感じです。」,0.1]
                    [EndGroup]

                    [BeginGroup]　　　
                    [SoundVoice,unit4,VOICE11_scenario4_8,1.0]
                    [DisplayActor,4,1]
                    [DarkenActor,0]
                    [ChangeCaption,グラウス]
                    [PrintText,「…よくあれでバレねぇと思ってんな。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,0]
                    [ChangeCaption,サイラス]
                    [PrintText,「…えぇ、くく。」,0.1]
                    [EndGroup]

 　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（バレる…？何のことだろう）,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,3,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,フェリ]
                    [PrintText,「そんなことより…腹減った。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,0]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「そうですね、そろそろランチに致しましょう。何が食べたいですかフェリくん。」,0.1]
                    [EndGroup]
　　　　　　　　　　
                    [BeginGroup]
                    [SoundVoice,unit3,VOICE07_chapter3_2,1.0]
                    [DisplayActor,3,2]
                    [DarkenActor,0]
　　　　　　　　　　[ChangeCaption,フェリ]
                    [PrintText,「…肉。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,0]
                    [DarkenActor,2]
                    [ChangeCaption,サイラス]
                    [PrintText,「…お肉ですか…。ルナさん貴方はなにか食べたいものありますか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「え、わ、私は特に…。」,0.1]

　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（いろんなことが起こりすぎてお腹の事とか考えてなかったな…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そんな時。,0.1]

                    [ChangeCaption,男性]
                    [PrintText,「＿あ、お疲れ様です、グラウスさん！」,0.1]
 　　　　　　　　　　　
                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_12,1.0]
                    [DisplayActor,4,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
　　　　　　　　　　[ChangeCaption,グラウス]
                    [PrintText,「…ああ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,警察官のような恰好をした男性が、グラウスに話しかけていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,（…誰だろう、話し方的にグラウスさんの部下の方かな）,0.1]

 　　　　　　　　　　 [ChangeCaption,男性]
                    [PrintText,「…あ、失礼いたしました。現在は職務中ではなかったのですね。それでは失礼いたします。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,そういって彼は去っていった。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「あ、あの…今の方は？」,0.1]
 　　　　　　　　　　　

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_5,1.0]
                    [DisplayActor,5,0]
                    [DarkenActor,1]
                    [DarkenActor,2]
　　　　　　　　　　[ChangeCaption,サイラス]
                    [PrintText,「彼は元の職は警察官なのですよ。この都市ではかなり名の知れた方なんですよ、そうですよねグラウスくん。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,4,1]
                    [DarkenActor,0]
                    [ChangeCaption,グラウス]
                    [PrintText,「…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,0]
                    [ChangeCaption,サイラス]
                    [PrintText,「まぁ、こんな彼なので市民の方からは勘違いされがちですが。…」,0.1]
                    [EndGroup]

　　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（そっか、いつも周りを警戒しながら歩く姿は、普段の仕事柄だったのかな。）,0.1]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_3,1.0]
                    [DisplayActor,1,1]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「…皆ー、お待たせ！リアムの話が長くて。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「アル！まだ話は終わってません！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,1]
                    [DarkenActor,2] 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「もう分かったって言っただろ！ほら、皆お腹空いてそうだしご飯食べに行こうぜ！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_8,1.0]
                    [DisplayActor,2,2]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「まったく…。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE07_chapter3_3,1.0]
                    [DisplayActor,3,0]
                    [DarkenActor,2] 　　　　　　　　　　　
 　　　　　　　　　 [ChangeCaption,フェリ]
                    [PrintText,「おっせ～よ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,1]
                    [ChangeCaption,アル]
                    [PrintText,「ごめんな。でも今日は短い方だろ？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,2,2]
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,リアム]
                    [PrintText,「いつもは長いみたいな言い方やめてください。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,1]
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「悪かったって。ええっと、ここからだと…ちょうどサイラスさんの行きつけのカフェが近かったよな？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,0]
                    [ChangeCaption,サイラス]
                    [PrintText,「そうですね。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「そこにしようか。この時間帯でも穴場だし、お肉も野菜も豊富だろ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE07_chapter5_3,1.0]
                    [DisplayActor,5,0]
　　　　　　　　　　 [ChangeCaption,サイラス]
                    [PrintText,「良いんですか、それでは案内いたしますね。」,0.1]
                    [EndGroup]

                    [DarkenActor,0]
                    [DarkenActor,1]
                    [DarkenActor,2]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_5,1.0]
                    [DisplayActor,2,2]           
                    [ChangeCaption,リアム]
                    [PrintText,「ここの都市はベネディクティアと言って、見てわかるように城壁に囲まれた都市です。」,0.1]
                    [EndGroup]
           　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,リアム]
                    [PrintText,「あちらに見えるのが、都市の中心に聳える魔石。別名ミラリ・ラピスと呼ばれています。」,0.1]

                    [BeginGroup]
                    [DisplayActor,1,1]           
                    [ChangeCaption,アル]
                    [PrintText,「あれと同じ魔石が、さっきいた都市の入り口の塔にもあっただろ？いつもあの魔石を狙って魔獣が襲ってくるんだ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,昼食後、彼らにこの都市のことについて詳しく教えてもらいながら、街の中を案内してくれる。,0.1]

                    [BeginGroup]
                    [DisplayActor,3,0]           
 　　　　　　　　　 [ChangeCaption,フェリ]
                    [PrintText,「あ、あそこの角曲がったら、ケヴィンの店だよな。」 ,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「店…？どんな？」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_3,1.0]
                    [DisplayActor,6,1]           
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,ケヴィン]
                    [PrintText,「…骨董屋。アンティークショップってやつ。」,0.1]
                    [EndGroup]

　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,「…へぇ、すごい！」,0.1]

                    [BeginGroup]
                    [DisplayActor,3,0]           
                    [ChangeCaption,フェリ]
                    [PrintText,「こいつ、こう見えても手先はめちゃくちゃ器用だからな、こう見えても。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「…こう見えても？」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_11,1.0]
                    [DisplayActor,6,1]           
                    [DarkenActor,0]
 　　　　　　　　 　[ChangeCaption,ケヴィン]
                    [PrintText,「こう見えてもは余計なんだよ。そんなこと言ってるからいつまでも身長が伸びないんじゃないのか。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_5,1.0]
                    [DisplayActor,3,0]           
                    [ChangeCaption,フェリ]
                    [PrintText,「お前にだけは言われたくねぇし！！」,0.1]
                    [EndGroup]

                    [BeginGroup]
 　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,「ふふっ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,2]           
                    [ChangeCaption,サイラス]
                    [PrintText,「…良かった、ルナさんが笑ってくれて。少しは緊張は解けたようですね。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「え…。」,0.1]
 　　　　　　　　　　　
                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_1,1.0]
                    [DisplayActor,2,1]           
　　　　　　　　　　[ChangeCaption,リアム]
                    [PrintText,「そうですね。お恥ずかしいところを見せてしまいましたが、ルナさんが笑顔になってくれて良かったです。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,0]           
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「そうだよな、魔獣とか急に出てきて怖くなかったか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「そうですね、確かにびっくりしたけれど…。皆さんが守ってくれたから。」,0.1]

　　　　　　　　　　 [ChangeCaption,アル]
                    [PrintText,「グラウスさんみたいな、顔怖い人に怒鳴られて、怖くなかったか？」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…え。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_8,1.0]
                    [DisplayActor,4,2]           
                    [DarkenActor,0]
                    [DarkenActor,1]
                    [ChangeCaption,グラウス]
                    [PrintText,「…っ。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,1,0]            　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「いたっ。ちょっとグラウスさん冗談だって。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DisplayActor,5,1]            　　　　　　　　　　　
                    [ChangeCaption,サイラス]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [PrintText,「…そういえばその魔石。なんでずっと持っていたんですか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,リアム]
                    [PrintText,「確かに、ルナさんは気づいたらここにいたとおっしゃっていましたよね？」,0.1]

 　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,（なんでこの魔石を持っていたかなんて…そんなの…。）,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…それが、覚えていなくて…。」,0.1]

                    [ChangeCaption,サイラス]
                    [PrintText,「覚えていないって…。肌身離さずそんな風に。」,0.1]

                    [BeginGroup]
                    [DisplayActor,1,0]            　　　　　　　　　　　 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,まぁ、そんな前のこと覚えてなくて当然だよな。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE11_scenario2_8,1.0]
                    [DisplayActor,2,2]            　　　　　　　　　　　
                    [ChangeCaption,リアム]
                    [PrintText,「はぁ、貴方は覚えてなさすぎですが…。でもあなたの子ども時代も気になりますね。」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [DarkenActor,1]
                    [DarkenActor,2]
                    [ChangeCaption,アル]
                    [PrintText,「そうだ、その魔石それじゃ持ちにくいだろ。実はフェリは魔石を加工するのが得意なんだ。そうだよな？」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit3,VOICE11_scenario3_7,1.0]
                    [DisplayActor,3,1]            　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,フェリ]
                    [PrintText,「え、ってそんな急に…」,0.1]
                    [EndGroup]

                    [ChangeCaption,アル]
                    [PrintText,「持ちやすいように加工してやってあげたらどうだ？ポケットにいれたままじゃなにかと不便だろ。」,0.1]

                    [ChangeCaption,フェリ]
                    [PrintText,「…はぁ。ったくアルはそういうところあるよな。ほらそれ貸せよルナ。」,0.1]
 　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,ルナ]
                    [PrintText,「え、あ、うん。」,0.1]

                    [BeginGroup]
                    [DarkenActor,0]
                    [DarkenActor,2]
                    [ChangeCaption,]
                    [PrintText,＿キンキンキン,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,フェリがその魔石に穴を開け、魔石に銀色に輝く紐を通す。,0.1]

 　　　　　　　　　 [ChangeCaption,フェリ]
                    [SoundVoice,unit3,VOICE11_scenario3_3,1.0]
                    [PrintText,「ほら…。」,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「え、す、すごい！ありがとう！！！」,0.1]

                    [ChangeCaption,フェリ]
                    [PrintText,「…べ、別に頼まれただけだって。」,0.1]

                    [BeginGroup]
                    [SoundVoice,unit1,VOICE11_scenario1_1,1.0]
                    [DisplayActor,1,0]            　　　　　　　　　　　 　　　　　　　　　　　                    　　　　　　　　　　　
　　　　　　　　　　[ChangeCaption,アル]
                    [PrintText,「いいじゃん！似合ってる！」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit5,VOICE11_scenario5_1,1.0]
                    [DisplayActor,5,2]            　　　　　　　　　　　 　　　　　　　　　　　
                    [ChangeCaption,サイラス]
                    [PrintText,「そうですね、貴方にピッタリだ。」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「ふふっ、ありがとうございます！」,0.1]

　　　　　　　　　　 [ChangeCaption,ルナ]
                    [PrintText,ぶら下がっていた石を眺めていた。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,しかし、その瞬間また石の中が微かな光をもつ。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「＿＿ッ。」,0.1]

                    [SoundBGM,BGM,BGM_005_scenario2,1.0]
 　　　　　　　　　　　
                    [ChangeCaption,ルナ]
                    [PrintText,首元にある魔石は徐々に輝きが増していく。,0.1]

                    [ChangeCaption,ルナ]
                    [PrintText,「…あ、また」 ,0.1]

                    [BeginGroup]
                    [SoundVoice,unit4,VOICE11_scenario4_7,1.0]
                    [DisplayActor,4,1]            　　　　　　　　　　　 　　　　　　　　　　　
                    [DarkenActor,0]
                    [DarkenActor,2]
　 　　　　　　　　 [ChangeCaption,グラウス]
                    [PrintText,「…まさか、また光りだしたのか？」,0.1]
                    [EndGroup]

                    [ChangeCaption,ルナ]
                    [PrintText,「今度は東の方向です。」,0.1]

                    [BeginGroup]
                    [DisplayActor,2,2]            　　　　　　　　　　　 　　　　　　　　　　　
                    [ChangeCaption,リアム]
                    [PrintText,「本当に襲撃の多い日ですね。急ぎますよ、ほらケヴィンさんも。」,0.1]
                    [EndGroup]
 　　　　　　　　　　　
                    [BeginGroup]
                    [SoundVoice,unit6,VOICE11_scenario6_9,1.0]
                    [DisplayActor,6,0]            　　　　　　　　　　　 　　　　　　　　　　　
                    [DarkenActor,1]
                    [DarkenActor,2]
　　　　　　　　　　[ChangeCaption,ケヴィン]
                    [PrintText,「あー。だりぃなぁ」,0.1]
                    [EndGroup]

                    [BeginGroup]
                    [SoundVoice,unit2,VOICE07_chapter2_2,1.0]
                    [DisplayActor,2,2]            　　　　　　　　　　　 　　　　　　　　　　　
                    [ChangeCaption,リアム]
                    [PrintText,「しゃきっと歩いてください！」,0.1]
                    [EndGroup]

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