/*
作者名称:YHB

脚本作用:使Logo的UI上下浮动

建立时间:2016.7.29.20.26
*/

using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour
{
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", -66, "easyType", iTween.EaseType.linear, "loopType", iTween.LoopType.pingPong, "time", 0.9f));
    }
}
