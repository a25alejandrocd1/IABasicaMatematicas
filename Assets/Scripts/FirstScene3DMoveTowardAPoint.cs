using UnityEngine;

// Clase que permite mover un obxecto na escena 3D cara a un punto seleccionado co rato.
// O obxecto orientase e desprazase cara ao destino ata chegar a unha distancia mínima (accuracy).
// Inclúe parámetros para controlar a velocidade de desprazamento e a precisión do destino.

public class FirstScene3DMoveTowardAPoint : MonoBehaviour
{
    // goal: posición de destino á que se move o obxecto.
    // speed: velocidade de desprazamento.
    // accuracy: distancia mínima para considerar que chegou ao destino.
    Vector3 goal;
    public float speed = 1.0f;
    public float accuracy = 1.0f;


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
    // O obxecto orientase cara ao destino e, se non chegou aínda (segundo accuracy):
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

        this.transform.LookAt(goal);

        if (Vector3.Distance(transform.position, goal) > accuracy)
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
