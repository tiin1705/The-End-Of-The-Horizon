using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private void Attack()
    {
        CameraShake.Instance.ShakeCamera(2f, 0.5f);
    }
}
