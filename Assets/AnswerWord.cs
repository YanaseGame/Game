using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnswerWord : MonoBehaviour {



    //問題の回答を出すメソッド
    public void Answerword()
    {

        HyphenationJpn answer = GameObject.Find("QLabel").GetComponentInChildren<HyphenationJpn>();

        Text judgeLabel = GameObject.Find("AnswerWord").GetComponent<Text>();

        if (answer.GetText == "ロックンロールの創始者の一人であり「ロック界の伝説」と呼ばれているミュージシャンは?")
        { judgeLabel.text = "チャック・ベリー"; }

        if (answer.GetText == "「花の色はうつりにけりないたずらに～」という歌が百人一首に収められている平安時代の女流歌人は誰？")
        { judgeLabel.text = "小野小町"; }

        if (answer.GetText == "寿司屋で使われる言葉で「ガリ」はしょうがのことですが、「ムラサキ」は何？")
        { judgeLabel.text = "しょうゆ"; }

        if (answer.GetText == "アニメ「ドラえもん」の妹ドラミちゃんの好物は何？")
        { judgeLabel.text = "メロンパン"; }

        if (answer.GetText == "「斜陽」「人間失格」を著した小説家は誰？")
        { judgeLabel.text = "太宰治"; }

        if (answer.GetText == "フランスの首都は何？")
        { judgeLabel.text = "パリ"; }

        if (answer.GetText == "「バスケットボールの神様」と呼ばれている選手は誰？")
        { judgeLabel.text = "マイケル・ジョーダン"; }

        if (answer.GetText == "将棋の駒は全部で8種類であるが、チェスは全部で何種類？")
        { judgeLabel.text = "6種類"; }

        if (answer.GetText == "2018年現在のアメリカ合衆国の州はいくつある？")
        { judgeLabel.text = "50州"; }

        if (answer.GetText == "1543年に種子島に漂着し鉄砲を伝えたのはどこの国の人？")
        { judgeLabel.text = "ポルトガル人"; }

        if (answer.GetText == "2018年の調査によると、日本で最も多い苗字は何？")
        { judgeLabel.text = "佐藤"; }

        if (answer.GetText == "将棋で同じ手順を繰返していつまでも局面が進展しない状態を何という？")
        { judgeLabel.text = "千日手"; }

        if (answer.GetText == "夏目漱石の弟子の一人で、「羅生門」「蜘蛛の糸」を著した小説家は誰？")
        { judgeLabel.text = "芥川龍之介"; }

        if (answer.GetText == "アメリカ合衆国の首都は何？")
        { judgeLabel.text = "ワシントンD.C."; }

        if (answer.GetText == "世界で一番人口が多い国は「中華人民共和国」ですが、二番目に人口が多い国は？")
        { judgeLabel.text = "インド"; }

        if (answer.GetText == "イギリスの首都は何？")
        { judgeLabel.text = "ロンドン"; }

        if (answer.GetText == "「ピアノの魔術師」と称されたピアニストは誰？")
        { judgeLabel.text = "リスト"; }

        if (answer.GetText == "日本で略称として使われる「仏国」はどこの国？")
        { judgeLabel.text = "フランス"; }

        if (answer.GetText == "世界一大きい島は何？")
        { judgeLabel.text = "グリーンランド"; }

        if (answer.GetText == "日本の民法において、遺言が単独で認められるのは何歳から？")
        { judgeLabel.text = "15才"; }

        if (answer.GetText == "空気中の音速は約m/秒？")
        { judgeLabel.text = "約340m/秒"; }

        if (answer.GetText == "日本で最も小さい都道府県は何？")
        { judgeLabel.text = "香川県"; }

        if (answer.GetText == "日本一長い川は何？")
        { judgeLabel.text = "信濃川"; }

        if (answer.GetText == "日本一深い湖は何？")
        { judgeLabel.text = "田沢湖"; }

        if (answer.GetText == "乳児が食べると特に危険な食品はどれ？")
        { judgeLabel.text = "ハチミツ"; }

        if (answer.GetText == "禁止されると余計にやってみたくなる心理現象を何という？")
        { judgeLabel.text = "カリギュラ効果"; }

        if (answer.GetText == "現在、世界で最も遊ばれているポーカーのルールは？")
        { judgeLabel.text = "テキサスホールデム"; }

        if (answer.GetText == "次のうち、最も重たい気体はどれ？")
        { judgeLabel.text = "二酸化炭素"; }

        if (answer.GetText == "次のうち、サッカーで使われる用語はどれ？")
        { judgeLabel.text = "オフサイド"; }

        if (answer.GetText == "次のうち、蒸留酒はどれ？")
        { judgeLabel.text = "ウイスキー"; }

        if (answer.GetText == "次のうち、一般的に度数が最も高いお酒は何？")
        { judgeLabel.text = "ウォッカ"; }

        if (answer.GetText == "「ハムレット」「オセロ」「ロミオとジュリエット」などの作品を生み出した詩人であり劇作家は誰？")
        { judgeLabel.text = "シェイクスピア"; }

        if (answer.GetText == "赤いバラの花言葉は何？")
        { judgeLabel.text = "愛"; }

        if (answer.GetText == "調味料で使われる「さしすせそ」の「せ」とは何？")
        { judgeLabel.text = "しょうゆ"; }



        if (answer.GetText == "いくら意見をしても全く効き目のないことをことわざで何という？")
        { judgeLabel.text = "馬の耳に念仏"; }

        if (answer.GetText == "弱者も追い込まれれば強者に勝つことをことわざで何という？")
        { judgeLabel.text = "窮鼠猫を嚙む"; }

        if (answer.GetText == "自分の利益にならないのに、他人のために危険を冒すことをことわざで何という？")
        { judgeLabel.text = "火中の栗を拾う"; }

        if (answer.GetText == "うわさは長く続かず、一時的なものに過ぎないことをことわざで「人の噂も〇日」。何日？")
        { judgeLabel.text = "七十五日"; }

        if (answer.GetText == "弱者も追い込まれれば強者に勝つということわざ「窮鼠猫を噛む」で噛んだ動物は何？")
        { judgeLabel.text = "ねずみ"; }

        if (answer.GetText == "わずかな労力で品物や多くの利益を得るということわざ「海老で〇を釣る」。〇の中は何？")
        { judgeLabel.text = "鯛"; }

        if (answer.GetText == "優れた人を規範として、少しでもあやかろうとすることわざ「○の垢を煎じて飲む」。〇の中は何？")
        { judgeLabel.text = "爪"; }

        if (answer.GetText == "どれもこれも似たり寄ったりで、抜きん出た者がいないことをことわざで「○○の背比べ」。〇の中は何？")
        { judgeLabel.text = "どんぐり"; }

        if (answer.GetText == "始める前はあれこれ心配をするが、やってみるとたやすくできることをことわざで何という？")
        { judgeLabel.text = "案ずるより産むが易し"; }

        if (answer.GetText == "危険を避けていては、大きな成功も有り得ないということわざ「〇穴に入らずんば〇子を得ず」。〇の中は何という？")
        { judgeLabel.text = "虎"; }

        if (answer.GetText == "早起きをすれば何らかの利益があることをことわざで「早起きは三文の徳」。では「三文」とは現代の価格で考えると約何円？")
        { judgeLabel.text = "約100円"; }

        if (answer.GetText == "非常に利口で賢いことや、判断が素早く抜け目のないことをことわざで何という？")
        { judgeLabel.text = "目から鼻へ抜ける"; }

        if (answer.GetText == "生活を共にしたり、同じ職場で働いた親密な仲をことわざで「同じ〇の飯を食う」。〇の中は何？")
        { judgeLabel.text = "釜"; }

        if (answer.GetText == "何事においてもそれぞれの専門家が一番であるということわざ「〇は〇屋」。〇の中は何？")
        { judgeLabel.text = "餅"; }

        if (answer.GetText == "これからどんな恐ろしいことが起きるか予測ができないということわざ「〇が出るか△が出るか」。〇と△の中は何？")
        { judgeLabel.text = "〇鬼△蛇"; }

        if (answer.GetText == "道理に反することをおし進めようとすれば、道理にかなった正義は行われなくなるということをことわざで何という？")
        { judgeLabel.text = "無理が通れば道理引っ込む"; }

        if (answer.GetText == "辛くても辛抱して続ければ、いつかは成し遂げられるということわざ「石の上にも〇年」〇の中は何？")
        { judgeLabel.text = "三"; }

        if (answer.GetText == "用心の上にさらに用心を重ねて物事を行うことを「石橋を叩いて渡る」。このことわざの対義は次の内どれ？")
        { judgeLabel.text = "虎穴に入らずんば虎子を得ず"; }

        if (answer.GetText == "子の能力は親に似るものであり、凡人の子は凡人であるということわざ「〇の子は〇」。〇の中は何？")
        { judgeLabel.text = "蛙"; }

        if (answer.GetText == "月日の過ぎるのが非常に早いということをことわざで何という？")
        { judgeLabel.text = "光陰矢の如し"; }


        if (answer.GetText == "最後の仕上げを漢字で何という？")
        { judgeLabel.text = "画竜点睛"; }

        if (answer.GetText == "目的を達成するために苦心し、日々努力をすることを漢字で何という？")
        { judgeLabel.text = "臥薪嘗胆"; }

        if (answer.GetText == "目の前の違いにこだわり、結果が同じことに気が付かないことを「朝〇暮△」というが、〇と△の中は何？")
        { judgeLabel.text = "〇三△四"; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }

        if (answer.GetText == "")
        { judgeLabel.text = ""; }
    }
}
