using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource player;
    public AudioClip[] garenSkill;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = gameObject.GetComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void GarenSkillSound(int index)
    {
        player.PlayOneShot(garenSkill[index]);
    }
}
