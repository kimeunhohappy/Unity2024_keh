using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image ProgressBar;
    static string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    ProgressBar.fillAmount += 0.1f;
        //}
    }

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("MyLoadingScene");
    }
    IEnumerator LoadSceneProcess()
    {
        yield return new WaitForSeconds(0.3f);

        //동기 방식 씬 호출. (씬을 불러 오기 전 까지는 다른 작업이 불가능 하다)
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false; // 씬이 끝나면 자동으로 해당 씬으로 이동할 것인가? 1. 씬 로딩 속도 제어, 페이크 로딩 2. 에셋 번들을 리소스로 읽어와야 하는 상황

        float timer = 0f;
        while (!operation.isDone)
        {
            yield return null;

            if (operation.progress < 0.9f)
            {
               ProgressBar.fillAmount = operation.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                ProgressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (ProgressBar.fillAmount >= 1f)
                {
                    yield return new WaitForSeconds(1.7f);
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }

        }
    }
}
