using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Collectible : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sfxs;
    [SerializeField] private VisualEffect _vfx;
    [SerializeField] private GameObject _sprite;

    private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioClip soundToPlay = _sfxs[Random.Range(0, _sfxs.Count - 1)];
            SoundManager.Instance.PlaySound(soundToPlay);
            _vfx.gameObject.SetActive(true);
            _collider = this.GetComponent<CircleCollider2D>();
            _collider.enabled = false;
            Destroy(_sprite);
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        Debug.Log("gonna be destroy");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
