using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ExternalHook : MonoBehaviour
{
    public void OpenCharacterBuilder()
    {
        Process.Start(Application.streamingAssetsPath + "/BatchFiles" + "/LaunchAurora.bat");
    }
}
