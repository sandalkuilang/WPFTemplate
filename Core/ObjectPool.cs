using Texaco.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.Core
{
    internal class ObjectPool
    {
        private static IContainer instance;
        public static IContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Container("WPFTemplate-container");
                }
                return instance;
            }
        }
    }
}
