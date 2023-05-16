using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int state = 0; // 0 = Patrol, 1 = Chase, 2 = Attack, 3 = Idle
    [SerializeField] private Transform path;
    private Transform[] nodes;
    private int index = 0;
    [SerializeField] private float patrolSpeed = 1.5f, chaseSpeed = 2f;
    private float currentSpeed = 0f;
    private float timer = 3f;

    private Transform target; // A dónde tengo que ir. Esto va cambiando
    private Transform player;

    [SerializeField] private Animator animator;
    AnimatorStateInfo stateInfo;
    Sight sight;
    LifeController playerLife;

    void Awake() {
        sight = GetComponentInChildren<Sight>();
    }

    void Start() {
        playerLife = FindObjectOfType<LifeController>();
        nodes = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++) {
            nodes[i] = path.GetChild(i);
        }

        target = nodes[0];
        currentSpeed = patrolSpeed;
        animator.SetTrigger("Walk");
    }

    void Update() {
        if (state == 0) {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.5f) {
                index = (index + 1) % nodes.Length;
                target = nodes[index];
            }
        } else if (state == 1 || state == 2) {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 1.5f) {
                if (timer >= 3f) {
                    Invoke("Attack", 1f);
                    timer = 0f;
                }
            }
            if (distance >= 1.5f) Chase();
        } else if (state == 3) Idle();

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, currentSpeed * Time.deltaTime * 10);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        if (timer < 3) timer += Time.deltaTime;
        if (StateController.playerLife <= 0) state = 3;
    }
    public void PlayerSpoted(Transform other) {
        player = other;
        target = player;
        Chase();
    }
    private void Chase() {
        animator.SetTrigger("Run");
        currentSpeed = chaseSpeed;
        state = 1;
    }
    public void Attack() {
        animator.SetTrigger("Attack");
        state = 2;
        currentSpeed = 0;
        playerLife.Damage();
    }
    private void Idle() {
        animator.SetTrigger("Idle");
        currentSpeed = 0;
    }
}
