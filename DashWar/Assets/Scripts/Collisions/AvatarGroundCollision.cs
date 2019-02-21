using UnityEngine;

public class AvatarGroundCollision : GameCollisionAbstract
{
    //PARA HACER OTRA CLASE DE COLISIÓN COPIAR LA SINTAXIS DE ESTA CLASE

    //en esta parte defino los tags de los dos colsisionadores

    //defino el tag del primer colisionador
    public override string Collider1Tag { get { return Tags.PLAYER; } protected set { } }
    //defino el tag del segundo colisionador
    public override string Collider2Tag { get { return Tags.GROUND; } protected set { } }
    //-----------------------------------------------------------------------

    //Hago la funcion de la colisión que resive los gameObject que van a colisionar y la colisión 2D
    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        //Aqui resuelvo la colisión especificando que pasa una vez colicionan los dos objetos.
        AvatarController ac = collider1.GetComponent<AvatarController>();

        ac.isJumping = false;
    }
}