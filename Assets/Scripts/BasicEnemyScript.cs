using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public Transform[] ways;
    public Animator animator;
    public float speed;
    int index;
    bool isWalking;
    bool isAttackInProgress;
    Transform player;
    bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isAttacking;
    public float runSpeed;
    public float walkSpeed;
    public float life;
    public float singleAttackDuration;
    public float attackDistance;
    public float damage = 3.0f;
    public bool isGameFinisher = false;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        speed = walkSpeed;
        isWalking = true;
        isAttackInProgress = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horisontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        velocity.y += gravity * Time.deltaTime;
        Vector3 direction = new Vector3(horisontal, 0f, vertical).normalized;
        gameObject.GetComponent<CharacterController>().Move(velocity * Time.deltaTime);

        if (!isAttacking && life > 0)
        {
            if (!isAttackInProgress)
            {
                Transform current = ways[index];
                Vector3 dir = current.position - transform.position;

                if (dir.magnitude < 1)
                {
                    index = Random.Range(0, 3);
                    wait();
                }

                if (isWalking)
                {
                    SelfRotation(current);
                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else if (Random.Range(0, 60 * 3) == 0)
                {
                    Walk();
                }
            }
            else
            {
                Vector3 dir = player.position - transform.position;

                if (dir.magnitude < attackDistance)
                {
                    StartCoroutine(Attack());
                }

                if (isWalking)
                {
                    SelfRotation(player);
                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    PerformAttack();
                }
            }
        }

        if (life <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        animator.SetBool("isDie", true);
        yield return new WaitForSeconds(2);
        if (isGameFinisher)
        {
            FindObjectOfType<GameManager>().StartPlayerWinManu();
        }
        Destroy(gameObject);
    }

    private IEnumerator Attack()
    {
        isWalking = false;
        isAttacking = true;
        animator.SetBool("isAttacking", true);
        player.transform.GetComponent<PlayerHealthScript>().TakeDamege(damage);

        yield return new WaitForSeconds(singleAttackDuration);

        isWalking = true;
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }

    private void PerformAttack()
    {
        speed = runSpeed;
        isWalking = true;
        animator.SetBool("isWaiting", false);
    }

    public void StartAttack(Transform other)
    {
        player = other;
        isAttackInProgress = true;
        PerformAttack();
    }

    void SelfRotation(Transform target)
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    void Walk()
    {
        speed = walkSpeed;
        isWalking = true;
        animator.SetBool("isWaiting", false);
    }

    void wait()
    {
        isWalking = false;
        animator.SetBool("isWaiting", true);
    }

    public void TakeDamge(float amount)
    {
        life -= amount;
    }
}
