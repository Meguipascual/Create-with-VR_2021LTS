using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePedestalFigure : MonoBehaviour
{
    private SpawnFromList _spawnFromList;
    private int _yRotation = 0;

    private Slider _slider;
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnFromList = FindObjectOfType<SpawnFromList>();
        _slider = GetComponent<Slider>();
    }

    public void RotateFigure()
    {
        if (_slider!= null)
        {
            _yRotation = (int)_slider.value;
        }else
            Debug.Log("Slider not found");

        if (_spawnFromList != null)
        {
            _spawnFromList.RotateYNewObject(_yRotation);
        }else
            Debug.Log("SpawnFromList not found");
    }
}
