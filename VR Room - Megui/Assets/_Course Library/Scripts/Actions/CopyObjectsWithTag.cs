using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObjectsWithTag : MonoBehaviour
{
    GameObject[] _copiedObjects;
    [SerializeField] float _scale = .5f;
    [SerializeField] float _moveX = 10f;
    [SerializeField] float _moveY = 1f;
    [SerializeField] float _moveZ = 1f;

    public void CopyObjects(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject targetObject in taggedObjects)
        {
            var copiedObject = Instantiate(targetObject);
            Scalate(copiedObject);
            Move(copiedObject);
        }
    }

    private void Scalate(GameObject targetObject)
    {
        targetObject.transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    private void Move(GameObject targetObject)
    {
        targetObject.transform.position += new Vector3(_moveX, _moveY, _moveZ);
    }
}
