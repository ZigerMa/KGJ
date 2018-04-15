using UnityEngine;
using System.Collections;

public enum SnakeHeadDirection
{
    Up,
    Down,
    Left,
    Right,
}

public class HeadController : MonoBehaviour
{

    public GameObject foodPrefab;
    public GameObject bodyPrefab;

    //癡漢的參考引用
    public Body _FirstBody;
    //最後一個小孩之參考引用
    public Body _LastBody;
    //public  Kid_Move move;

    //Step1.先定義速度
    public float speed;//移動之速 (m/s)
    private float _Timer = 0f;

    private SnakeHeadDirection _CurrentDir = SnakeHeadDirection.Up;//預設朝上
    private SnakeHeadDirection _NextDir = SnakeHeadDirection.Up;//下一步移動方向

    private bool _IsOver = false;

    
    


    /// <summary>
    /// Raises the trigger enter event.
    /// </summary>
    /// <param name="other">Other.</param>
    public void OnTriggerEnter(Collider other)
    {
        //若碰到邊界collider 遊戲結束
        if (other.tag.Equals("Bound"))
        {
            _IsOver = true;
        }
        //若碰到小孩,癡漢後增加一個小孩        
        if (other.tag.Equals("kid"))
        {
            Destroy(other.gameObject);
            Grow();
           
        }
    }
    //癡漢身後增加一個小孩
    private void Grow()
    {
        //先故意生成再螢幕看不到的位置 , 等癡漢觸碰到小孩Tag的物件 再位移
        GameObject obj = Instantiate(bodyPrefab, new Vector3(1000f, 1000f, 1000f), Quaternion.identity) as GameObject;

        Body b = obj.GetComponent<Body>();//取得小孩 prefab上的腳本
                                          //  如果癡漢後面還未有小孩
        if (_FirstBody == null)
        {
            _FirstBody = b;//最前面癡漢部分
        }
        //若有最後一個小孩
        if (_LastBody != null)
        {
            _LastBody.next = b;//就將新的小孩掛後頭
        }
        _LastBody = b;//更新最後一個小孩
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //只要遊戲還未結束 , 就繼續執行更新遊戲循環
        if (!_IsOver)
        {
            Turn();
            Move();
        }
    }

    //Step2.每隔一段時間往前移動一個單位
    /// <summary>
    /// Move this instance.
    /// </summary>
    private void Move()
    {   
        _Timer += Time.deltaTime;
        //判定當前的frame是否該移動
        if (_Timer >= (1f / speed))
        {
            //讓癡漢轉彎
            switch (_NextDir)
            {
                case SnakeHeadDirection.Up:
                    transform.forward = Vector3.forward;
                    _CurrentDir = SnakeHeadDirection.Up;
                    break;
                case SnakeHeadDirection.Down:
                    transform.forward = Vector3.back;
                    _CurrentDir = SnakeHeadDirection.Down;
                    break;
                case SnakeHeadDirection.Left:
                    transform.forward = Vector3.left;
                    _CurrentDir = SnakeHeadDirection.Left;
                    break;
                case SnakeHeadDirection.Right:
                    transform.forward = Vector3.right;
                    _CurrentDir = SnakeHeadDirection.Right;
                    break;
            }
            //紀錄癡漢移動之前的位置
            Vector3 nextPos = transform.position;

            transform.Translate(Vector3.forward);//每frame都會移動一單位
            _Timer = 0f;//Reset 計時器
                        //如果小孩身體子部分 就讓它移動
            //move.Move();
            if (_FirstBody != null)
            {
                //讓最前面單位移動
                _FirstBody.Move(nextPos);
            }
        }
    }

    /// <summary>
    /// Turn this instance.
    /// </summary>
    private void Turn()
    {
        
        if (Input.GetKey(KeyCode.W))
        {//上
            _NextDir = SnakeHeadDirection.Up;
            //判斷按鈕是否生效
            if (_CurrentDir == SnakeHeadDirection.Down)
            {//若按下之鍵盤值無效就修正
                _NextDir = _CurrentDir;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {//下
            _NextDir = SnakeHeadDirection.Down;
            //判斷按鈕是否生效
            if (_CurrentDir == SnakeHeadDirection.Up)
            {//若按下之鍵盤值無效就修正
                _NextDir = _CurrentDir;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {//左
            _NextDir = SnakeHeadDirection.Left;
            //判斷按鈕是否生效
            if (_CurrentDir == SnakeHeadDirection.Right)
            {//若按下之鍵盤值無效就修正
                _NextDir = _CurrentDir;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {//右
            _NextDir = SnakeHeadDirection.Right;
            //判斷按鈕是否生效
            if (_CurrentDir == SnakeHeadDirection.Left)
            {//若按下之鍵盤值無效就修正
                _NextDir = _CurrentDir;
            }
        }
    }
}
