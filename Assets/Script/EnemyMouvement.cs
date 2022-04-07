using UnityEngine;


[RequireComponent(typeof(Ennemy))]
public class EnemyMouvement : MonoBehaviour
{
    //Fonction
    private Transform target;
    private int waypoinIndex = 0;
    private Ennemy enemy;

    void Start()
    {
        enemy = GetComponent<Ennemy>();
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

    }



} 
