using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCAudio : MonoBehaviour
{
    public GameObject objectMusic;
    private AudioSource _audioSource;

    private float _audioVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        objectMusic = GameObject.FindWithTag("GameMusic");
        _audioSource = objectMusic.GetComponent<AudioSource>();
        _audioVolume = PlayerPrefs.GetFloat("volume");
        _audioSource.volume = _audioVolume;
        
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = _audioVolume;
        PlayerPrefs.SetFloat("volume",_audioVolume);
    }

    public void UpdateVolume(float volume)
    {
        _audioVolume = volume;
    }
}
