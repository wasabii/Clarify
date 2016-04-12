using System;
using System.Diagnostics.Contracts;

namespace Clarify
{
    
    class HalClassAttribute :
        Attribute
    {

        readonly string className;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="className"></param>
        public HalClassAttribute(string className)
        {
            Contract.Requires<ArgumentNullException>(className != null);

            this.className = className;
        }

        /// <summary>
        /// Gets the HAL class name the attributed object type is associated with.
        /// </summary>
        public string ClassName
        {
            get { return className; }
        }

    }

}