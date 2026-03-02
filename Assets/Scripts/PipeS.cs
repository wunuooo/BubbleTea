using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeS : MonoBehaviour
{
    public Transform pivot;
    Vector2 mousePos;
    Vector2 preMousePos;
    public Transform upPos;//顶端物体的坐标
    float preMouseDistance;//鼠标距离枢轴的距离
    bool onPick;
    bool isBlocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dnew = new Vector2(mousePos.x - pivot.position.x, mousePos.y - pivot.position.y).magnitude;


        if (onPick && !isBlocked)
        {
            Vector2 direction = new Vector2(mousePos.x - pivot.position.x, mousePos.y - pivot.position.y);

            // 计算物体需要旋转的角度，atan2返回的是弧度，需要转换为角度
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 使用插值来平滑旋转（如果需要旋转速度）
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            pivot.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7 * Time.deltaTime);


            Vector2 offset = mousePos - preMousePos;
            float slideDistance = dnew > preMouseDistance ? offset.magnitude : -offset.magnitude;
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + slideDistance);
        }
        
        preMousePos = mousePos;
        preMouseDistance = dnew;
        isBlocked = false;
    }

    private void OnMouseDown()
    {
        //onPick = true;

    }

    private void OnMouseDrag()
    {
        onPick = true;
    }

    private void OnMouseUp()
    {
        onPick =false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBlocked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        isBlocked = true;
    }

    void Suck()
    {

    }
}
