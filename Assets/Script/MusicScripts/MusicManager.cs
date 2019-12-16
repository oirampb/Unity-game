using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    ///<Sumary>
    /// Metodo para poner la musica.
    ///</Sumary>

    public void PlayMusic(AudioClip audioClip)
    {
        foreach (AudioSource audioSource in _audioSource)
        {
            // Comprueba si se esta reproduciendo la musica.
            if (!audioSource.isPlaying)
            {
                useAudioSource = audioSource;
                break;
            }

        }

        // Igualamos el clip recibido al clip del audioSource.
        useAudioSource.clip = audioClip;
        // Se pone el audio una vez.
        useAudioSource.PlayOneShot(useAudioSource.clip);
    }

    ///<Sumary>
    /// Se compruba que la musica no se esta reproduciendo y se empieza a reproducir la musica predefinida.
    ///</Sumary>

    private void Update()
    {
        if (!useAudioSource.isPlaying)
        {
            useAudioSource.clip = _audioClip;
            useAudioSource.Play();
        }
    }

    ///<Sumary>
    /// Se crea en el Awake un nuevo arrayList de AudioSorce
    ///</Sumary>

    private void Awake()
    {
        _audioSource = new List<AudioSource>();
    }

    [SerializeField]
    private AudioClip _audioClip;       // Musica del juego Standard.
    public AudioSource useAudioSource = null;       // AudioSurce que se utiliza.
    private List<AudioSource> _audioSource;        //ArrayList de AudioSource.
}
