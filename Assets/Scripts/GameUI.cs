/*
作者名称:YHB

脚本作用:根据游戏状态来更改UI的显示

建立时间:2016.7.29.19.45
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    #region 奖牌图片数组
    public Sprite[] medals;
    #endregion

    #region 私有字段 Awke赋值
    private GameObject _Logo;
    private GameObject _Start;
    private GameObject _Ladder;
    private GameObject _Ready;
    private GameObject _Tutorial;
    private GameObject _Score;
    private GameObject _Over;
    private GameObject _New;
    private Text _PanelScore;
    private Text _PanelBest;
    private Image _PanelMedal;
    #endregion

    #region Awake赋值
    void Awake()
    {
        _Logo = this.transform.FindChild("Logo").gameObject;
        _Start = this.transform.FindChild("Start").gameObject;
        _Ladder = this.transform.FindChild("Ladder").gameObject;
        _Ready = this.transform.FindChild("Ready").gameObject;
        _Tutorial = this.transform.FindChild("Tutorial").gameObject;
        _Score = this.transform.FindChild("Score").gameObject;
        _Over = this.transform.FindChild("Over").gameObject;
        _New = _Over.transform.Find("Panel/New").gameObject;
        _PanelScore = _Over.transform.Find("Panel/Score").GetComponent<Text>();
        _PanelBest = _Over.transform.Find("Panel/Best").GetComponent<Text>();
        _PanelMedal = _Over.transform.Find("Panel/Medal").GetComponent<Image>();
    }
    #endregion

    #region 更新UI的方法---外调
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

    #region 更新分数的方法---外调
    public void UpdateScore(int score)
    {
        _Score.GetComponent<Text>().text = score.ToString();
    }
    #endregion

    #region 更新分数和奖牌图片
    public void UpdateResult(int score, int best, bool newScore)
    {
        _New.SetActive(newScore);

        _PanelScore.text = score.ToString();
        _PanelBest.text = best.ToString();

        Sprite m = null;

        if (score < 66)
        {
            m = medals[0];
        }
        else if (score >= 66 && score < 666)
        {
            m = medals[1];
        }
        else if (score >= 666 && score < 666666)
        {
            m = medals[2];
        }
        else
        {
            m = medals[3];
        }

        _PanelMedal.sprite = m;

        iTween.MoveFrom(
            _Over,
            iTween.Hash(
           "y", -300,
           "easyType", iTween.EaseType.easeOutExpo,
           "loopType", iTween.LoopType.none,
           "time", 0.3f));
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
