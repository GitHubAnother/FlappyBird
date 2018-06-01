/*
作者名称:YHB

脚本作用:障碍物管理

建立时间:2016.7.30.14.39
*/

using UnityEngine;

public class ObstacleLoop : MonoBehaviour
{
    #region 常量
    public const float LEFT = -6.72f;
    public const float CENTER = 0f;
    public const float RIGHT = 6.72f;
    public const float MAX = 0.55f;
    public const float MIN = -5.25f;
    #endregion

    #region 字段
    public float moveSpeed = 1.6f;
    public bool isShowPipe = false;
    public bool isMove = false;
    public GameObject[] obstacles;

    private Vector3[] defaultPosition;
    #endregion

    #region Awake赋值 Update每帧移动
    void Awake()
    {
        defaultPosition = new Vector3[obstacles.Length];

        for (int i = 0; i < obstacles.Length; i++)
        {
            defaultPosition[i] = obstacles[i].transform.localPosition;
        }
    }
    void Update()
    {
        Move();
    }
    #endregion

    #region 外调---1.显示所有的pipe  2.根据参数来显示指定的pipe
    public void SetPipeAll(bool visible)
    {
        foreach (GameObject obstacle in obstacles)
        {
            SetPipe(obstacle, visible);
        }
    }
    public void SetPipe(GameObject obstacle, bool visible)
    {
        foreach (Transform child in obstacle.transform)
        {
            if (child.name == "Pipe")
            {
                child.gameObject.SetActive(visible);
            }
        }
    }
    #endregion

    #region 可外调---Restore
    public void Restore()
    {
        //还原位置
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].transform.localPosition = defaultPosition[i];
        }

        isMove = true;//移动

        //pipe不可见
        isShowPipe = false;
        SetPipeAll(false);

        //启用碰撞
        SetPipeCollisionAll(true);
    }
    #endregion

    #region 移动方法
    void Move()
    {
        if (!isMove)
        {
            return;
        }

        for (int i = 0; i < obstacles.Length; i++)
        {
            GameObject thisObstacles = obstacles[i];  //下一个Obstacles

            GameObject nextObstacles = (i == 0) ? obstacles[1] : obstacles[0];//下一个Obstacles

            //记录当前坐标
            Vector3 thisPos = thisObstacles.transform.localPosition;
            thisPos.x += -moveSpeed * Time.deltaTime;

            //判断
            if (thisPos.x <= LEFT)
            {
                thisPos.x = RIGHT;//确定X坐标
                thisObstacles.transform.localPosition = thisPos;//修改

                SetPipe(thisObstacles, isShowPipe);//显示

                //设置随机高度的pipe
                if (isShowPipe)
                {
                    SetPipePositionY(thisObstacles);
                }

                Vector3 nextPos = nextObstacles.transform.localPosition;
                nextPos.x = CENTER;
                nextObstacles.transform.localPosition = nextPos;

                break;
            }
            else
            {
                thisObstacles.transform.localPosition = thisPos;//修改
            }
        }
    }
    #endregion

    #region 碰撞启用方法---1.所有  2.单个
    public void SetPipeCollisionAll(bool enable)
    {
        foreach (GameObject obstacle in obstacles)
        {
            SetPipeCollision(obstacle, enable);
        }
    }
    void SetPipeCollision(GameObject obstacle, bool enable)
    {
        foreach (Transform child in obstacle.transform)
        {
            if (child.name == "Pipe")
            {
                BoxCollider2D[] cols = child.GetComponentsInChildren<BoxCollider2D>();

                foreach (BoxCollider2D collider in cols)
                {
                    collider.enabled = enable;
                }
            }
        }
    }
    #endregion

    #region 设置pipe的随机高度
    void SetPipePositionY(GameObject obstacle)
    {
        foreach (Transform child in obstacle.transform)
        {
            if (child.name == "Pipe")
            {
                float randomY = Random.Range(MIN, MAX);

                Vector3 localPos = child.transform.localPosition;
                localPos.y = randomY;
                child.transform.localPosition = localPos;
            }
        }
    }
    #endregion
}
