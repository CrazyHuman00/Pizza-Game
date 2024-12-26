using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GameManager
{
    /// <summary>
    /// 音量の調整をする。
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider sEVolumeSlider;

        private void Start()
        {
            bgmVolumeSlider.onValueChanged.AddListener(SetAudioMixerBGM);
            sEVolumeSlider.onValueChanged.AddListener(SetAudioMixerSe);
        }

        private void SetAudioMixerBGM(float bgmVolume)
        {
            audioMixer.SetFloat("BGM", AdjustStepVolume(bgmVolume));
            Debug.Log($"BGM Volume: {AdjustStepVolume(bgmVolume)}");
        }

        private void SetAudioMixerSe(float sEVolume)
        {
            audioMixer.SetFloat("BGM", AdjustStepVolume(sEVolume));
            Debug.Log($"BGM Volume: {AdjustStepVolume(sEVolume)}");
        }

        private static float AdjustStepVolume(float volume)
        {
            volume /= 5;
            return Mathf.Clamp(Mathf.Log10(volume) * 20f,-80f,0f);
        }
    }
}
