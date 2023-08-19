using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Sprite SoundOnIcon;
    public Sprite SoundOffIcon;

    private Image _buttonImage;
    private bool _isSoundOn = true;
    
    public void ToggleSound()
    {
        _isSoundOn = !_isSoundOn;
        float soundVolume = _isSoundOn ? 0 : -80;
        AudioMixer.SetFloat("EffectsVolume", soundVolume);
        _buttonImage.sprite = _isSoundOn ? SoundOnIcon : SoundOffIcon;
    }

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }
}
