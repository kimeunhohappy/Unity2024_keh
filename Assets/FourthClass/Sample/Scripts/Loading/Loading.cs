using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image progressbar;
    static string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            progressbar.fillAmount += 0.1f;
        }
    }
    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadSceneProcess()
    {
        yield return new WaitForSeconds(0.3f);

        //���� ��� �� ȣ��. (���� �ҷ� ���� �� ������ �ٸ� �۾��� �Ұ��� �ϴ�)
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false; // ���� ������ �ڵ����� �ش� ������ �̵��� ���ΰ�? - 1. �� �ε� �ӵ� ����, ����ũ �ε� 2. ���� ������ ���ҽ��� �о�;� �ϴ� ��Ȳ

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressbar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressbar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressbar.fillAmount >= 1f)
                {
                    yield return new WaitForSeconds(1.7f);
                    op.allowSceneActivation = true;
                }
                yield return null;
            }

        }
    }
}
