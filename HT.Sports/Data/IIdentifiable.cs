using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Sports.Data
{
    /// <summary>Interface which defines identifiable objects.</summary>
    /// <typeparam name="T">Type used for the unique ID of the entity.</typeparam>
    public interface IIdentifiable<out T>
    {
        /// <summary>
        /// Gets the property which uniquely identifies the object. 
        /// </summary>
        T Id { get; }
    }
}
