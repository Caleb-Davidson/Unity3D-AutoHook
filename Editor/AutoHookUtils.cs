using UnityEditor;
using UnityEngine;

namespace TNRD.Autohook {
public static class AutoHookUtils {
    private const string IconName = "net.tnrd.autohook.icon";
    
    private static Texture2D icon;
    public static Texture2D Icon {
        get {
            if (icon != null) return icon;

            var searchTerm = (EditorGUIUtility.isProSkin ? "d_" : "l_") + IconName + " t:Texture2D";
            var guids = AssetDatabase.FindAssets(searchTerm);
            if (guids.Length == 0) {
                Debug.LogWarning("AutoHook: Icon not found");
                return null;
            }
            
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(guids[0]));
            return icon;
        }
    }

    private static Texture2D grayIcon;
    public static Texture2D GrayIcon {
        get {
            if (grayIcon != null) return grayIcon;

            var searchTerm = "g_" + IconName + " t:Texture2D";
            var guids = AssetDatabase.FindAssets(searchTerm);
            if (guids.Length == 0) {
                Debug.LogWarning("AutoHook: Grey icon not found");
                return null;
            }

            grayIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(guids[0]));
            return grayIcon;
        }
    }

    public static Texture2D GetIcon(bool gray) {
        return gray ? GrayIcon : Icon;
    }
}
}