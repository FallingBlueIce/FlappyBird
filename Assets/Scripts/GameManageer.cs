using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManageer : MonoBehaviour
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

    /// <summary>
    /// 当前游戏界面
    /// </summary>
    public GameState m_State;

    /// <summary>
    /// 开始按钮
    /// </summary>
    public Button startBtn;

    /// <summary>
    /// 游戏计分板
    /// </summary>
    public GameObject scoreBoard;

    /// <summary>
    ///  小鸟
    /// </summary>
    public Rigidbody2D bird;

    /// <summary>
    ///  管道
    /// </summary>
    public GameObject pipe;

    /// <summary>
    /// 游戏暂停状态
    /// </summary>
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        m_State = GameState.GameReady;

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case GameState.GameReady:

                break;
            case GameState.Gaming:
                bird.gravityScale = 800;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    bird.velocity = new Vector2(0, 2250);
                }

                if (bird.velocity.y > 0)
                    bird.rotation = 15.0f;
                else
                    bird.rotation = Mathf.Clamp(bird.velocity.y, -1800.0f, 0.0f) * 0.02f;
                break;
            case GameState.GameOver:
                bird.transform.GetComponent<Animation>().Stop();

                break;
        }
    }
}
