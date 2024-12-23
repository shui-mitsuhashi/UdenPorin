using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;//全体音量
    public Slider bgmVolumeSlider;//BGM音量
    public Slider seVolumeSlider;//SE音量

    private AudioSource bgmSource;
    private AudioSource seSource;
    // Start is called before the first frame update
    void Start()
    {
        //初期値の設定
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        seVolumeSlider.value = PlayerPrefs.GetFloat("SEVolume", 1.0f);

        //オーディオソースの取得
        bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        seSource = GameObject.Find("SE").GetComponent<AudioSource>();

        ApplyVolumeSettings();
    }

    public void ApplyVolumeSettings()
    {
        float masterVolume = masterVolumeSlider.value;
        float bgmVolume = bgmVolumeSlider.value;
        float seVolume = seVolumeSlider.value;

        //音量を適用
        AudioListener.volume = masterVolumeSlider.value;
        if(bgmSource != null)bgmSource.volume = bgmVolume;
        if(seSource != null)seSource.volume = seVolume;

        //設定を保存
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
        PlayerPrefs.SetFloat("SEVolume", seVolumeSlider.value);
        PlayerPrefs.Save();
    }
}
