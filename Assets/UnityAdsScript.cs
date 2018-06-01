using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour
{

//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//広告を出す
//━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    public void ShowAd()
    {
        // ゲームIDを入力して、Unity Adsを初期化する
        Advertisement.Initialize("12345678");

        // Unity Adsを表示する準備ができているか確認する
        if (Advertisement.IsReady())
        {
            // Unity Adsを表示する
            Advertisement.Show();
        }
    }
}