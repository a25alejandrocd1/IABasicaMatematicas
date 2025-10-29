using UnityEngine;

// Clase que permite mover un obxecto (porco) cara a outro obxecto (goal) na escena 3D.
// O porco orientase e desprazase cara ao obxecto goal mentres a distancia sexa maior que 2 unidades.
// Inclúe parámetros para controlar a velocidade de desprazamento.

public class PigMove : MonoBehaviour {

    // goal: obxecto destino ao que se move o porco.
    // direction: vector de dirección cara ao destino.
    // speed: velocidade de desprazamento.
    public GameObject goal;
    Vector3 direction;
    public float speed = 5f;

    // LateUpdate chámase despois de Update en cada fotograma.
    // Calcula a dirección cara ao obxecto goal e orienta o porco cara a el.
    // Se a distancia ao destino é maior que 2:
    //   - Desprázase cara ao destino segundo a velocidade indicada.
    private void LateUpdate() {
        direction = goal.transform.position - this.transform.position;
        this.transform.LookAt(goal.transform.position);

        if(direction.magnitude > 2){
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}
