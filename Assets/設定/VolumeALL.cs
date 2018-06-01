using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeALL : MonoBehaviour
{

    public UnityEngine.Audio.AudioMixer mixer;

    // インスペクター上からスライダーのオブジェクトを登録
    public Slider targetSlider;

    void Start()
    {
        float volume;

        // mixer.GetFloat()の値は、volumeに代入される
        // 返り値は、パラメーターが存在しない場合にfalseになるといった具合
        if (mixer.GetFloat("Master", out volume))
        {
            targetSlider.value = volume;
        }
    }

    public void masterVol(Slider slider)
    {
        mixer.SetFloat("Master", slider.value);
    }
}