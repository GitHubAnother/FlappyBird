/*
作者名称:YHB

脚本作用:小鸟脚本

建立时间:2016.7.29.20.11
*/

using UnityEngine;
using System.Collections;
using System;

public class Bird : MonoBehaviour
{
    #region 事件
    public event Action OnHit;//穿过管道的事件
    public event Action OnDead;//小鸟死亡事件
    #endregion

    #region 字段
    public float jumpSpeed = 9f;//小鸟跳跃速度

    private Vector3 defaultPosition = Vector3.zero;//小鸟初始位置
    private Rigidbody2D r2d;
    private Animator anim;
    #endregion

    #region 属性---设置小鸟隐藏或显示,设置小鸟是否启用重力
    public bool IsVisible
    {
        get { return this.gameObject.activeSelf; }
        set { this.gameObject.SetActive(value); }
    }
    public bool UseGravity
    {
        get { return r2d.gravityScale == 1; }//如果返回true表示重力值为1（正常值）就是启用了重力
        set { r2d.gravityScale = value ? 1 : 0; }//true启用重力false关闭重力
    }
    #endregion

    #region Awake组件赋值和注册事件
    public void Awake()
    {
        defaultPosition = this.transform.position;

        r2d = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        //OnHit += Bird_OnHit;
        OnDead += Bird_OnDead;
    }
    #endregion

    #region 外调---跳跃，死亡，重置
    public void Jump()
    {
        r2d.velocity = Vector3.up * jumpSpeed;
    }
    public void Dead()//关闭动画
    {
        anim.enabled = false;
    }
    public void Reset()//重置小鸟位置，关闭重力，播放动画
    {
        this.transform.position = defaultPosition;
        UseGravity = false;
        anim.enabled = true;
    }
    #endregion

    #region 事件注册的方法
    private void Bird_OnDead()//死亡
    {
        Dead();
    }
    #endregion

    //触发检测
    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
