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
        [SerializeField] private Slider soundEffectVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;

        // Update is called once per frame
        void Update()
        {
        
        }

        public void PlaySoundEffect(AudioClip clip)
        {
            
        }
    }
}
