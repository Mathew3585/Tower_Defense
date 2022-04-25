 using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Fontions
    public float panSpeed = 30f;
    public float panBorder = 10f;
    public float scroolSpeed = 5f;
    [Header("Axes Y de la camera"), Tooltip("Cette Variable permet de générer l'axes y de la camera.")]
    public float minY = 10f;
    public float MaxY= 80f;
    [Header("Axes X de la camera"), Tooltip("Cette Variable permet de générer l'axes x de la camera.")]
    public float minX = 10f;
    public float MaxX = 80f;
    [Header("Axes Z de la camera"), Tooltip("Cette Variable permet de générer l'axes z de la camera.")]
    public float minZ = 10f;
    public float MaxZ = 80f;
    //Bouger la camera avec la souris ou les touche Z Q S D
    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        //Déplacement vers l'avant 
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //Déplacment Vers l'arrier 
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        //Déplacment Vers la gauche
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //Déplacement vers la droit
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 *  scroolSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, MaxY);
        pos.x = Mathf.Clamp(pos.x, minX, MaxX);
        pos.z = Mathf.Clamp(pos.z, minZ, MaxZ);
        transform.position = pos;
        
    }
}
