using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Health = 100f;

    GameObject player;
    Rigidbody2D rigidBody, playerRigidBody;

    bool onMove = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    public IEnumerator StunForSeconds(float t)
    {
        onMove = false;
        yield return new WaitForSeconds(t);
        if (Health <= 0f)
        {
            Destroy(gameObject);
        }
        onMove = true;
        c = null;
    }

    Coroutine c;
    public void Hit(float damage, float t)
    {
        Health -= damage;

        if (Health <= 0f)
        {
            gameObject.tag = "Dead";
        }

        if (c != null) StopCoroutine(c);

        c = StartCoroutine(StunForSeconds(t));
    }

    void Move()
    {
        var direction = player.transform.position - transform.position;
        rigidBody.linearVelocity = direction.normalized * 2f;
    }

    private void Update()
    {
        if (Health < 0f)
            return;

        if (onMove)
        {
            Move();
        }
    }
}
