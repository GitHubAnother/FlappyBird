/*
作者名称:YHB

脚本作用:切换背景

建立时间:2016.7.30.10.01
*/

using UnityEngine;

public class BackGround : MonoBehaviour
{
    #region 字段
    public Sprite[] bgArray;

    private SpriteRenderer bgSprite;
    #endregion

    #region Start获取SpriteRenderer组件
    void Start()
    {
        bgSprite = this.GetComponent<SpriteRenderer>();
    }
    #endregion

    #region 外调切换背景方法
    public void ShowBG()
    {
        bgSprite.sprite = bgArray[RandomIndex()];
    }

    //索引随机方法
    int RandomIndex()
    {
        int bgIndex = 0;
        bgIndex = Random.Range(0, bgArray.Length);
        return bgIndex;
    }
    #endregion
}
