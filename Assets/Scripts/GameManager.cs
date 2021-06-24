using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FlappyBird
{
    /// <summary>
    /// 游戏运行状态
    /// </summary>
    public enum GameState 
    {
        Ready,
        Gameing,
        GameOver
    }


    public class GameManager : MonoBehaviour
    {
        
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
                switch(value) 
                {
                    case GameState.Ready:
                        Init();
                        break;
                    case GameState.Gameing:
                        Begin();
                        break;
                    case GameState.GameOver:
                        End();
                        break;
                }
            }
        }

        private int m_score;
        private int m_best_score;
        public int Score 
        { 
            set
            {
                m_score = value; 
                if (value > m_best_score)
                {
                    m_best_score = value;
                    bestScoreEndGame.text = m_best_score.ToString();
                }
                setScore();
            }
        }

        public TextMeshProUGUI scoreInGame;
        
        public Transform scoreBoard;
        private TextMeshProUGUI scoreEndGame;
        private TextMeshProUGUI bestScoreEndGame;

        public Player bird;
        public PipeCreator pipe;
        public Button playBtn1;
        public Button playBtn2;
        public Sprite _play;
        public Sprite _pause;


        bool isPaused;

        void Start()
        {
            scoreEndGame = scoreBoard.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            bestScoreEndGame = scoreBoard.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

            AddAllListeners();
            status = GameState.Ready;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        private void Init()
        {
            bird.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            pipe.clearAllPipes();
            bird.animator.SetTrigger("idle");
            bird.rb.gravityScale = 0.0f;
            bird.rb.velocity = new Vector2(0.0f, 0.0f);
            playBtn1.gameObject.SetActive(true);
            playBtn2.gameObject.SetActive(false);
            scoreInGame.transform.parent.gameObject.SetActive(false);
            scoreBoard.gameObject.SetActive(false);
            Score = 0;
        }

        private void Begin()
        {
            bird.onEnterGame = true;
            bird.animator.SetTrigger("fly");
            bird.rb.gravityScale = 500.0f;
            pipe.OnEnterGame();
            playBtn1.gameObject.SetActive(false);
            playBtn2.gameObject.SetActive(true);
            scoreInGame.transform.parent.gameObject.SetActive(true);
            scoreBoard.gameObject.SetActive(false);
        }

        private void End()
        {
            pause();
            bird.onEnterGame = false;
            pipe.OnExitGame();
            playBtn1.gameObject.SetActive(true);
            playBtn2.gameObject.SetActive(false);
            scoreInGame.transform.parent.gameObject.SetActive(false);
            scoreBoard.gameObject.SetActive(true);
        }

        private void resume()
        {
            Time.timeScale = 1.0f;
        }

        private void pause()
        {
            Time.timeScale = 0.0f;
        }
        private void setScore()
        {
            scoreInGame.text = m_score.ToString();
            scoreEndGame.text = m_score.ToString();
        }

        private void AddAllListeners()
        {
            playBtn1.onClick.AddListener(()=>
            {
                if (status == GameState.GameOver)
                {
                    resume();
                    status = GameState.Ready;
                }
                else
                {
                    status = GameState.Gameing;
                    bird.rb.velocity = new Vector2(0.0f, 1500.0f);
                }
                    
            });

            playBtn2.onClick.AddListener(()=>
            {
                if (isPaused)
                {
                    playBtn2.GetComponent<Image>().sprite = _play;
                    resume();
                    isPaused = false;
                }
                else
                {
                    playBtn2.GetComponent<Image>().sprite = _pause;
                    pause();
                    isPaused = true;
                }
            });

            Pipe.trigged += () => {
                status = GameState.GameOver;
            };

            Pipe.passed += () => {
                Score = m_score + 1;
            };

            Platform.collied += () => {
                status = GameState.GameOver;
            };
        }
    }

}