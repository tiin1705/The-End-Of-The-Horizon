using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttachment : MonoBehaviour
{
    public GameObject vfxPrefab; // Prefab VFX để gắn vào đối tượng
    private GameObject vfxInstance; // Phiên bản của Prefab VFX

    private void Start()
    {
        // Tạo một phiên bản của Prefab VFX
        vfxInstance = Instantiate(vfxPrefab, transform.position, transform.rotation);
        // Gắn Prefab VFX vào đối tượng
        vfxInstance.transform.SetParent(transform);
    }
}
