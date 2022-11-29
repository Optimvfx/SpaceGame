using UnityEngine;

public class PlayerBullet : Bullet<PlayerBullet.PlayerBulletIgnore>
{
    public class PlayerBulletIgnore : IDamageIgnore
    {
        public bool Ignore(GameObject collision)
        {
            if (collision.TryGetComponent(out Player player))
                return true;

            return false;
        }
    }
}