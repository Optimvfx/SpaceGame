using UnityEngine;

[RequireComponent(typeof(PlayerShoter))]
[RequireComponent(typeof(Player))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private AudioSource _takeDamageSound;

    private PlayerShoter _shoter;
    private Player _player;

    private void Awake()
    {
        _shoter = GetComponent<PlayerShoter>();
        _player = GetComponent<Player>();   
    }

    private void OnEnable()
    {
        _shoter.OnShot += PlayShotSound;
        _player.TakingDamage += PlayTakeDamageSound;
    }

    private void OnDisable()
    {
        _shoter.OnShot -= PlayShotSound;
        _player.TakingDamage -= PlayTakeDamageSound;
    }

    private void PlayShotSound()
    {
        _shotSound.Play();
    }

    private void PlayTakeDamageSound()
    {
        _takeDamageSound.Play();
    }
}
