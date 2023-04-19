using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // Singleton
    public static ProjectileManager _instance;

    [SerializeField] private List<GameObject> _bulletInventory;
    [SerializeField] private List<UnityEngine.UI.Button> _bulletButtonList;

    private UnityEngine.UI.Button _bulletButton0;
    private UnityEngine.UI.Button _bulletButton1;
    private UnityEngine.UI.Button _bulletButton2;

    private GameObject _selectedBullet;
    private Camera _camera;

    private Vector3 _offset;
    public static ProjectileManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL!");
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private void Start() {
        _camera = Camera.main;
        _offset = - _camera.transform.up * 0.2f  + _camera.transform.forward * 0.5f;

        _bulletButton0 = _bulletButtonList[0];
        _bulletButton1 = _bulletButtonList[1];
        _bulletButton2 = _bulletButtonList[2];

        _bulletButton0.onClick.AddListener(delegate{setBullet(0);});
        _bulletButton1.onClick.AddListener(delegate{setBullet(1);});
        _bulletButton2.onClick.AddListener(delegate{setBullet(2);});
    }
    void Update()
    {
        // bullet inventory should be updated as game proceeed
    }

    public void setBullet(int bulletIndex){
        popUpTheBullet(bulletIndex);
    }

    private void popUpTheBullet(int bulletIndex){
        // when the new bullet was selected, but there was already a bullet that was selected before
        // 1. destroy original one
        if (_selectedBullet!=null){
            Destroy(_selectedBullet.gameObject);
        }
        // 2. then, instantiate the selected bullet
        Vector3 initPosition = _camera.transform.position + _offset;
        Quaternion initRotation = _camera.transform.rotation;
        _selectedBullet = Instantiate(_bulletInventory[bulletIndex],initPosition,initRotation);
    }
}
