# Descrición

Creación de una **escena** donde exista lo siguiente:

- Un **jugador** que **se pueda controlar**.
- Un **NPC** que contenga un **movimiento automático**.

Para realizar el primer ejercicio me basé en el ejemplo de *la escena del granjero y los cerdos*. Donde el personaje principal sería perseguido por tres NPCs.

# Solución

## Creando la escena

Primero creé una nueva escena donde contuviese:
- Un plano (la superficie por donde se moverían los personajes)
- Un personaje principal (el que controlaremos)
- Tres personajes no jugables (los NPCs que contendrán el movimiento automático)

Más adelante reutilicé el material del suelo de otras escenas para esta escena que creé. Y también reutilicé la luz para proyectar sombras dentro de la escena.

## Dando forma a los personajes

Obtuve dos diferentes assets para los personajes, ya que el principal sería una mamá pato y los NPCs serían unos pequeños patitos.

Los assets se pueden encontrar en estos enlaces:
- [Mamá Pato](https://skfb.ly/otTYs)
- [Pato pequeño](https://skfb.ly/pxpxG)

Después creé unos materiales con colores básicos para darle color a los personajes importados.

## Creando los Scripts

Ahora vendría la parte donde le daríamos movimiento a los diferentes personajes.

En el Script **DuckDrive** se gestionará el movimiento de la mamá Pato controlado por el jugador.

```csharp
using UnityEngine;

public class DuckDrive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}

```

En el Script **DucklingMove** se gestionará el movimiento automático de los tres patitos.

```csharp
using UnityEngine;

public class DucklingMove : MonoBehaviour
{
    public GameObject goal;
    Vector3 direction;
    public float speed = 3f;

    private void LateUpdate()
    {
        direction = goal.transform.position - this.transform.position;
        this.transform.LookAt(goal.transform.position);

        if(direction.magnitude > 2){
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}

```

Para finalizar, implementé los siguientes Scripts a los diferentes personajes de la escena. Y para que no se viese un movimiento tan automático, le pondré una velocidad diferente para cada NPC, dando así la sensación de que un pato es más rápido que otro.
