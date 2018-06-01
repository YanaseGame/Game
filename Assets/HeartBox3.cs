
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeartBox3 : MonoBehaviour
{

    public bool dontDestroyEnabled = true;

    private static GameObject instance = null;

    public static GameObject Instance
    {
        get { return instance; }
    }

    void Awake()
    {

        if (instance != null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this.gameObject;
        }

        instance = this.gameObject;

        DontDestroyOnLoad(this.gameObject);

    }
    public static void DeleteInstance2()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }
    public static void OnDestroy()
    {
        Destroy(instance.gameObject);
        //登録を解除
        instance = null;
    }
}
