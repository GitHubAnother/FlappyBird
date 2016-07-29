/*
作者名称:YHB

脚本作用:控制小鸟的运行

建立时间:2016.7.29.20.11
*/

using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    public bool IsVisible
    {
        get
        {
            return this.gameObject.activeInHierarchy;
        }

        set
        {
            this.gameObject.SetActive(value); 
        }
    }
}
