using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TNRD.Autohook
{
    [CustomPropertyDrawer(typeof(AutoHookAttribute))]
    public class AutoHookPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            AutoHookAttribute autoHookAttribute = (AutoHookAttribute) attribute;
            
            if (autoHookAttribute.HideWhenFound() && property.objectReferenceValue != null)
            {
                return 0;
            }

            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            AutoHookAttribute autoHookAttribute = (AutoHookAttribute) attribute;

            if (property.objectReferenceValue == null)
            {
                Component component = FindComponent(property);
                property.objectReferenceValue = component;
            }
            
            if (property.objectReferenceValue != null && autoHookAttribute.HideWhenFound())
            {
                return;
            }
            
            var readOnly = autoHookAttribute.ReadOnlyWhenFound() && property.objectReferenceValue != null;
            EditorGUI.BeginDisabledGroup(readOnly);
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
            
            var iconRect = new Rect(position.x + EditorGUIUtility.labelWidth - EditorGUIUtility.singleLineHeight, position.y, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
            GUI.DrawTexture(iconRect, AutoHookUtils.GetIcon(readOnly));
        }

        private Component FindComponent(SerializedProperty property)
        {
            SerializedObject root = property.serializedObject;
            if (!(root.targetObject is Component))
            {
                return null;
            }

            Type type = fieldInfo.FieldType;
            Component parent = (Component) root.targetObject;
            AutoHookAttribute autoHookAttribute = (AutoHookAttribute) attribute;

            switch (autoHookAttribute.SearchArea)
            {
                case AutoHookSearchArea.Parent:
                    return parent.GetComponentInParent(type);
                case AutoHookSearchArea.Children:
                    return parent.GetComponentInChildren(type);
                case AutoHookSearchArea.DirectChildrenOnly:
                    return FindComponentInDirectChildren(parent.transform, type);
                case AutoHookSearchArea.AllChildrenOnly:
                    return FindComponentInChildrenRecursive(parent.transform, type);
                case AutoHookSearchArea.WholeScene:
                    return FindComponentInScene(parent.gameObject.scene, type);
                default:
                    return parent.GetComponent(type);
            }
        }

        private Component FindComponentInDirectChildren(Transform parent, Type type)
        {
            foreach (Transform child in parent)
            {
                Component component = child.GetComponent(type);
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        private Component FindComponentInChildrenRecursive(Transform parent, Type type)
        {
            foreach (Transform child in parent)
            {
                Component component = child.GetComponent(type);
                if (component != null)
                {
                    return component;
                }

                component = FindComponentInChildrenRecursive(child.transform, type);
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }
        
        private Component FindComponentInScene(Scene scene, Type type)
        {
            foreach (var gameObject in scene.GetRootGameObjects()) {
                var component = gameObject.GetComponent(type);
                if (component != null) {
                    return component;
                }
            }
            
            return null;
        }
    }

    public static class AutoHookAttributeExtension {
        public static bool HideWhenFound(this AutoHookAttribute attribute) {
            return attribute.HideWhenFound == AutoHookAttribute.Trinary.Null 
                ? AutoHookSettings.HideWhenFound == AutoHookAttribute.Trinary.True 
                : attribute.HideWhenFound == AutoHookAttribute.Trinary.True;
        }
        
        public static bool ReadOnlyWhenFound(this AutoHookAttribute attribute) {
            return attribute.ReadOnlyWhenFound == AutoHookAttribute.Trinary.Null 
                ? AutoHookSettings.ReadOnlyWhenFound == AutoHookAttribute.Trinary.True 
                : attribute.ReadOnlyWhenFound == AutoHookAttribute.Trinary.True;
        }
    } 
}
