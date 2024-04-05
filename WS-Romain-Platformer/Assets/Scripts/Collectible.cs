using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Collectible : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sfxs;
    [SerializeField] private VisualEffect _vfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("AAAH");
            AudioClip soundToPlay = _sfxs[Random.Range(0, _sfxs.Count - 1)];
            SoundManager.Instance.PlaySound(soundToPlay);
            _vfx.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
