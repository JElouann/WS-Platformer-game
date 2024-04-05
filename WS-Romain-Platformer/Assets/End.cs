using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject _vfxEnd;
    [SerializeField] private PlayerInput _playerInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerInput.enabled = false;
        _vfxEnd.SetActive(true);
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
