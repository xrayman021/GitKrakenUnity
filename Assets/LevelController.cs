using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AudioClip _music = null;

    private void Update()
    {
        AudioHelper.PlayClip2D(_music, 1);
    }
}
