using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace Social.WebMVC.Models
{
    /// <summary>
    /// Gestion d'unity par httpcontext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpContextLifetimeManager<T> : LifetimeManager
    {
        /// <summary>
        /// Attention ne marche que pour une seule variable dans HttpContext : le DbContext
        /// </summary>
        private string key = typeof(T).FullName;

        /// <summary>
        /// Recupère la valeur 
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return HttpContext.Current.Items[key];
        }

        /// <summary>
        /// Supprime la valeur
        /// </summary>
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(key);
        }

        /// <summary>
        /// Enregistre la valeur
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[key] = newValue;
        }
    }
}