/*
作者名称:YHB

脚本作用:游戏主脚本

建立时间:2016.7.29.19.47
*/

using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour
{
    #region 公共字段 
    public Bird bird;
    public GameUI gameUI;
    public BackGround backGround;
    public ObstacleLoop obstacleLoop;
    public InputController inputController;
    public Saver saver;
    #endregion

    #region 单例
    private static Game Instance = null;

    public static Game _i
    {
        get { return Instance; }
    }

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region 私有字段-游戏状态
    private bool isFirst = false;

    private GameState state = GameState.Init;

    public GameState gameState
    {
        get { return state; }
        private set
        {
            state = value;
            if (OnGameState != null)
            {
                OnGameState(state);
            }
        }
    }
    #endregion

    #region 事件
    public event Action<GameState> OnGameState;
    #endregion

    #region Start---事件---初始化
    public void Start()
    {
        OnGameState += Game_OnGameState;//游戏状态监听事件

        bird.OnDead += Bird_OnDead;
        bird.OnHit += Bird_OnHit;
        saver.OnScoreChanged += Saver_OnScoreChanged;

        inputController.OnTab += InputController_OnTab;//控制监听事件

        GotoInit();//初始化Init
    }
    //--------------------------------------------------------------------------------
    private void Bird_OnDead()//死亡
    {
        obstacleLoop.SetPipeCollisionAll(false);

        GotoOver();

        Sound._i.Play("sfx_die");
    }
    private void Bird_OnHit()//通过了一个管道
    {
        //加分
        saver.Score += 6;

        Sound._i.Play("sfx_point");
    }
    private void Saver_OnScoreChanged(int score)//保存分数
    {
        gameUI.UpdateScore(score);
    }
    private void Game_OnGameState(GameState state)//游戏状态
    {
        switch (state)
        {
            case GameState.Init:
                saver.Score = 0;
                inputController.Enable = false;
                bird.IsVisible = false;
                bird.UseGravity = false;
                backGround.ShowBG();
                obstacleLoop.isMove = true;
                obstacleLoop.SetPipeAll(false);
                gameUI.UpdateUI(GameState.Init);
                break;
            case GameState.Ready:
                saver.Restore();
                inputController.Enable = true;
                bird.IsVisible = true;
                bird.UseGravity = false;
                bird.Reset();
                obstacleLoop.Restore();

                if (!isFirst)
                {
                    backGround.ShowBG();
                }
                else
                {
                    isFirst = false;
                }

                gameUI.UpdateScore(saver.Score);
                gameUI.UpdateUI(GameState.Ready);
                break;
            case GameState.Play:
                inputController.Enable = true;
                bird.IsVisible = true;
                bird.UseGravity = true;
                obstacleLoop.isMove = true;
                obstacleLoop.isShowPipe = true;
                gameUI.UpdateUI(GameState.Play);
                break;
            case GameState.Over:
                inputController.Enable = false;
                bird.IsVisible = true;
                bird.UseGravity = true;
                obstacleLoop.isMove = false;
                gameUI.UpdateUI(GameState.Over);
                gameUI.UpdateResult(saver.Score, saver.Best, saver.IsNewScore);
                Sound._i.Play("sfx_swooshing");
                break;
            default:
                break;
        }
    }
    private void InputController_OnTab()//控制
    {
        if (this.gameState == GameState.Ready)
        {
            GotoPlay();
        }

        //点了以后先来跳一下
        bird.Jump();

        Sound._i.Play("sfx_wing");
    }
    #endregion

    #region 4个可外调的改变游戏状态的方法 
    public void GotoInit()
    {
        this.gameState = GameState.Init;
    }
    public void GotoReady()
    {
        this.gameState = GameState.Ready;
    }
    public void GotoPlay()
    {
        this.gameState = GameState.Play;
    }
    public void GotoOver()
    {
        this.gameState = GameState.Over;
    }
    #endregion
}
