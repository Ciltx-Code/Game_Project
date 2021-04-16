using UnityEngine;

public class AudioPlaylist : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int last;
    private int random;

    void Start()
    {
        random = Random.Range(0, playlist.Length);
        last = random;
        audioSource.clip = playlist[random];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            random = Random.Range(0, playlist.Length);
            if(random != last)
            {
                audioSource.clip = playlist[random];
                audioSource.Play();
            }

        }
    }
}
