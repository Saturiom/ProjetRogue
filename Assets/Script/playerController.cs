using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Component")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Stat")]
    [SerializeField]
    float moveSpeed;
    public float currentHealth;
    public float maxHealth;

    [Header("Attack")]
    private float attackTime;
    [SerializeField] float timeBetweenAttack;
    [SerializeField] Transform checkEnemy;
    public LayerMask whatIsEnemy;
    public float range;



    public static playerController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time >= attackTime)
            {
                anim.SetTrigger("attack");
                attackTime = Time.time + timeBetweenAttack;
            }


        }
    }

    void Move()
    {
        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1)
        {
            anim.SetFloat("lastInputX", Input.GetAxis("Horizontal"));
            anim.SetFloat("lastInputY", Input.GetAxis("Vertical"));
        }

        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //retourne toujours 1 ou -1
        rb.velocity = new Vector2(x, y);
        rb.velocity.Normalize();

        if (x != 0 || y != 0)
        {
            anim.SetFloat("inputX", x);
            anim.SetFloat("inputY", y);

        }


        //regarde si il y a un enemy dans la direction
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x + range, transform.position.y);

        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x - range, transform.position.y);

        }

        if (Input.GetAxis("Vertical") > 0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x, transform.position.y + range);

        }
        else if (Input.GetAxis("Vertical") < -0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x, transform.position.y - range);

        }

    }

    //quand il attaque
    public void onAttack()
    {
        //on recup les enemy du jeu et on les mets dans un tab
        Collider2D[] enemy = Physics2D.OverlapCircleAll(checkEnemy.position, 0.5f, whatIsEnemy);

        //ici on boucle
        foreach (var enemy_ in enemy)
        {
            //deal dmg 
        }
    }


}
