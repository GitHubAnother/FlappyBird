/*
作者名称:YHB

脚本作用:保存数据

建立时间:2016.7.30.17.44
*/

using UnityEngine;
using System;

public class Saver : MonoBehaviour
{
    #region 分数事件
    public event Action<int> OnScoreChanged;
    #endregion

    #region 字段  属性
    private int _Score = 0;
    private bool isNewScore = false;

    public int Score
    {
        get
        {
            return _Score;
        }

        set
        {
            _Score = value;

            if (OnScoreChanged != null)
            {
                OnScoreChanged(_Score);
            }
        }
    }
    public bool IsNewScore
    {
        get
        {
            return isNewScore;
        }
    }
    #endregion

    #region 事件监听
    void Awake()
    {
        OnScoreChanged += Saver_OnScoreChanged;
    }

    private void Saver_OnScoreChanged(int score)
    {
        if (_Score > Best)
        {
            Best = _Score;
            isNewScore = true;
        }
    }
    #endregion

    #region 外调设置最高分数
    public int Best
    {
        get { return PlayerPrefs.GetInt("Best", 0); }
        private set { PlayerPrefs.SetInt("Best", value); }
    }
    #endregion

    #region 外调重置方法
    public void Restore()
    {
        _Score = 0;
        isNewScore = false;
    }
    #endregion

    #region 清除方法
    public void Clear()
    {
        Best = 0;
    }
    #endregion
}
