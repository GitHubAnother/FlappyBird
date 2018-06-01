/*
作者名称:YHB

脚本作用:音乐播放

建立时间:2016.7.30.17.58
*/

using UnityEngine;

public class Sound : MonoBehaviour
{
    #region 音乐集合
    public AudioClip[] clips;
    #endregion

    #region 单例
    public static Sound _i;
    void Awake()
    {
        _i = this;
    }
    #endregion

    #region 外调播放声音
    public void Play(string name)
    {
        AudioClip clip = null;

        foreach (AudioClip ac in clips)
        {
            if (ac.name == name)
            {
                clip = ac;
                break;
            }
        }

        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
        }
    }
    #endregion
}
