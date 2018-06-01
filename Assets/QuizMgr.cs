using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



// OrderBy(i => Guid.NewGuid())をShuffle()にする拡張メソッド
public static class IEnumerableExtension
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(i => Guid.NewGuid());
    }
}



public class QuizMgr : MonoBehaviour
{
    //画像を消すための画像
    public static GameObject Heart;
    public static GameObject Heart2;
    public static GameObject Heart3;

    //正解、不正解の音を出すための箱
    private AudioSource sound01;
    private AudioSource sound02;

    //４択ボタンを消す箱（JudgeAnswer）
    Button Ans1;
    Button Ans2;
    Button Ans3;
    Button Ans4;

    //「次へ」ボタンの箱（Start）
    public GameObject buttonObj;

    //スコアを計算する変数
    public static int g_scoreData;

    //正解、不正解を出す変数
    public static string g_judgeData;

    //今の問題数（Q.1～）を出すための変数
    public static int numberQuestions = 1;

    //残り体力の変数
    public static int qCount;

    //リスト化した問題を数値にするための変数
    static public int questionIndex;  

    //☆の変数
    static public int starBox = 5;

    //問題を置く
    static List<string> questionList = new List<string>()
    {
        "ロックンロールの創始者の一人であり「ロック界の伝説」と呼ばれているミュージシャンは?",
        "「花の色はうつりにけりないたずらに～」という歌が百人一首に収められている平安時代の女流歌人は誰？",
        "寿司屋で使われる言葉で「ガリ」はしょうがのことですが、「ムラサキ」は何？",
        "アニメ「ドラえもん」の妹ドラミちゃんの好物は何？",
        "「斜陽」「人間失格」を著した小説家は誰？",
        "フランスの首都は何？",
        "「バスケットボールの神様」と呼ばれている選手は誰？",
        "将棋の駒は全部で8種類であるが、チェスは全部で何種類？",
        "2018年現在のアメリカ合衆国の州はいくつある？",
        "「東京タワー」の高さは333mであるが、「東京スカイツリー」の高さは何m？",
        "1543年に種子島に漂着し鉄砲を伝えたのはどこの国の人？",
        "2018年の調査によると、日本で最も多い苗字は何？",
        "将棋で同じ手順を繰返していつまでも局面が進展しない状態を何という？",
        "夏目漱石の弟子の一人で、「羅生門」「蜘蛛の糸」を著した小説家は誰？",
        "アメリカ合衆国の首都は何？",
        "世界で一番人口が多い国は「中華人民共和国」ですが、二番目に人口が多い国は？",
        "イギリスの首都は何？",
        "「ピアノの魔術師」と称されたピアニストは誰？",
        "日本で略称として使われる「仏国」はどこの国？",
        "世界一大きい島は何？",
        "日本の民法において、遺言が単独で認められるのは何歳から？",
        "空気中の音速は約m/秒？",
        "日本で最も小さい都道府県は何？",
        "日本一長い川は何？",
        "日本一深い湖は何？",
        "乳児が食べると特に危険な食品はどれ？",
        "禁止されると余計にやってみたくなる心理現象を何という？",
        "現在、世界で最も遊ばれているポーカーのルールは？",
        "次のうち、最も重たい気体はどれ？",
        "次のうち、サッカーで使われる用語はどれ？",
        "次のうち、蒸留酒はどれ？",
        "次のうち、一般的に度数が最も高いお酒は何？",
        "「ハムレット」「オセロ」「ロミオとジュリエット」などの作品を生み出した詩人であり劇作家は誰？",
        "赤いバラの花言葉は何？",
        "調味料で使われる「さしすせそ」の「せ」とは何？",

        "いくら意見をしても全く効き目のないことをことわざで何という？",
        "弱者も追い込まれれば強者に勝つことをことわざで何という？",
        "自分の利益にならないのに、他人のために危険を冒すことをことわざで何という？",
        "うわさは長く続かず、一時的なものに過ぎないことをことわざで「人の噂も〇日」。何日？",
        "弱者も追い込まれれば強者に勝つということわざ「窮鼠猫を噛む」で噛んだ動物は何？",
        "わずかな労力で品物や多くの利益を得るということわざ「海老で〇を釣る」。〇の中は何？",
        "優れた人を規範として、少しでもあやかろうとすることわざ「○の垢を煎じて飲む」。〇の中は何？",
        "どれもこれも似たり寄ったりで、抜きん出た者がいないことをことわざで「○○の背比べ」。〇の中は何？",
        "始める前はあれこれ心配をするが、やってみるとたやすくできることをことわざで何という？",
        "危険を避けていては、大きな成功も有り得ないということわざ「〇穴に入らずんば〇子を得ず」。〇の中は何という？",
        "早起きをすれば何らかの利益があることをことわざで「早起きは三文の徳」。では「三文」とは現代の価格で考えると約何円？",
        "非常に利口で賢いことや、判断が素早く抜け目のないことをことわざで何という？",
        "生活を共にしたり、同じ職場で働いた親密な仲をことわざで「同じ〇の飯を食う」。〇の中は何？",
        "何事においてもそれぞれの専門家が一番であるということわざ「〇は〇屋」。〇の中は何？",
        "これからどんな恐ろしいことが起きるか予測ができないということわざ「〇が出るか△が出るか」。〇と△の中は何？",
        "道理に反することをおし進めようとすれば、道理にかなった正義は行われなくなるということをことわざで何という？",
        "辛くても辛抱して続ければ、いつかは成し遂げられるということわざ「石の上にも〇年」〇の中は何？",
        "用心の上にさらに用心を重ねて物事を行うことを「石橋を叩いて渡る」。このことわざの対義は次の内どれ？",
        "子の能力は親に似るものであり、凡人の子は凡人であるということわざ「〇の子は〇」。〇の中は何？",
        "月日の過ぎるのが非常に早いということをことわざで何という？",

        "最後の仕上げを漢字で何という？",
        "目的を達成するために苦心し、日々努力をすることを漢字で何という？",
        "目の前の違いにこだわり、結果が同じことに気が付かないことを「朝〇暮△」というが、〇と△の中は何？",
        "",
    };

//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//スタートのメソッド
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    void Start()
    {
        //問題（禁則処理してる）をUnityに渡す変数
        HyphenationJpn qLabel = GameObject.Find("Quiz/QLabel").GetComponentInChildren<HyphenationJpn>();

        //問題を順番化させて、Unityに渡す
        qLabel.GetText = questionList[questionIndex];
        
        //４択を出すラベル
        Choices.AnswerLabelSet();

        //「次へ」ボタンを非表示にする
        buttonObj.SetActive(false);

        //問題数（Q１～）を出す
        Text scoreLabel = GameObject.Find("NumberQ").GetComponent<Text>();
        scoreLabel.text = "Q. " + numberQuestions+" / 100";

        //タイトルの音楽を消す
        Sound2.DeleteInstance();
    }

//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//GameStart→NextScene()、問題をシャッフル　と　☆を-１する
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public static void shuffleSet()
    {
        //問題をシャッフルさせる
        questionList = questionList.Shuffle().ToList();
        //☆を-1する
        starBox--;
    }
       

//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//次の問題へ対応
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public void NextQuiz()
    {
        //☆を増やす
        if (numberQuestions == 15)
        {
            starBox += 1;
        }
        if (numberQuestions == 30)
        {
            starBox++;
        }
        if (numberQuestions == 50)
        {
            starBox++;
        }
        if (numberQuestions == 75)
        {
            starBox++;
        }
        if (numberQuestions == 100)
        {
            starBox++;
        }

        if (SceneManager.GetActiveScene().name == "Quiz")
            if (numberQuestions == 100)
            {
                //スコアを出すシーン
                SceneManager.LoadScene("Score");
                //クイズ時のBGMを切るメソッド
                Sound.DeleteInstance();
                //問題を一からスタートさせる
                questionIndex = 0;
                //問題をリセットする
                qCount = 0;
            }
            else if (g_judgeData == "正解")
        　　{  
                //まだ続く
                SceneManager.LoadScene("Quiz");
                //次の問題にする
                questionIndex++;
                //問題数(Q1～)を次にする
                numberQuestions++;
            } 
            
            //体力ゼロの場合
            else if(qCount == 2)
            {
                //スコアを出すシーン
                SceneManager.LoadScene("Score");
                //クイズ時のBGMを切るメソッド
                Sound.DeleteInstance();
                //問題を一からスタートさせる
                questionIndex = 0;          
                //問題をリセットする
                qCount = 0;
             }
            else if(g_judgeData == "不正解")
            {
                //体力を減らす
                qCount++;
                //まだ続く
                SceneManager.LoadScene("Quiz");
                //次の問題にする
                questionIndex++;
                //問題数（Q1～）を次にする
                numberQuestions++;
            }

    }
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//「Score」→スコアを出すメソッド(今は使わない)
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━    
    public static int GetScoreData()
    {
        return g_scoreData;
    }
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//「GameStart」→スコアをリセットするためのメソッド(今は使わない)
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public static int SetScoreData(int scoreData)
    {
        g_scoreData = scoreData;
        return g_scoreData;
    }
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//スコアのところに出す、〇問到達のメソッド
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public static int GetQuestionData()
    {
        return numberQuestions;
    }
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//「GameStart」→☆の数を出すためのメソッド
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public static int Starbox()
    {
        return starBox;
    }
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//回答→正解か不正解かを認識するメソッド
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public void JudgeAnswer()
    {
        //４択ボタンの箱に対応させて、それを無効化(interactable)する
        Ans1 = GameObject.Find("Quiz/AnsButton1").GetComponentInChildren<Button>();
        Ans2 = GameObject.Find("Quiz/AnsButton2").GetComponentInChildren<Button>();
        Ans3 = GameObject.Find("Quiz/AnsButton3").GetComponentInChildren<Button>();
        Ans4 = GameObject.Find("Quiz/AnsButton4").GetComponentInChildren<Button>();
        Ans1.interactable = false;
        Ans2.interactable = false;
        Ans3.interactable = false;
        Ans4.interactable = false;

        //「次へ」を表示させる
        GameObject.Find("Quiz").transform.Find("Button").gameObject.SetActive(true);

        //音を出すために、Unityと対応させる
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];

