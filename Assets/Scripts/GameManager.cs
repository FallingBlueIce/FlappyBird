using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 游戏运行状态
    /// </summary>
    public enum GameState
    {
        GameReady,
        Gaming,
        GameOver
    }

    private GameState m_Status;
    
    /// <summary>
    /// 当前游戏界面
    /// </summary>
    public GameState status
    {
        get
        {
            return m_Status;
        }
        set
        {
            m_Status = value;
        }
    }

    /// <summary>
    /// 游戏准备界面
    /// </summary>
    public GameObject GameReady;

    /// <summary>
    /// 游戏中界面
    /// </summary>
    public GameObject Gaming;

    /// <summary>
    /// 游戏结束界面
    /// </summary>
    public GameObject GameOver;

    private int m_score;
    public int score { get { return m_score; } set { m_score = value; } }
    public int bestScore;

    public TMPro.TextMeshProUGUI scoreInGame;
    public TMPro.TextMeshProUGUI scoreEndGame;
    public TMPro.TextMeshProUGUI bestScoreEndGame;

    public GameObject bird;
    public GameObject pipe;
    public Sprite _play;
    public Sprite _pause;

    private Animator birdAnim;
    private Rigidbody2D birdRb;
    private GameObject playBtn;


    private bool isPaused;

    void Start()
    {

        // 播放按钮1
        GameReady.GetComponentInChildren<Button>().onClick.AddListener(() => {
            status = GameState.Gaming;
            birdAnim.SetBool("fly", true);
            GameReady.SetActive(false);
            Gaming.SetActive(true);
            pipe.SetActive(true);
            score = 0;
            birdRb.velocity = new Vector2(0, 1800);
        });

        // 播放按钮2
        playBtn = Gaming.transform.GetChild(0).gameObject;
        Sprite img = playBtn.GetComponent<Image>().sprite;
        playBtn.GetComponent<Button>().onClick.AddListener(() => {
            if (isPaused)
            {
                playGame();
                isPaused = false;
            }
            else
            {
                pauseGame();
                isPaused = true;
            }
                
        });

        // 播放按钮3
        GameOver.transform.Find("ScoreBoard/PlayBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameOver.SetActive(false);
            GameReady.SetActive(true);
            status = GameState.GameReady;
            int size = pipe.transform.childCount;
            for (int i = 0; i < size; i++)
            {
                Destroy(pipe.transform.GetChild(i).gameObject);
            }
            pipe.SetActive(false);
            birdAnim.SetBool("fly", false);
        });

        // 小鸟
        birdAnim = bird.GetComponentInChildren<Animator>();
        birdRb = bird.GetComponent<Rigidbody2D>();
        bird.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GameReady.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_Status)
        {
            case GameState.GameReady:
                if (Time.timeScale != 1.0f)
                    Time.timeScale = 1.0f;
                if (birdAnim.GetBool(0))
                    birdAnim.SetBool("fly", false);
                birdRb.transform.localPosition = new Vector3(-100, 0, 0);
                if (birdRb.gravityScale != 0)
                    birdRb.gravityScale = 0;
                if (birdRb.rotation != 0)
                    birdRb.rotation = 0;
                if (birdRb.velocity != Vector2.zero)
                    birdRb.velocity = Vector2.zero;

                break;
            case GameState.Gaming:

                if (birdRb.gravityScale == 0)
                    birdRb.gravityScale = 600;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    birdRb.velocity = new Vector2(0, 1800);
                }

                if (birdRb.velocity.y > 0)
                    birdRb.rotation = Mathf.Clamp(birdRb.velocity.y, 0.0f, 1800.0f) * 0.01f;
                else
                    birdRb.rotation = Mathf.Clamp(birdRb.velocity.y, -1800.0f, 0.0f) * 0.02f;

                scoreInGame.text = score.ToString();

                break;
            case GameState.GameOver:
                
                break;
        }

        if (score > bestScore)
            bestScore = score;
    }


    private void playGame()
    {

        playBtn.GetComponent<Image>().sprite = _play;
        Time.timeScale = 1.0f;
    }

    private void pauseGame()
    {
        playBtn.GetComponent<Image>().sprite = _pause;
        Time.timeScale = 0.0f;
    }
}
