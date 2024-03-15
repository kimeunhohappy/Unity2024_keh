using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region �̱��� ����
    // Single : Ŭ������ �� ���� �����ϵ��� �����ϰ�,�̸� �����ؼ�
    // �ٸ� Ŭ�������� �� Ŭ������ �ҷ��ͼ� ����� �� �ְ� �Ѵ�.

    // �̱��� ������ ����:�̱����� �ʹ� ���� ������� ����.
    // �ϳ��� Ŭ������ �ʹ� ���� �����͸� ��� �Ǵ� ������ ������,
    // static �̱����� ������ �ϴµ�, ������ ����� ������ �޸𸮰�
    // ��� �����ִ� �������� �ֽ��ϴ�.

    // [������ ����] Ŭ�������� ���� ���踦 �� �� �ִ� ����(��� ����)��
    // ���س��� �� ����� ���� ���鵵�� �ϰ� �� ��.
    // �⺻ ����&���� ���
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public object SceneManger { get; private set; }

    //void Awake()�Լ��� �׻� void Start()�Լ����� ���� ����˴ϴ�.

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // static���� ������ ������ Ŭ���� �̸������� �ٷ� ������ �� �ִ� ������ �ֽ��ϴ�.
    // �� ��� ������ static���� �������� �������?
    // 1.GameManager �ȿ� �ִ� ��� static���� ������ ������ �̸��� ��� �˰� �־�� �մϴ�.
    // 2.static���� ������ ������ ���α׷��� ����� ������ ��� ���� �ֽ��ϴ�.

    public float Coin;

    public bool IsPlayerDeath;

    // static : Ŭ���� ȣ��&�ν��Ͻ� ȣ��

    #endregion
    private void SetGameSetting()
    {
        IsPlayerDeath = false;
        // �ʱ�ȭ ����
    }

    public GameObject[] gameOverObjects;
    public void GameOver()
    {
        foreach (GameObject obj in gameOverObjects)
        {
            obj.SetActive(true); 
        }
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        //�̸��� ��Ȯ���� ������ ������ �߻��ϱ⿡
        //Ctrl+C Ctrl+V�� �̸��� ������ ���ϴ�.
        SetGameSetting();
        SceneManager.LoadScene("SampleScene");
    }

}