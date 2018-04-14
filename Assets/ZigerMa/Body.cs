using System.Collections;
using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour
{
    public Body next;//小孩的參考引用

    //促使我們目前的小孩跟著前一個小孩移動
    public void Move(Vector3 pos)
    {
        //紀錄移動前之位置
        Vector3 nextPos = transform.position;

        //先位移
        transform.position = pos;//移動目前頭
                                 //再檢查後面還有沒有小孩

        if (next != null)
        {//若後面還跟著有小孩
            next.Move(nextPos);//讓癡漢後面的小孩移動
        }
    }
}