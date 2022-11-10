using UnityEngine;

public class EnemyBullet : Bullet<EnemyBullet.EnemyBulletIgnore>
{
    public class EnemyBulletIgnore : IDamageIgnore
    {
        public bool Ignore(GameObject collision)
        {
            if (collision.TryGetComponent(out Player player) || collision.TryGetComponent(out Meteor metior))
                return false;

            return true;
        }
    }
}
