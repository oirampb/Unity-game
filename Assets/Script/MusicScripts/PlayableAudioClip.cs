using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAudioClip : MonoBehaviour
{
    public MusicManager _musicManager;
    public AudioClip _audioClipKino;

    ///<Sumary>
    /// Comprobamos si el jugador entra en el collider y ejecutamos la musica desde el MusicManager.
    ///</Sumary>

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag.Equals("Player"))
        {
            if (_musicManager.useAudioSource.isPlaying)
            {
                _musicManager.useAudioSource.Stop();
                _musicManager.PlayMusic(_audioClipKino);
                Destroy(gameObject);
            }
        }
    }
}
