using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject StopPanel;

    // 씬 전환 (sceneNum = 빌드 세팅 참고)
    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void GameStart()
    {
        GameManager.Instance.GameStart();
    }

    public void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void GamePauseOrPlay()
    {
        if (StopPanel == null) return;
        if (!StopPanel.activeSelf)
        {
            GameManager.Instance.GamePause();
            OpenPanel(StopPanel);
        }
        else
        {
            GameManager.Instance.GamePlay();
            ClosePanel(StopPanel);
        }
    }

    // 판넬 활성화 (panel = 활성화할 판넬 오브젝트)
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
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
