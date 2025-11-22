using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager _instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // Spawn gameobject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // Set clip
        audioSource.clip = audioClip;

        // Set volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get clip length
        float clipLength = audioSource.clip.length;

        // Destroy gameobject after clip length
        Destroy(audioSource.gameObject, clipLength);
    }

    
    public void PlayRandomSoundFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume)
    {
        // Random index
        int rndIndex = Random.Range(0, audioClips.Length);

        // Spawn gameobject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // Set clip
        audioSource.clip = audioClips[rndIndex];

        // Set volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get clip length
        float clipLength = audioSource.clip.length;

        // Destroy gameobject after clip length
        Destroy(audioSource.gameObject, clipLength);
    }
    
}
