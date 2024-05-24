using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GreasyFools
{
    public static class CustomVisuals
    {
        public static Dictionary<string, AttackVisualsSO> Visuals;
        public static void Prepare()
        {
            Visuals = new Dictionary<string, AttackVisualsSO>();
        }
        public static void LoadVisuals(string name, AssetBundle bundle, string path, string sound, bool full = false)
        {
            try
            {
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = name;
                ret.animation = bundle.LoadAsset<AnimationClip>(path);
                ret.audioReference = sound;
                ret.isAnimationFullScreen = full;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(name)) Visuals.Add(name, ret);
                else Debug.LogWarning("animation for " + name + " already exists!");
            }
            catch
            {
                Debug.LogError("visuals failed to load: " + name);
                Debug.LogError("asset path: " + path);
                Debug.LogError("audio path: " + sound);
            }
        }
        public static AttackVisualsSO GetVisuals(string name)
        {
            if (Visuals == null) Prepare();
            if (Visuals.TryGetValue(name, out AttackVisualsSO ret)) return ret;
            else Debug.LogWarning("missing animation for " + name);
            return null;
        }
        public static void Duplicate(string newname, string oldname, string audio)
        {
            try
            {
                AttackVisualsSO old = GetVisuals(oldname);
                if (old == null) return;
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = newname;
                ret.animation = old.animation;
                ret.audioReference = audio;
                ret.isAnimationFullScreen = old.isAnimationFullScreen;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(newname)) Visuals.Add(newname, ret);
                else Debug.LogWarning("animation for " + newname + " already exists!");
            }
            catch
            {
                Debug.LogError("visuals failed to load: " + newname);
                Debug.LogError("failed to copy off: " + oldname);
            }
        }

        public static void Setup()
        {
            LoadVisuals("Greasy/Brute", PymnHere.Assets, "assets/Ability/Ani/BruteAnim.anim", LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals.audioReference);
            LoadVisuals("Greasy/Splitter", PymnHere.Assets, "assets/Ability/Ani/SplitterAnim.anim", LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals.audioReference);
            LoadVisuals("Greasy/Affliction", PymnHere.Assets, "Assets/AttackAnimGreasy/Affliction_A.anim", "event:/Greasy/Attack/Affliction_A");//gay
            LoadVisuals("Greasy/Buckler", PymnHere.Assets, "Assets/AttackAnimGreasy/Buckler_A.anim", LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals.audioReference);
            LoadVisuals("Greasy/Decay", PymnHere.Assets, "Assets/AttackAnimGreasy/Decay_A.anim", "event:/Greasy/Attack/Decay_A");
            LoadVisuals("Greasy/Forge", PymnHere.Assets, "Assets/AttackAnimGreasy/Forge_A.anim", "event:/Greasy/Attack/Forge_A");
            LoadVisuals("Greasy/Intimidate", PymnHere.Assets, "Assets/AttackAnimGreasy/Intimidate_A.anim", "event:/Greasy/Attack/Intimidate_A");
            LoadVisuals("Greasy/Nullify", PymnHere.Assets, "Assets/AttackAnimGreasy/Nullify_A.anim", "event:/Greasy/Attack/Vindicate_A");
            LoadVisuals("Greasy/Pummel", PymnHere.Assets, "Assets/AttackAnimGreasy/Pummel_A.anim", "event:/Greasy/Attack/Pummel_A");
            LoadVisuals("Greasy/Sleep", PymnHere.Assets, "Assets/AttackAnimGreasy/Sleep_A.anim", "event:/Greasy/Attack/Sleep_A");
            LoadVisuals("Greasy/Vindicate", PymnHere.Assets, "Assets/AttackAnimGreasy/Vindicate_A.anim", "event:/Greasy/Attack/Vindicate_A");

        }
    }
}
