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

        //���� ��� �� ȣ��. (���� �ҷ� ���� �� ������ �ٸ� �۾��� �Ұ��� �ϴ�)
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false; // ���� ������ �ڵ����� �ش� ������ �̵��� ���ΰ�? 1. �� �ε� �ӵ� ����, ����ũ �ε� 2. ���� ������ ���ҽ��� �о�;� �ϴ� ��Ȳ

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
