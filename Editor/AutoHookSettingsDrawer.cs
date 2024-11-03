using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TNRD.Autohook {
internal static class AutoHookSettingsDrawer {
    private static readonly Dictionary<string, string> fieldNames = new() {
        { nameof(AutoHookSettings.HideWhenFound), "Hide When Found" },
        { nameof(AutoHookSettings.ReadOnlyWhenFound), "Read-Only When Found" },
    };
    
    [SettingsProvider]
    public static SettingsProvider CreateSettingsProvider() {
        return new SettingsProvider("Preferences/AutoHook", SettingsScope.User) {
            label = "AutoHook",
            keywords = GetKeywords(),
            guiHandler = searchContext => {
                AutoHookSettings.HideWhenFound = (AutoHookAttribute.Trinary)EditorGUILayout.EnumPopup(
                    new GUIContent(fieldNames[nameof(AutoHookSettings.HideWhenFound)]),
                    AutoHookSettings.HideWhenFound, IsSelectableValue, true
                );
                AutoHookSettings.ReadOnlyWhenFound = (AutoHookAttribute.Trinary)EditorGUILayout.EnumPopup(
                    new GUIContent(fieldNames[nameof(AutoHookSettings.ReadOnlyWhenFound)]),
                    AutoHookSettings.ReadOnlyWhenFound, IsSelectableValue, true
                );
            }
        };
    }

    private static HashSet<string> GetKeywords() => fieldNames.Values
        .SelectMany(fieldName => fieldName.Split(' '))
        .Concat(new[] { "AutoHook", "Auto Hook", "Auto", "Hook" })
        .ToHashSet();
    
    private static bool IsSelectableValue(Enum value) => !Equals(value, AutoHookAttribute.Trinary.Null);
}
}