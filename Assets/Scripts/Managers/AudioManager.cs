using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource player;
    public AudioClip[] garenSkill;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmslider;
    

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

        InitializeSliders();
        ApplyAudioSettings();

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        bgmslider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void InitializeSliders()
    {
        if (masterSlider != null)
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        if (sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        if (bgmslider != null)
            bgmslider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
    }

    private void ApplyAudioSettings()
    {
        if (masterSlider != null) SetMasterVolume(masterSlider.value);
        if (sfxSlider != null) SetSFXVolume(sfxSlider.value);
        if (bgmslider != null) SetMusicVolume(bgmslider.value);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void ReinitializeSliders()
    {
        // 슬라이더를 다시 찾아 할당합니다.
        masterSlider = GameObject.Find("MasterSlider")?.GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider")?.GetComponent<Slider>();
        bgmslider = GameObject.Find("BGMSlider")?.GetComponent<Slider>();

        // 슬라이더 값 초기화
        InitializeSliders();

        // 오디오 설정 적용
        ApplyAudioSettings();

        // 슬라이더 이벤트 추가
        if (masterSlider != null)
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        if (bgmslider != null)
            bgmslider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void GarenSkillSound(int index)
    {
        player.PlayOneShot(garenSkill[index]);
    }
}
