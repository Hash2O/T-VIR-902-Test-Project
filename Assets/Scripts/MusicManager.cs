using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musiques;
    [SerializeField] private AudioSource audioSource;

    private int indexActuel = 0;

    void Start()
    {
        if (musiques.Count > 0 && audioSource != null)
        {
            PlayMusic(indexActuel);
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying && musiques.Count > 0)
        {
            indexActuel++;
            if (indexActuel < musiques.Count)
            {
                PlayMusic(indexActuel);
            }
        }
    }

    void PlayMusic(int index)
    {
        audioSource.clip = musiques[index];
        audioSource.Play();
    }

    // Optionnel: pour relancer le cycle après la dernière piste
    public void RewindPlaylist()
    {
        indexActuel = 0;
        PlayMusic(indexActuel);
    }
}
