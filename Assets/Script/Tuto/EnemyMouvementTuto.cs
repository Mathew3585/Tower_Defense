using System.Collections;
using UnityEngine;


[RequireComponent(typeof(EnnemyTuto))]
public class EnemyMouvementTuto : MonoBehaviour
{
    //Fonction
    private Transform target;
    private int waypoinIndex = 0;
    private EnnemyTuto enemy;
    public Waypoint_Script Waypoint_Script;
    public float Speed = 1f;
    private Coroutine LookCorotine;
    public Transform Mesh;

    void Start()
    {

        enemy = GetComponent<EnnemyTuto>();
        target = Waypoint_Script.point[0];
    }

    //Déplacer les personnages énnemies au niveaux des waypoints
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //Si l'ennemie et a 0.3 du waypoint il passe au prochain 
        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.StartSpeed;
    }

    //Aller au prochain Waypoint
    private void GetNextWaypoint()
    {

        //SI il n'y a plus de waypoint il détruit l'énémie
        if (waypoinIndex >= Waypoint_Script.point.Length - 1)
        {
            enemy.EndOfPath();
            return;
        }

        //Cherhcer le prochain waypoint
        waypoinIndex++;
        target = Waypoint_Script.point[waypoinIndex];
        //transform.LookAt(target);
        StartRotating();

    }

    public void StartRotating()
    {
        if (LookCorotine != null)
        {
            StopCoroutine(LookCorotine);
        }
        LookCorotine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - Mesh.position);

        float time = 0;

        while (time < 1)
        {
            Mesh.rotation = Quaternion.Slerp(Mesh.rotation, lookRotation, time);

            time += Time.deltaTime * Speed;

            yield return null;
        }
    }

} 
