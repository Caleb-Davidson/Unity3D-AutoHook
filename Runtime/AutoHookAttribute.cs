using System;
using UnityEngine;

namespace TNRD.Autohook
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutoHookAttribute : PropertyAttribute
    {
        public enum Trinary 
        {
            Null,
            True,
            False
        }
        
        public AutoHookSearchArea SearchArea;
        /// <summary>
        /// Reduces the size of the property to 0 when a matching component has been found
        /// </summary>
        public Trinary HideWhenFound;
        /// <summary>
        /// Marks the property as read-only when a matching component has been found
        /// </summary>
        public Trinary ReadOnlyWhenFound;

        public AutoHookAttribute(Trinary hideWhenFound = Trinary.Null, Trinary readOnlyWhenFound = Trinary.Null)
        {
            HideWhenFound = hideWhenFound;
            ReadOnlyWhenFound = readOnlyWhenFound;
            SearchArea = AutoHookSearchArea.Default;
        }

        public AutoHookAttribute(AutoHookSearchArea searchArea, Trinary hideWhenFound = Trinary.Null, Trinary readOnlyWhenFound = Trinary.Null)
        {
            SearchArea = searchArea;
            HideWhenFound = hideWhenFound;
            ReadOnlyWhenFound = readOnlyWhenFound;
        }
    }
}
