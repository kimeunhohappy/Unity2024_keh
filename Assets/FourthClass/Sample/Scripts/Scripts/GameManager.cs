using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 싱글톤 패턴
    // Single : 클래스를 한 개만 존재하도록 구성하고,이를 참조해서
    // 다른 클래스에서 이 클래스를 불러와서 사용할 수 있게 한다.

    // 싱글톤 패턴의 목적:싱글톤을 너무 많이 사용하지 말라.
    // 하나의 클래스에 너무 많은 데이터를 담게 되는 단점이 있으며,
    // static 싱글톤을 구현을 하는데, 게임이 종료될 때까지 메모리가
    // 계속 남아있는 문제점이 있습니다.

    // [디자인 패턴] 클래스간의 좋은 설계를 할 수 있는 관계(상속 관계)를
    // 정해놓고 그 방식을 따라서 만들도록 하게 한 것.
    // 기본 문법&선언 방법
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

    //void Awake()함수는 항상 void Start()함수보다 먼저 실행됩니다.

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
    // static으로 선언한 변수는 클래스 이름만으로 바로 접근할 수 있는 장점이 있습니다.
    // 왜 모든 변수를 static으로 선언하지 않을까요?
    // 1.GameManager 안에 있는 모든 static으로 선언한 변수의 이름을 모두 알고 있어야 합니다.
    // 2.static으로 선언한 변수는 프로그램이 종료될 때까지 계속 남아 있습니다.

    public float Coin;

    public bool IsPlayerDeath;

    // static : 클래스 호출&인스턴스 호출

    #endregion
    private void SetGameSetting()
    {
        IsPlayerDeath = false;
        // 초기화 예시
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
        //이름이 정확하지 않으면 에러가 발생하기에
        //Ctrl+C Ctrl+V로 이름을 가져와 씁니다.
        SetGameSetting();
        SceneManager.LoadScene("SampleScene");
    }

}