        //〇×を検索する箱
        SpriteRenderer judgeImage = GameObject.Find("JudgeImage").GetComponent<SpriteRenderer>();
        //正解、不正解を検索する箱
        Text judgeLabel = GameObject.Find("JudgeLabel").GetComponent<Text>();
        //答えの箱を作る
        Text answer = this.GetComponentInChildren<Text>();

        HyphenationJpn Answer = GameObject.Find("QLabel").GetComponentInChildren<HyphenationJpn>();

        //この問題でこの回答→正解、不正解を出す
        if (Answer.GetText == "ロックンロールの創始者の一人であり「ロック界の伝説」と呼ばれているミュージシャンは?" && answer.text == "チャック・ベリー")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「花の色はうつりにけりないたずらに～」という歌が百人一首に収められている平安時代の女流歌人は誰？" && answer.text == "小野小町")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "寿司屋で使われる言葉で「ガリ」はしょうがのことですが、「ムラサキ」は何？" && answer.text == "しょうゆ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "アニメ「ドラえもん」の妹ドラミちゃんの好物は何？" && answer.text == "メロンパン")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「斜陽」「人間失格」を著した小説家は誰？" && answer.text == "太宰治")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "フランスの首都は何？" && answer.text == "パリ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「バスケットボールの神様」と呼ばれている選手は誰？" && answer.text == "マイケル・ジョーダン")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "将棋の駒は全部で8種類であるが、チェスは全部で何種類？" && answer.text == "6種類")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "2018年現在のアメリカ合衆国の州はいくつある？" && answer.text == "50州")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「東京タワー」の高さは333mであるが、「東京スカイツリー」の高さは何m？" && answer.text == "634m")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "1543年に種子島に漂着し鉄砲を伝えたのはどこの国の人？" && answer.text == "ポルトガル人")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "2018年の調査によると、日本で最も多い苗字は何？" && answer.text == "佐藤")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "将棋で同じ手順を繰返していつまでも局面が進展しない状態を何という？" && answer.text == "千日手")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "夏目漱石の弟子の一人で、「羅生門」「蜘蛛の糸」を著した小説家は誰？" && answer.text == "芥川龍之介")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "アメリカ合衆国の首都は何？" && answer.text == "ワシントンD.C.")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "世界で一番人口が多い国は「中華人民共和国」ですが、二番目に人口が多い国は？" && answer.text == "インド")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "イギリスの首都は何？" && answer.text == "ロンドン")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「ピアノの魔術師」と称されたピアニストは誰？" && answer.text == "リスト")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "日本で略称として使われる「仏国」はどこの国？" && answer.text == "フランス")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "世界一大きい島は何？" && answer.text == "グリーンランド")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "日本の民法において、遺言が単独で認められるのは何歳から？" && answer.text == "15才")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "空気中の音速は約m/秒？" && answer.text == "約340m/秒")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "日本で最も小さい都道府県は何？" && answer.text == "香川県")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "日本一長い川は何？" && answer.text == "信濃川")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "日本一深い湖は何？" && answer.text == "田沢湖")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "乳児が食べると特に危険な食品はどれ？" && answer.text == "ハチミツ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "禁止されると余計にやってみたくなる心理現象を何という？" && answer.text == "カリギュラ効果")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "現在、世界で最も遊ばれているポーカーのルールは？" && answer.text == "テキサスホールデム")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "次のうち、最も重たい気体はどれ？" && answer.text == "二酸化炭素")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "次のうち、サッカーで使われる用語はどれ？" && answer.text == "オフサイド")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "次のうち、蒸留酒はどれ？" && answer.text == "ウイスキー")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "次のうち、一般的に度数が最も高いお酒は何？" && answer.text == "ウォッカ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "「ハムレット」「オセロ」「ロミオとジュリエット」などの作品を生み出した詩人であり劇作家は誰？" && answer.text == "シェイクスピア")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "赤いバラの花言葉は何？" && answer.text == "愛")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "調味料で使われる「さしすせそ」の「せ」とは何？" && answer.text == "しょうゆ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }


        if (Answer.GetText == "いくら意見をしても全く効き目のないことをことわざで何という？" && answer.text == "馬の耳に念仏")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "弱者も追い込まれれば強者に勝つことをことわざで何という？" && answer.text == "窮鼠猫を嚙む")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "自分の利益にならないのに、他人のために危険を冒すことをことわざで何という？" && answer.text == "火中の栗を拾う")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "うわさは長く続かず、一時的なものに過ぎないことをことわざで「人の噂も〇日」。何日？" && answer.text == "七十五日")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "弱者も追い込まれれば強者に勝つということわざ「窮鼠猫を噛む」で噛んだ動物は何？" && answer.text == "ねずみ")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "わずかな労力で品物や多くの利益を得るということわざ「海老で〇を釣る」。〇の中は何？" && answer.text == "鯛")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "優れた人を規範として、少しでもあやかろうとすることわざ「○の垢を煎じて飲む」。〇の中は何？" && answer.text == "爪")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "どれもこれも似たり寄ったりで、抜きん出た者がいないことをことわざで「○○の背比べ」。〇の中は何？" && answer.text == "どんぐり")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "始める前はあれこれ心配をするが、やってみるとたやすくできることをことわざで何という？" && answer.text == "案ずるより産むが易し")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "危険を避けていては、大きな成功も有り得ないということわざ「〇穴に入らずんば〇子を得ず」。〇の中は何という？" && answer.text == "虎")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "早起きをすれば何らかの利益があることをことわざで「早起きは三文の徳」。では「三文」とは現代の価格で考えると約何円？" && answer.text == "約100円")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "非常に利口で賢いことや、判断が素早く抜け目のないことをことわざで何という？" && answer.text == "目から鼻へ抜ける")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "生活を共にしたり、同じ職場で働いた親密な仲をことわざで「同じ〇の飯を食う」。〇の中は何？" && answer.text == "釜")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "何事においてもそれぞれの専門家が一番であるということわざ「〇は〇屋」。〇の中は何？" && answer.text == "餅")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "これからどんな恐ろしいことが起きるか予測ができないということわざ「〇が出るか△が出るか」。〇と△の中は何？" && answer.text == "〇鬼△蛇")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "道理に反することをおし進めようとすれば、道理にかなった正義は行われなくなるということをことわざで何という？" && answer.text == "無理が通れば道理引っ込む")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "辛くても辛抱して続ければ、いつかは成し遂げられるということわざ「石の上にも〇年」〇の中は何？" && answer.text == "三")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "用心の上にさらに用心を重ねて物事を行うことを「石橋を叩いて渡る」。このことわざの対義は次の内どれ？" && answer.text == "虎穴に入らずんば虎子を得ず")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "子の能力は親に似るものであり、凡人の子は凡人であるということわざ「〇の子は〇」。〇の中は何？" && answer.text == "蛙")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "月日の過ぎるのが非常に早いということをことわざで何という？" && answer.text == "光陰矢の如し")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }


        if (Answer.GetText == "最後の仕上げを漢字で何という？" && answer.text == "画竜点睛")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "目的を達成するために苦心し、日々努力をすることを漢字で何という？" && answer.text == "臥薪嘗胆")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }
        if (Answer.GetText == "目の前の違いにこだわり、結果が同じことに気が付かないことを「朝〇暮△」というが、〇と△の中は何？" && answer.text == "〇三△四")
        {
            Debug.Log("正解");

            //正解時に「ピンポン！」を出す
            sound01.PlayOneShot(sound01.clip);

            //点数を加算する(今は使わない)
            g_scoreData++;

            // NextQuiz()で使う
            g_judgeData = "正解";

            //「〇」を出す
            Sprite loadingMaruImage = Resources.Load<Sprite>("maru");
            judgeImage.sprite = loadingMaruImage;

            //「正解」を出す
            judgeLabel.color = Color.red;
            judgeLabel.text = "正解";
            return;
        }

        else
        {
            Debug.Log("不正解");

            //不正解時に「ブー！」を出す
            sound02.PlayOneShot(sound02.clip);

            //×の画像を出す
            Sprite loadingBatsuImage = Resources.Load<Sprite>("batsu");
            judgeImage.sprite = loadingBatsuImage;

            //「不正解」を出す
            judgeLabel.color = Color.blue;
            judgeLabel.text = "不正解";

            // NextQuiz()で使う
            g_judgeData = "不正解";
            if (qCount == 0)
            {
                Heart = GameObject.Find("ハートのマーク2");
                Heart.SetActive(false);
            }

            else if (qCount == 1)
            {
                Heart2 = GameObject.Find("ハートのマーク1");
                Heart2.SetActive(false);
            }
            else if (qCount == 2)
            {
                Heart3 = GameObject.Find("ハートのマーク");
                Heart3.SetActive(false);
            }
        }
    }


}
