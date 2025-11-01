using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance { get; private set; }

    [SerializeField] private List<AudioClip> _audioClips = new();

    private AudioSource audioSource;

    private void Awake()
    {
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        audioInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTheGoodSound(int index)
    {

        audioSource.PlayOneShot(_audioClips[index]);
        Debug.Log("Sound n°" + index + " has been played successfully !");
    }
}
