using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    // 씬 전환 (sceneNum = 빌드 세팅 참고)
    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    // 판넬 활성화 (panel = 활성화할 판넬 오브젝트)
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f; // 게임 일시 중/
    }

    // 판넬 비활성화 (panel = 비활성화활 판넬 오브젝트
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f; //게임 재개
    }

    // 게임 종료
    public void QuitGame()
    {
        // 구동 환경이 유니티 에디터일 경우
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // 구동 환경이 응용프로그램일 경우
        #else
            Application.Quit();
        #endif
    }
}
