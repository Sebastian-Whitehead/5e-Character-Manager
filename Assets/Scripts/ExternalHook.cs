using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ExternalHook : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCharacterBuilder()
    {
        Process.Start(Application.streamingAssetsPath + "/BatchFiles" + "/LaunchAurora.bat");
    }
}
