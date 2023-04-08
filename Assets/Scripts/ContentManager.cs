using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.Networking.Match;
using File = System.IO.File;

using JsonFormats;
using JsonFormats.DataStructures;
using Newtonsoft.Json;

//TODO: Method: Create Content Package System in appdata directory (persistentdatapath) load all paths as strings into list of files to offloaded into respective content lists (Spells, Items, backgrounds, Feats, Race abilities, Class Features, Races, Subraces, Classes, Subclasses)
//TODO: Function to Unload JSON From File to List
//TODO: Function to Write JSON From List to File
public class Loaded
{
    [NonSerialized] public IDictionary<string, Spell> Spells;
    [NonSerialized] public IDictionary<string, Item> Items;
    [NonSerialized] public IDictionary<string, Background> Backgrounds;
    [NonSerialized] public IDictionary<string, Feat> Feats;
    [NonSerialized] public IDictionary<string, RaceAbility> RaceAbilities;
    [NonSerialized] public IDictionary<string, ClassFeature> ClassFeatures;
    [NonSerialized] public IDictionary<string, Race> Races;
    [NonSerialized] public IDictionary<string, PlayerClass> Classes;
    [NonSerialized] public IDictionary<string, PlayerSubclass> Subclasses;
}

public class ContentManager : MonoBehaviour
{
   
    private string _srdPackagePath;
    private string _customContentPath;
    
    private string[] _srdFiles;
    private string[] _customFiles;
    
    // Start is called before the first frame update
    void Start()
    {
        // _srdFiles = new string[] System.IO.Directory.GetFiles(_srdPackagePath);
        //var spellJson = JsonConvert.SerializeObject(basicSpell); // Convert object to JSON --> https://www.youtube.com/watch?v=pJtuuolUhCc
        //Debug.Log(spellJson); 
        
        //Application.dataPath Storing standard assets
        //Debug.Log(Application.persistentDataPath); // Storing files that should persist between application runtimes
        //File.WriteAllText();
        //File.ReadAllText();
        
        var loadedContent = new Loaded();
        _srdPackagePath = Application.dataPath + @"\SRD_Content";
        _customContentPath = Application.persistentDataPath + @"\CustomContent";
        
        _srdFiles = System.IO.Directory.GetFiles(_srdPackagePath);
        _customFiles = System.IO.Directory.GetFiles(_customContentPath);
        
        //TODO: LoadSRD Content
        //TODO: Load Custom Content from sub folders
    }
    
    public void UnloadJsonFromPath(string[] jsonPaths)
    {
        foreach (var path in jsonPaths)
        {
            File.ReadAllText(@path);
            //TODO: Split File Into Objects
            //TODO: Insert Objects into loadedContent object dictionaries (each entry should key = name)
        }
    }
    
    public void UnloadJsonFromPath(string[] jsonPaths, string type) //TODO: Overload that only loads one content type
    {
        foreach (var path in jsonPaths)
        {
            File.ReadAllText(@path);
        }
    }

    public void OpenEachCcPackage(string[] collections) // Unload custom content packages
    {
        foreach (var subFolder in collections)
        {
            // Iterate Through Sub Folders and call UnloadJsonFromPath
        }
    }
    
    
    /*
    public List<string> AppendToExportList(object obj, List<string> outJsonList)
    {
        var jsonOut = JsonConvert.SerializeObject();
        outJsonList.Add(jsonOut);
        return outJsonList;
    }
    */
}

