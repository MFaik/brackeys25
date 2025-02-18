using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public float Damage = 30f;

    public float DirectForce, SideForce;

    [HideInInspector]   public List<Rigidbody2D> DirectRangeEnemies = new();
    [HideInInspector]   public List<Rigidbody2D> SideRangeEnemies = new();

    void DirectHit(Rigidbody2D enemy)
    {
        enemy.GetComponent<EnemyAI>().Hit(Damage, 3f);
        var direction = enemy.transform.position - transform.position;
        enemy.AddForce(direction.normalized * DirectForce);
    }

    void SideHit(Rigidbody2D enemy)
    {
        enemy.GetComponent<EnemyAI>().Hit(Damage / 3f, 1f);
        var direction = enemy.transform.position - transform.position;
        enemy.AddForce(direction.normalized * SideForce);
    }

    public void HandleCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DirectRangeEnemies.RemoveAll(o => o == null || o.transform.tag == "Dead");
            foreach (Rigidbody2D r in DirectRangeEnemies)
            {
                if (r == null) 
                    DirectRangeEnemies.Remove(r);
                else
                    DirectHit(r);
            }

            SideRangeEnemies.RemoveAll(o => o == null || o.transform.tag == "Dead");
            foreach (Rigidbody2D r in SideRangeEnemies)
            {
                if (r == null)
                    SideRangeEnemies.Remove(r);
                else
                    if (!DirectRangeEnemies.Contains(r)) SideHit(r);
            }
        }
    }

    private void Update()
    {
        HandleCombatInput();

        foreach (Rigidbody2D r in DirectRangeEnemies)
            Debug.Log("direct");

        foreach (Rigidbody2D r in SideRangeEnemies)
            Debug.Log("side");
    }
}
