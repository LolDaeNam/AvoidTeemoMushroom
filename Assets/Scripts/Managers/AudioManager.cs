using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;         // 오디오 소스 컴포넌트 (배경음악)
    public AudioClip audioClip;             // 오디오 클립 (배경음악)

    public AudioSource player;              // 오디오 소스 컴포넌트 (플레이어 캐릭터)
    public AudioClip[] garenSkill;          // 오디오 클립 (플레이어 캐릭터 스킬 사운드)

    [SerializeField] private AudioMixer audioMixer; // 오디오 믹서
    [SerializeField] private Slider masterSlider;   // 마스터 볼륨 슬라이더
    [SerializeField] private Slider sfxSlider;      // 효과음 슬라이더
    [SerializeField] private Slider bgmslider;      // 배경음악 슬라이더
    

    private void Awake()
    {
        // 싱글톤
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

        // 배경음악 재생
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();

        // 슬라이더 초기화
        InitializeSliders();
        // 슬라이더 설정 적용
        ApplyAudioSettings();

        // 슬라이더에 리스너 장착
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        bgmslider.onValueChanged.AddListener(SetMusicVolume);
    }

    // 슬라이더 초기화
    private void InitializeSliders()
    {
        if (masterSlider != null)
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        if (sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        if (bgmslider != null)
            bgmslider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
    }

    // 슬라이더 설정 적용
    private void ApplyAudioSettings()
    {
        if (masterSlider != null) SetMasterVolume(masterSlider.value);
        if (sfxSlider != null) SetSFXVolume(sfxSlider.value);
        if (bgmslider != null) SetMusicVolume(bgmslider.value);
    }

    // 마스터 볼륨 설정
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    // 효과음 볼륨 설정
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    // 배경음악 볼륨 설정
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    // 슬라이더 재설정
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

    // 플레이어 캐릭터 스킬 사운드 출력
    public void GarenSkillSound(int index)
    {
        player.PlayOneShot(garenSkill[index]);
    }
}
