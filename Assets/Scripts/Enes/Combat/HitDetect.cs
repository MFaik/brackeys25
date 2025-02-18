using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public enum HitDetectType
    {
        Direct = 0,
        Side = 1
    }

    public HitDetectType Type;

    HitManager ehit;
    List<Rigidbody2D> enemiesList;

    private void Start()
    {
        ehit = GetComponentInParent<HitManager>();
        switch (Type)
        {
            case HitDetectType.Direct:
                enemiesList = ehit.DirectRangeEnemies;
                break;

            case HitDetectType.Side:
                enemiesList = ehit.SideRangeEnemies;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Enemy")
            return;

        enemiesList.Add(collision.transform.GetComponent<Rigidbody2D>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Enemy")
            return;

        enemiesList.Remove(collision.transform.GetComponent<Rigidbody2D>());
    }
}
