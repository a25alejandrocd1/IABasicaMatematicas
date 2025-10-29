using UnityEngine;

// Clase que permite mover o obxecto na escena 3D ao facer clic co rato.

public class FirstScene3DMove : MonoBehaviour
{
    // Update chámase unha vez por cada fotograma.
    // Lanza un raio dende a cámara ata a posición do rato na pantalla.
    // Se o raio colisiona cun obxecto e se preme o botón esquerdo do rato:
    //   - Move o obxecto ás coordenadas x e z do punto de colisión, mantendo a posición y actual.
    //   - Amosa a nova posición na consola.
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            Vector3 newPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            this.transform.position = newPosition;

            Debug.Log("Current position vector: " + newPosition.ToString());
        }
    }
}
