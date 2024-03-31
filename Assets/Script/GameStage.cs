using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStage : MonoBehaviour
{
    public static GameStage Instance;

    [Header("몬스터 생성 관리")]
    public int spawnEnemyCount;
    public int waveCount = 1;
    public int maxWave;
    public bool stageClear;
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    [Header("스테이지 클리어 UI")]
    public GameObject clearGameUI;

    private void Awake() // 싱글톤 선언
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CreateEnemy(waveCount);
    }

    private void Update()
    {
        if(spawnEnemyCount <= 0 && !stageClear)
        {
            waveCount++; //waveCount = waveCount +1;와 같음(waveCount에 1을 더해주는 코드)
            WaveProcess();
        }

        if (stageClear)
        {
            clearGameUI.SetActive(true);
        }
    }

    private void WaveProcess()
    {
        if(waveCount > maxWave)
        {
            stageClear = true;
            return;
        }
        else
        {
            CreateEnemy(waveCount);
        }
    }

    private void CreateEnemy(int spawnCount)
    {
        for(int i = 0; i < spawnCount; i++) 
        {
            Instantiate(enemyPrefab, SetCharacterPosition().position, Quaternion.identity);
            spawnEnemyCount++;
        }
    }

    private Transform SetCharacterPosition()
    {
        int selectPos = UnityEngine.Random.RandomRange(0, spawnPositions.Length);
        return spawnPositions[selectPos];
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("NewIntro");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
