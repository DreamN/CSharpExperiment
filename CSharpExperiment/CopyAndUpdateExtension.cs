using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CSharpExperiment
{
    public static class CopyAndUpdateExtension
    {
        private static PropertyInfo CreateChangedProp<T, TProp>(Expression<Func<T, TProp>> selector)
        {
            return (PropertyInfo)((MemberExpression)selector.Body).Member;
        }

        private static T GetClone<T>(T prevObj)
        {
            var clone = Activator.CreateInstance<T>();
            foreach (var prop in typeof(T).GetProperties())
                prop.SetValue(clone, prop.GetValue(prevObj));
            return clone;
        }
        
        private static void UpdateValueClone<T, TProp>(T clone,
            (Expression<Func<T, TProp>> selector, TProp newValue) updater)
        {
            var changedProp = CreateChangedProp(updater.selector);
            changedProp.SetValue(clone, updater.newValue);
        }
        
        public static T CopyWith<T, TProp1, TProp2>(this T self,
            (Expression<Func<T, TProp1>> selector, TProp1 newValue) updater1,
            (Expression<Func<T, TProp2>> selector, TProp2 newValue) updater2)
        {
            var clone = GetClone(self);
            UpdateValueClone(clone, updater1);
            UpdateValueClone(clone, updater2);
            return clone;
        }
        
        public static T CopyWith<T, TProp1, TProp2, TProp3>(this T self, 
            (Expression<Func<T, TProp1>> selector, TProp1 newValue) updater1, 
            (Expression<Func<T, TProp2>> selector, TProp2 newValue) updater2,
            (Expression<Func<T, TProp3>> selector, TProp3 newValue) updater3)
        {
            var clone = GetClone(self);
            UpdateValueClone(clone, updater1);
            UpdateValueClone(clone, updater2);  
            UpdateValueClone(clone, updater3);  
            return clone;
        }
        
        public static T CopyWith<T, TProp1, TProp2, TProp3, TProp4>(this T self, 
            (Expression<Func<T, TProp1>> selector, TProp1 newValue) updater1, 
            (Expression<Func<T, TProp2>> selector, TProp2 newValue) updater2,
            (Expression<Func<T, TProp3>> selector, TProp3 newValue) updater3,
            (Expression<Func<T, TProp4>> selector, TProp4 newValue) updater4)
        {
            var clone = GetClone(self);
            UpdateValueClone(clone, updater1);
            UpdateValueClone(clone, updater2);  
            UpdateValueClone(clone, updater3);  
            UpdateValueClone(clone, updater4);  
            return clone;
        }
        
        public static T CopyWith<T, TProp1, TProp2, TProp3, TProp4, TProp5>(this T self, 
            (Expression<Func<T, TProp1>> selector, TProp1 newValue) updater1, 
            (Expression<Func<T, TProp2>> selector, TProp2 newValue) updater2,
            (Expression<Func<T, TProp3>> selector, TProp3 newValue) updater3,
            (Expression<Func<T, TProp4>> selector, TProp4 newValue) updater4,
            (Expression<Func<T, TProp5>> selector, TProp5 newValue) updater5)
        {
            var clone = GetClone(self);
            UpdateValueClone(clone, updater1);
            UpdateValueClone(clone, updater2);  
            UpdateValueClone(clone, updater3);  
            UpdateValueClone(clone, updater4);  
            UpdateValueClone(clone, updater5);  
            return clone;
        }
    }
}