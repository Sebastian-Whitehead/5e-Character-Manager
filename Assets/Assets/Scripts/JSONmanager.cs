using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine.Windows;

using ContentTypes;
using File = System.IO.File;

public class JSONmanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        var basicSpell = new Spell()
        {
            Name = "Acid Splash",
            Source = "SRD",
            Lvl = 0,
            School = "Conjuration",
            Classes = new []{ "Sorcerer", "Wizard" },
            Components = new []{true, true, false},
            Materials = null,
            Range = 60,
            Target = "One creature within range or two creatures within range that are within 5 feet of each other",
            Damage = "1d6",
            DamageType = "Acid",
            CastTime = "1 action",
            Concentration = false,
            Duration = "Instantaneous",
            Description = "You hurl a bubble of acid. Choose one creature within range, or choose two Creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.",
            HigherLvl = "This spell's damage increases by 1d6 when you reach 5th Level (2d6), 11th level (3d6) and 17th level (4d6)."
        };

        var spellJson = JsonConvert.SerializeObject(basicSpell);
        Debug.Log(spellJson);
        
        //Debug.Log(Application.dataPath); // Storing standard assets
        //Debug.Log(Application.persistentDataPath); // Storing files that should persist between application runtimes
        //File.WriteAllText();
        //File.ReadAllText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

