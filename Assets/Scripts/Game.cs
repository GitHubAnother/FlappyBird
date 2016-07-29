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
    public GameUI gameUI;
    public Bird bird;
    #endregion

    #region 单例
    private static Game Instance = null;

    public static Game _i
    {
        get
        {
            return Instance;
        }
    }

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region 私有字段  游戏状态
    private GameState state = GameState.Init;

    public GameState gameState
    {
        get
        {
            return state;
        }

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
        OnGameState += Game_OnGameState;//监听事件

        GotoInit();//初始化Init
    }

    private void Game_OnGameState(GameState obj)
    {
        switch (state)
        {
            case GameState.Init:
                bird.IsVisible = false;
                gameUI.UpdateUI(state);
                break;
            case GameState.Ready:
                bird.IsVisible = true;
                gameUI.UpdateUI(state);
                break;
            case GameState.Play:
                bird.IsVisible = true;
                gameUI.UpdateUI(state);
                break;
            case GameState.Over:
                bird.IsVisible = false;
                gameUI.UpdateUI(state);
                break;
            default:
                break;
        }
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
