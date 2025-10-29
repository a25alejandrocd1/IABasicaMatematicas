using UnityEngine;

// Clase que permite mover e interpolar a posición dun obxecto na escena 3D ao facer clic co rato.
// O obxecto móvese suavemente cara ao punto seleccionado, rotando e desprazándose ata chegar ao destino.
// Inclúe parámetros para controlar a velocidade de desprazamento, precisión do destino e velocidade de rotación.

public class FirstScene3DMoveInterpolate : MonoBehaviour
{
    // goal: posición de destino á que se move o obxecto.
    // speed: velocidade de desprazamento.
    // accuracy: distancia mínima para considerar que chegou ao destino.
    // rotSpeed: velocidade de rotación cara ao destino.
    Vector3 goal;
    public float speed = 1.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 2f;


    // Start chámase unha vez antes da primeira execución de Update.
    // Inicializa a posición de destino co valor actual do obxecto.
    void Start()
    {
        goal = this.transform.position;
    }

    // Update chámase unha vez por cada fotograma.
    // Lanza un raio dende a cámara ata a posición do rato na pantalla.
    // Se o raio colisiona cun obxecto e se preme o botón esquerdo do rato:
    //   - Actualiza a posición de destino (goal) ás coordenadas x e z do punto de colisión, mantendo a posición y actual.
    // Calcula a dirección cara ao destino e, se non chegou aínda (segundo accuracy):
    //   - Interpola a rotación do obxecto cara ao destino.
    //   - Desprázase cara ao destino segundo a velocidade indicada.
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            goal = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            Debug.Log("Current position vector: " + goal.ToString());
        }

        Vector3 direction = goal - this.transform.position;
        
        if (Vector3.Distance(transform.position, goal) > accuracy)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime*rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
