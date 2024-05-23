using UnityEngine;

public class SoundSceneInitializer : MonoBehaviour
{
    // 슬라이더 호출 시 재설정
    private void Start()
    {
        AudioManager audioManager = AudioManager.Instance;
        if (audioManager != null)
        {
            audioManager.ReinitializeSliders();
        }
    }
}
