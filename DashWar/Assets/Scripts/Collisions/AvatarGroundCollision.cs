using UnityEngine;

public class AvatarGroundCollision : GameCollisionAbstract
{
    //PARA HACER OTRA CLASE DE COLICION COPIAR LA SINTACIS DE ESTA CLASE

    //en esta parte defino los tags de los dos collisionadores

    //defino el tag del primer colicionador
    public override string Collider1Tag { get { return Tags.PLAYER; } protected set { } }
    //defino el tag del segundo colicionador
    public override string Collider2Tag { get { return Tags.GROUND; } protected set { } }
    //-----------------------------------------------------------------------

    //Hago la funcion de la colicion que resive los gameObject que van a colicionar y la colicion 2D
    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        //Aqui resuelvo la colicion especificando que pasa una vez colicionan los dos objetos.
        AvatarController ac = collider1.GetComponent<AvatarController>();

        ac.IsJumping = false;
    }
}