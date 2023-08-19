using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Sprite MusicOnIcon;
    public Sprite MusicOffIcon;
    public AudioMixer AudioMixer;

    private bool _isMusicOn = true;
    private Image _buttonImage;

    public void ToggleMusic()
    {
        _isMusicOn = !_isMusicOn;
        float musicVolume = _isMusicOn ? -5 : -80;
        AudioMixer.SetFloat("MusicVolume", musicVolume);
        _buttonImage.sprite = _isMusicOn ? MusicOnIcon : MusicOffIcon;
    }

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }
}
