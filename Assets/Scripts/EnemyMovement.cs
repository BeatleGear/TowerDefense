using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWayPoint();

        enemy.speed = enemy.startSpeed;
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

    void EndPath()
    {
        PlayerStats.Lives--;

        WaveSpawner.EnemyIsAlive--;

        Destroy(gameObject);
    }
}
