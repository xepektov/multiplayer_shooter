using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class room_manager_script : MonoBehaviourPunCallbacks
{
    public static room_manager_script Instance_room_manager;

    private void Awake()
    {
        if (Instance_room_manager)  
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance_room_manager = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManagerPhoton"), new Vector3(0f, 3f, 990f), Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
