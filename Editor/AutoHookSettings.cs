using UnityEditor.SettingsManagement;

namespace TNRD.Autohook {
internal static class AutoHookSettings {
    private const string PACKAGE_NAME = "net.tnrd.autohook";
    
    private static Settings instance;
    private static UserSetting<AutoHookAttribute.Trinary> hideWhenFound;
    private static UserSetting<AutoHookAttribute.Trinary> readOnlyWhenFound;
    
    public static AutoHookAttribute.Trinary HideWhenFound {
        get {
            InitializeIfNeeded();
            return hideWhenFound.value;
        }
        
        set => hideWhenFound.value = value;
    }
    
    public static AutoHookAttribute.Trinary ReadOnlyWhenFound {
        get {
            InitializeIfNeeded();
            return readOnlyWhenFound.value;
        }
        
        set => readOnlyWhenFound.value = value;
    }

    private static void InitializeIfNeeded() {
        instance ??= new Settings(PACKAGE_NAME);
        hideWhenFound ??= new UserSetting<AutoHookAttribute.Trinary>(instance, "hideWhenFound", AutoHookAttribute.Trinary.False);
        readOnlyWhenFound ??= new UserSetting<AutoHookAttribute.Trinary>(instance, "readOnlyWhenFound", AutoHookAttribute.Trinary.False);
    }
}
}