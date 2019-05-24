using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject attackPoint;
    public GameObject shoot;
    Animator anim;
    float move;
    float speed = 10;
    bool bGround = true;
    bool bJump = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        bool bRun = false;
        if (move != 0)
        {
            bRun = true;
            transform.localScale = new Vector3(move, 1, 1);
        }
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
        bool bIsAttack = false;
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
            }
            bIsAttack = true;
        }
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(transform.position, -transform.up, 0.1f, 1 << 8))
        {
            if (hit.transform.tag == "Gorund")
            {
                bJump = true;
                bGround = true;
            }
            // Debug.Log(hit.transform.tag);
        }
        else
        {
            bGround = false;
        }
        Debug.DrawRay(transform.position, -transform.up * 0.1f, Color.red, 1);
        if (Input.GetKeyDown(KeyCode.Space)&& bJump)
        {
            bJump = false;
            anim.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,20);
        }
        anim.SetBool("Ground", bGround);
        anim.SetBool("IsAttack", bIsAttack);
        anim.SetBool("Run", bRun);
    }
    public void AnimShoot()
    {
        Instantiate(shoot, attackPoint.transform.position, Quaternion.Euler(0, 0, transform.localScale.x == 1 ? 180 : 0));
    }
    public float GetMoveX()
    {
        return move;
    }
}
