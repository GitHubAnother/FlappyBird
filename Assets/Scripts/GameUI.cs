/*
作者名称:YHB

脚本作用:根据游戏状态来更改UI的显示

建立时间:2016.7.29.19.45
*/

using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
    #region 私有字段 Awke赋值
    private GameObject _Logo;
    private GameObject _Start;
    private GameObject _Ladder;
    private GameObject _Ready;
    private GameObject _Tutorial;
    private GameObject _Score;
    private GameObject _Over;
    #endregion

    #region Unity内置函数
    void Awake()
    {
        _Logo = this.transform.FindChild("Logo").gameObject;
        _Start = this.transform.FindChild("Start").gameObject;
        _Ladder = this.transform.FindChild("Ladder").gameObject;
        _Ready = this.transform.FindChild("Ready").gameObject;
        _Tutorial = this.transform.FindChild("Tutorial").gameObject;
        _Score = this.transform.FindChild("Score").gameObject;
        _Over = this.transform.FindChild("Over").gameObject;
    }
    #endregion

    #region 更新UI的方法
    public void UpdateUI(GameState state)
    {
        switch (state)
        {
            case GameState.Init:
                Init();
                break;
            case GameState.Ready:
                Ready();
                break;
            case GameState.Play:
                Play();
                break;
            case GameState.Over:
                Over();
                break;
            default:
                break;
        }
    }
    #endregion

    #region 4个状态方法
    void Init()
    {
        _Logo.SetActive(true);
        _Start.SetActive(true);
        _Ladder.SetActive(true);
        _Ready.SetActive(false);
        _Tutorial.SetActive(false);
        _Score.SetActive(false);
        _Over.SetActive(false);
    }
    void Ready()
    {
        _Logo.SetActive(false);
        _Start.SetActive(false);
        _Ladder.SetActive(false);
        _Ready.SetActive(true);
        _Tutorial.SetActive(true);
        _Score.SetActive(false);
        _Over.SetActive(false);
    }
    void Play()
    {
        _Logo.SetActive(false);
        _Start.SetActive(false);
        _Ladder.SetActive(false);
        _Ready.SetActive(false);
        _Tutorial.SetActive(false);
        _Score.SetActive(true);
        _Over.SetActive(false);
    }
    void Over()
    {
        _Logo.SetActive(false);
        _Start.SetActive(false);
        _Ladder.SetActive(false);
        _Ready.SetActive(false);
        _Tutorial.SetActive(false);
        _Score.SetActive(false);
        _Over.SetActive(true);
    }
    #endregion
}
