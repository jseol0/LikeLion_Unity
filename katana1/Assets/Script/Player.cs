using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 속성")]
    public float speed = 5;
    public float jumpUp = 10;
    public float power = 5;

    public Vector3 direction;
    public GameObject slash;
    public GameObject jumpDust;
    public GameObject wallDust;

    //벽점프
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask wLayer;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump = false;
    float isRight = 1;
    bool isWall;

    //그림자
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    public GameObject Lazer;

    //bool bJump = false;
    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();
    }


    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); //왼쪽은 -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            //점프 벽잡기 방향
            isRight = -1;

            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }
        }
        else if(direction.x >0)
        {
            //right
            sp.flipX = false;
            pAnimator.SetBool("Run", true);

            isRight = 1;

            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }
        }
        else if(direction.x == 0)
        {
            pAnimator.SetBool("Run", false);

            for (int i = 0; i < sh.Count; i++)
            {
                Destroy(sh[i]); //게임오브젝트 지우기
                sh.RemoveAt(i); //게임오브젝트 관리하는 리스트 지우기
            }
        }


        if(Input.GetMouseButtonDown(0)) //0번 왼쪽마우스
        {
            pAnimator.SetTrigger("Attack");
            Instantiate(Lazer, transform.position, Quaternion.identity);
        }
    }
    
    void Update()
    {
        if (!isWall && !isWallJump)
        {
            KeyInput();
            Move();
        }

        //벽체크
        isWall = Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, wLayer);
        pAnimator.SetBool("Grab", isWall);

        if(Input.GetKeyDown(KeyCode.W))
        {
            if (pAnimator.GetBool("Jump") == false)
            {
                Jump();
                pAnimator.SetBool("Jump", true);
                JumpDust();
            }
        }

        if (isWall)
        {
            isWallJump = false;
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);

            if (Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;

                GameObject go = Instantiate(wallDust, transform.position + new Vector3(0.8f * isRight, 0, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().flipX = sp.flipX;

                Invoke("FreezeX", 0.3f);

                pRig2D.linearVelocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);    // 벽 반대방향으로 뛰기 때문에
                //sp.flipX = sp.flipX == false ? true : false;
                sp.flipX = !sp.flipX;
                isRight = -isRight;

                //JumpDust();
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));

        //레이캐스트로 땅체크 
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if(pRig2D.linearVelocityY < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    pAnimator.SetBool("Jump", false);
                }
            }
            else
            {
                if (!isWall)
                {
                    pAnimator.SetBool("Jump", true);
                }
                else
                {
                    pAnimator.SetBool("Grab", true);
                }
            }
        }
    }

    public void Jump()
    {
        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void AttSlash()
    {
        if (sp.flipX == false)
        {
            //플레이어 오른쪽
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
        else
        {
            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
    }

    //그림자
    public void RunShadow()
    {
        if (sh.Count < 6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - sh.Count;
            sh.Add(go);
        }
    }

    //흙먼지
    public void RandDust(GameObject dust)
    {
        Instantiate(dust, transform.position + new Vector3(-0.15f, -0.3f, 0), Quaternion.identity);
    }

    public void JumpDust()
    {
        if (!isWall)
            Instantiate(jumpDust, transform.position, Quaternion.identity);
        else
            Instantiate(wallDust, transform.position, Quaternion.identity);
    }

    public void FreezeX()
    {
        isWallJump = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right * isRight * wallchkDistance);
    }
}
