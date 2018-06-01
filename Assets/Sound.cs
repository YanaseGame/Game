using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//シーンが同じでも重複再生されないコード
public class Sound : MonoBehaviour
{
    
    public bool dontDestroyEnabled = true;
    
    //instanceにSoundを格納
    private static Sound instance = null;

    public static Sound Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        //既にinstanceに曲入っていて、新たに入った曲があれば、それを消去
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        //曲がまだなら曲スタート
        else
        {
            instance = this;
        }
        //サウンドを消去せずに維持する
        DontDestroyOnLoad(this.gameObject);
    }
    //曲をストップさせるメソッド
    public static void DeleteInstance()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
                instance = null;
            }
        }
}