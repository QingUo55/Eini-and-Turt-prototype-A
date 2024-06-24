using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{

    private static VFXManager instance;
    public static VFXManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    //play at when eini jump
   public void PlayVFX_Jump(CapsuleCollider2D _col)
    {
        Vector3 _input = new Vector3(_col.bounds.center.x - _col.bounds.size.x / 2, _col.bounds.min.y) + Vector3.up * 1f;
        Instantiate(GameAssets.Instance.VFX_Jump, _input , Quaternion.identity);
    }
}
