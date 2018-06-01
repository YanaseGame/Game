using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Choices : MonoBehaviour {

    //選択肢を出す
    public static void AnswerLabelSet()
    {
        string[] array01 = new string[]{"エディ・マーフィ","ジョン・レノン","チャック・ベリー","ハロルド・ロイド"};
        string[] array02 = new string[]{"紫式部", "小野小町","清少納言","伊勢"};
        string[] array03 = new string[]{"わさび", "いくら","しょうゆ","まぐろ"};
        string[] array04 = new string[]{"メロンパン", "カレーパン","食パン","あんパン"};
        string[] array05 = new string[]{ "太宰治", "芥川龍之介","宮沢賢治","川端康成" };
        string[] array06 = new string[]{"パリ", "ローマ","ミラノ","ロンドン"};
        string[] array07 = new string[]{"マイケル・ジョーダン", "モハメド・アリ","ベーブ・ルース","ペレ"};
        string[] array08 = new string[]{"6種類", "7種類","5種類","8種類"};
        string[] array09 = new string[]{"50州", "55州","40州","45州"};
        string[] array10 = new string[]{"634m", "654m","666m","567m"};
        string[] array11 = new string[]{"ポルトガル人", "オランダ人","イタリア人","ギリシャ人"};
        string[] array12 = new string[]{"佐藤", "鈴木","高橋","田中"};
        string[] array13 = new string[]{"千日手", "二歩","必至","封じ手"};
        string[] array14 = new string[]{"芥川龍之介", "太宰治","宮沢賢治","川端康成"};
        string[] array15 = new string[]{"ワシントンD.C.", "ニューヨーク","ロサンゼルス","テキサス"};
        string[] array16 = new string[]{"インド", "アメリカ","ロシア","日本"};
        string[] array17 = new string[]{"ロンドン", "パリ","ローマ","ミラノ"};
        string[] array18 = new string[]{"リスト", "モーツァルト","ドビュッシー","ショパン"};
        string[] array19 = new string[]{"フランス", "インド","イタリア","インドネシア"};
        string[] array20 = new string[]{"グリーンランド", "ニューギニア","イースター島","セントルシア"};
        string[] array21 = new string[]{"15才", "18才","20才","0才"};
        string[] array22 = new string[]{"約340m/秒", "約1500m/秒","約120m/秒","約760m/秒"};
        string[] array23 = new string[]{"香川県", "大阪府","東京都","沖縄県"};
        string[] array24 = new string[]{"信濃川", "利根川","石狩川","最上川"};
        string[] array25 = new string[]{"田沢湖", "バイカル湖","支笏湖","十和田湖"};
        string[] array26 = new string[]{"ハチミツ", "たまねぎ","ぶどう","カレー"};
        string[] array27 = new string[]{"カリギュラ効果", "サブリミナル効果","ブーメラン効果","カクテルパーティー効果"};
        string[] array28 = new string[]{"サンサーンス", "バッハ","モーツァルト","ショパン"};
        string[] array29 = new string[]{"テキサスホールデム", "スピード","ファイブカードドロー","インディアンポーカー"};
        string[] array30 = new string[]{"二酸化炭素", "水素","酸素","窒素"};
        string[] array31 = new string[]{"オフサイド", "トラベリング","スクラム","デュース"};
        string[] array32 = new string[]{"ウイスキー", "ビール","日本酒","ワイン"};
        string[] array33 = new string[]{"ウォッカ", "焼酎","日本酒","ワイン"};
        string[] array34 = new string[]{"シェイクスピア", "ゲーテ","ミケランジェロ","デカルト"};
        string[] array35 = new string[]{"愛", "希望","純潔","友情"};
        string[] array36 = new string[]{"しょうゆ", "みそ","みりん","しお"};


        string[] aa01 = new string[]{ "馬の耳に念仏", "井の中の蛙", "医者の不養生", "釈迦に説法" };
        string[] aa02 = new string[]{ "窮鼠猫を嚙む", "鳥なき里のこうむり", "海老で鯛を釣る", "猫の額にある物を鼠が窺う" };
        string[] aa03 = new string[]{ "火中の栗を拾う", "先んずれば人を制す", "天は自ら助くる者を助く", "七転び八起き" };
        string[] aa04 = new string[]{ "七十五日", "四十五日", "九十五日", "十五日" };
        string[] aa05 = new string[]{ "ねずみ", "ねこ", "いぬ", "とり" };
        string[] aa06 = new string[]{ "鯛", "金", "鯨", "鯉" };
        string[] aa07 = new string[]{ "爪", "足", "手", "鼻" };
        string[] aa08 = new string[]{ "どんぐり", "かえる", "こども", "さる" };
        string[] aa09 = new string[]{ "案ずるより産むが易し", "後悔先に立たず", "雨降って地固まる", "覆水盆に返らず" };
        string[] aa10 = new string[]{ "虎", "馬", "鬼", "龍" };
        string[] aa11 = new string[]{ "約100円", "約10円", "約30円", "約3円" };
        string[] aa12 = new string[]{ "目から鼻へ抜ける", "耳から耳へ抜ける", "鼻から耳へ抜ける", "耳から鼻へ抜ける" };
        string[] aa13 = new string[]{ "釜", "皿", "卓", "台" };
        string[] aa14 = new string[]{ "餅", "桶", "魚", "蕎麦" };
        string[] aa15 = new string[] { "〇鬼△蛇", "〇仏△蛇", "〇蛇△仏", "〇鰐△鬼" };
        string[] aa16 = new string[] { "無理が通れば道理引っ込む", "無理に通れば道理引っ込む", "道理に向かう刃なし", "理の前には道理なし" };
        string[] aa17 = new string[] { "三", "百", "十", "七" };
        string[] aa18 = new string[] { "虎穴に入らずんば虎子を得ず", "浅い川も深く渡れ", "濡れぬ先の傘", "転ばぬ先の杖" };
        string[] aa19 = new string[] { "蛙", "鳶", "馬", "狐" };
        string[] aa20 = new string[] { "光陰矢の如し", "桃栗三年柿八年", "応接に暇あらず", "時は金なり" };


        string[] ab01 = new string[] { "画竜点睛", "", "", "" };
        string[] ab02 = new string[] { "臥薪嘗胆", "", "", "" };
        string[] ab03 = new string[] { "〇三△四", "", "", "" };


        //問題のシャッフル
        //通常はstring[] Array = array.OrderBy(i => Guid.NewGuid()).ToArray();
        //の「OrderBy(i => Guid.NewGuid())」をShuffle()にする拡張メソッドを使っている
        string[] Array01 = array01.Shuffle().ToArray(); string[] Array02 = array02.Shuffle().ToArray();
        string[] Array03 = array03.Shuffle().ToArray(); string[] Array04 = array04.Shuffle().ToArray();
        string[] Array05 = array05.Shuffle().ToArray(); string[] Array06 = array06.Shuffle().ToArray();
        string[] Array07 = array07.Shuffle().ToArray(); string[] Array08 = array08.Shuffle().ToArray();
        string[] Array09 = array09.Shuffle().ToArray(); string[] Array10 = array10.Shuffle().ToArray();
        string[] Array11 = array11.Shuffle().ToArray(); string[] Array12 = array12.Shuffle().ToArray();
        string[] Array13 = array13.Shuffle().ToArray(); string[] Array14 = array14.Shuffle().ToArray();
        string[] Array15 = array15.Shuffle().ToArray(); string[] Array16 = array16.Shuffle().ToArray();
        string[] Array17 = array17.Shuffle().ToArray(); string[] Array18 = array18.Shuffle().ToArray();
        string[] Array19 = array19.Shuffle().ToArray(); string[] Array20 = array20.Shuffle().ToArray();
        string[] Array21 = array21.Shuffle().ToArray(); string[] Array22 = array22.Shuffle().ToArray();
        string[] Array23 = array23.Shuffle().ToArray(); string[] Array24 = array24.Shuffle().ToArray();
        string[] Array25 = array25.Shuffle().ToArray(); string[] Array26 = array26.Shuffle().ToArray();
        string[] Array27 = array27.Shuffle().ToArray(); string[] Array28 = array28.Shuffle().ToArray();
        string[] Array29 = array29.Shuffle().ToArray(); string[] Array30 = array30.Shuffle().ToArray();
        string[] Array31 = array31.Shuffle().ToArray(); string[] Array32 = array32.Shuffle().ToArray();
        string[] Array33 = array33.Shuffle().ToArray(); string[] Array34 = array34.Shuffle().ToArray();
        string[] Array35 = array35.Shuffle().ToArray(); string[] Array36 = array36.Shuffle().ToArray();

        string[] AA01 = aa01.Shuffle().ToArray(); string[] AA02 = aa02.Shuffle().ToArray();
        string[] AA03 = aa03.Shuffle().ToArray(); string[] AA04 = aa04.Shuffle().ToArray();
        string[] AA05 = aa05.Shuffle().ToArray(); string[] AA06 = aa06.Shuffle().ToArray();
        string[] AA07 = aa07.Shuffle().ToArray(); string[] AA08 = aa08.Shuffle().ToArray();
        string[] AA09 = aa09.Shuffle().ToArray(); string[] AA10 = aa10.Shuffle().ToArray();
        string[] AA11 = aa11.Shuffle().ToArray(); string[] AA12 = aa12.Shuffle().ToArray();
        string[] AA13 = aa13.Shuffle().ToArray(); string[] AA14 = aa14.Shuffle().ToArray();
        string[] AA15 = aa15.Shuffle().ToArray(); string[] AA16 = aa16.Shuffle().ToArray();
        string[] AA17 = aa17.Shuffle().ToArray(); string[] AA18 = aa18.Shuffle().ToArray();
        string[] AA19 = aa19.Shuffle().ToArray(); string[] AA20 = aa20.Shuffle().ToArray();

        string[] AB01 = ab01.Shuffle().ToArray(); string[] AB02 = ab02.Shuffle().ToArray();
        string[] AB03 = ab03.Shuffle().ToArray();



        HyphenationJpn answer = GameObject.Find("Quiz/QLabel").GetComponentInChildren<HyphenationJpn>();


        //問題と選択肢を一致させる
        for (int i = 1; i <= 4; i++)
        {
            Text ansLabel = GameObject.Find("Quiz/AnsButton" + i).GetComponentInChildren<Text>();

            if (answer.GetText == "ロックンロールの創始者の一人であり「ロック界の伝説」と呼ばれているミュージシャンは?")
            { ansLabel.text = Array01[i - 1]; }
            if (answer.GetText == "「花の色はうつりにけりないたずらに～」という歌が百人一首に収められている平安時代の女流歌人は誰？")
            { ansLabel.text = Array02[i - 1]; }
            if (answer.GetText == "寿司屋で使われる言葉で「ガリ」はしょうがのことですが、「ムラサキ」は何？")
            { ansLabel.text = Array03[i - 1]; }
            if (answer.GetText == "アニメ「ドラえもん」の妹ドラミちゃんの好物は何？")
            { ansLabel.text = Array04[i - 1]; }
            if (answer.GetText == "「斜陽」「人間失格」を著した小説家は誰？")
            { ansLabel.text = Array05[i - 1]; }
            if (answer.GetText == "フランスの首都は何？")
            { ansLabel.text = Array06[i - 1]; }
            if (answer.GetText == "「バスケットボールの神様」と呼ばれている選手は誰？")
            { ansLabel.text = Array07[i - 1]; }
            if (answer.GetText == "将棋の駒は全部で8種類であるが、チェスは全部で何種類？")
            { ansLabel.text = Array08[i - 1]; }
            if (answer.GetText == "2018年現在のアメリカ合衆国の州はいくつある？")
            { ansLabel.text = Array09[i - 1]; }
            if (answer.GetText == "「東京タワー」の高さは333mであるが、「東京スカイツリー」の高さは何m？")
            { ansLabel.text = Array10[i - 1]; }
            if (answer.GetText == "1543年に種子島に漂着し鉄砲を伝えたのはどこの国の人？")
            { ansLabel.text = Array11[i - 1]; }
            if (answer.GetText == "2018年の調査によると、日本で最も多い苗字は何？")
            { ansLabel.text = Array12[i - 1]; }
            if (answer.GetText == "将棋で同じ手順を繰返していつまでも局面が進展しない状態を何という？")
            { ansLabel.text = Array13[i - 1]; }
            if (answer.GetText == "夏目漱石の弟子の一人で、「羅生門」「蜘蛛の糸」を著した小説家は誰？")
            { ansLabel.text = Array14[i - 1]; }
            if (answer.GetText == "アメリカ合衆国の首都は何？")
            { ansLabel.text = Array15[i - 1]; }
            if (answer.GetText == "世界で一番人口が多い国は「中華人民共和国」ですが、二番目に人口が多い国は？")
            { ansLabel.text = Array16[i - 1]; }
            if (answer.GetText == "イギリスの首都は何？")
            { ansLabel.text = Array17[i - 1]; }
            if (answer.GetText == "「ピアノの魔術師」と称されたピアニストは誰？")
            { ansLabel.text = Array18[i - 1]; }
            if (answer.GetText == "日本で略称として使われる「仏国」はどこの国？")
            { ansLabel.text = Array19[i - 1]; }
            if (answer.GetText == "世界一大きい島は何？")
            { ansLabel.text = Array20[i - 1]; }
            if (answer.GetText == "日本の民法において、遺言が単独で認められるのは何歳から？")
            { ansLabel.text = Array21[i - 1]; }
            if (answer.GetText == "空気中の音速は約m/秒？")
            { ansLabel.text = Array22[i - 1]; }
            if (answer.GetText == "日本で最も小さい都道府県は何？")
            { ansLabel.text = Array23[i - 1]; }
            if (answer.GetText == "日本一長い川は何？")
            { ansLabel.text = Array24[i - 1]; }
            if (answer.GetText == "日本一深い湖は何？")
            { ansLabel.text = Array25[i - 1]; }
            if (answer.GetText == "乳児が食べると特に危険な食品はどれ？")
            { ansLabel.text = Array26[i - 1]; }
            if (answer.GetText == "禁止されると余計にやってみたくなる心理現象を何という？")
            { ansLabel.text = Array27[i - 1]; }
            if (answer.GetText == "クラシック曲の「死の舞踏」を作曲したのは誰？")
            { ansLabel.text = Array28[i - 1]; }
            if (answer.GetText == "現在、世界で最も遊ばれているポーカーのルールは？")
            { ansLabel.text = Array29[i - 1]; }
            if (answer.GetText == "次のうち、最も重たい気体はどれ？")
            { ansLabel.text = Array30[i - 1]; }
            if (answer.GetText == "次のうち、サッカーで使われる用語はどれ？")
            { ansLabel.text = Array31[i - 1]; }
            if (answer.GetText == "次のうち、蒸留酒はどれ？")
            { ansLabel.text = Array32[i - 1]; }
            if (answer.GetText == "次のうち、一般的に度数が最も高いお酒は何？")
            { ansLabel.text = Array33[i - 1]; }
            if (answer.GetText == "「ハムレット」「オセロ」「ロミオとジュリエット」などの作品を生み出した詩人であり劇作家は誰？")
            { ansLabel.text = Array34[i - 1]; }
            if (answer.GetText == "赤いバラの花言葉は何？")
            { ansLabel.text = Array35[i - 1]; }
            if (answer.GetText == "調味料で使われる「さしすせそ」の「せ」とは何？")
            { ansLabel.text = Array36[i - 1]; }


            if (answer.GetText == "いくら意見をしても全く効き目のないことをことわざで何という？")
            { ansLabel.text = AA01[i - 1]; }
            if (answer.GetText == "弱者も追い込まれれば強者に勝つことをことわざで何という？")
            { ansLabel.text = AA02[i - 1]; }
            if (answer.GetText == "自分の利益にならないのに、他人のために危険を冒すことをことわざで何という？")
            { ansLabel.text = AA03[i - 1]; }
            if (answer.GetText == "うわさは長く続かず、一時的なものに過ぎないことをことわざで「人の噂も〇日」。何日？")
            { ansLabel.text = AA04[i - 1]; }
            if (answer.GetText == "弱者も追い込まれれば強者に勝つということわざ「窮鼠猫を噛む」で噛んだ動物は何？")
            { ansLabel.text = AA05[i - 1]; }
            if (answer.GetText == "わずかな労力で品物や多くの利益を得るということわざ「海老で〇を釣る」。〇の中は何？")
            { ansLabel.text = AA06[i - 1]; }
            if (answer.GetText == "優れた人を規範として、少しでもあやかろうとすることわざ「○の垢を煎じて飲む」。〇の中は何？")
            { ansLabel.text = AA07[i - 1]; }
            if (answer.GetText == "どれもこれも似たり寄ったりで、抜きん出た者がいないことをことわざで「○○の背比べ」。〇の中は何？")
            { ansLabel.text = AA08[i - 1]; }
            if (answer.GetText == "始める前はあれこれ心配をするが、やってみるとたやすくできることをことわざで何という？")
            { ansLabel.text = AA09[i - 1]; }
            if (answer.GetText == "危険を避けていては、大きな成功も有り得ないということわざ「〇穴に入らずんば〇子を得ず」。〇の中は何という？")
            { ansLabel.text = AA10[i - 1]; }
            if (answer.GetText == "早起きをすれば何らかの利益があることをことわざで「早起きは三文の徳」。では「三文」とは現代の価格で考えると約何円？")
            { ansLabel.text = AA11[i - 1]; }
            if (answer.GetText == "非常に利口で賢いことや、判断が素早く抜け目のないことをことわざで何という？")
            { ansLabel.text = AA12[i - 1]; }
            if (answer.GetText == "生活を共にしたり、同じ職場で働いた親密な仲をことわざで「同じ〇の飯を食う」。〇の中は何？")
            { ansLabel.text = AA13[i - 1]; }
            if (answer.GetText == "何事においてもそれぞれの専門家が一番であるということわざ「〇は〇屋」。〇の中は何？")
            { ansLabel.text = AA14[i - 1]; }
            if (answer.GetText == "これからどんな恐ろしいことが起きるか予測ができないということわざ「〇が出るか△が出るか」。〇と△の中は何？")
            { ansLabel.text = AA15[i - 1]; }
            if (answer.GetText == "道理に反することをおし進めようとすれば、道理にかなった正義は行われなくなるということをことわざで何という？")
            { ansLabel.text = AA16[i - 1]; }
            if (answer.GetText == "辛くても辛抱して続ければ、いつかは成し遂げられるということわざ「石の上にも〇年」〇の中は何？")
            { ansLabel.text = AA17[i - 1]; }
            if (answer.GetText == "用心の上にさらに用心を重ねて物事を行うことを「石橋を叩いて渡る」。このことわざの対義は次の内どれ？")
            { ansLabel.text = AA18[i - 1]; }
            if (answer.GetText == "子の能力は親に似るものであり、凡人の子は凡人であるということわざ「〇の子は〇」。〇の中は何？")
            { ansLabel.text = AA19[i - 1]; }
            if (answer.GetText == "月日の過ぎるのが非常に早いということをことわざで何という？")
            { ansLabel.text = AA20[i - 1]; }

            if (answer.GetText == "最後の仕上げを漢字で何という？")
            { ansLabel.text = AB01[i - 1]; }
            if (answer.GetText == "目的を達成するために苦心し、日々努力をすることを漢字で何という？")
            { ansLabel.text = AB02[i - 1]; }
            if (answer.GetText == "目の前の違いにこだわり、結果が同じことに気が付かないことを「朝〇暮△」というが、〇と△の中は何？")
            { ansLabel.text = AB03[i - 1]; }
        }
    }


}
