/*
作者名称:YHB

脚本作用:控制小鸟的运动

建立时间:2016.7.30.10.22
*/

using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    #region 字段
    public bool Enable { get; set; }
    #endregion

    //事件
    public event Action OnTab = null;

    #region Update控制
    void Update()
    {
        Controller();
    }
    #endregion

    #region 控制的事件
    void Controller()
    {
        if (Enable && Input.GetMouseButtonDown(0))
        {
            if (OnTab != null)//只要事件里面至少有一个注册的方法就能执行这个事件了
            {
                OnTab();
            }
        }
    }
    #endregion
}
