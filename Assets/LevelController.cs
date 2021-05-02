using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AudioClip _music = null;

    void Start()
    {
        AudioHelper.PlayClip2D(_music, 1);
    }
}
