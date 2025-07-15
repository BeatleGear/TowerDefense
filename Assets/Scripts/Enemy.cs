using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWayPoint();
    }
    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {            
            EndPath();
            return;
        }

        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.Money += value;
        Destroy(gameObject);
        Destroy(effect, 5f);
    }
}
