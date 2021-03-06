﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    public class SystemGlobals
    {

        private static volatile SystemGlobals instance;
        private static object syncRoot = new Object();

        private SystemGlobals() { }

        public static SystemGlobals Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SystemGlobals();
                        }
                    }
                }

                return instance;
            }
        }

        // The Enum to use for the current data source
        // Default to Mock
        public DataSourceEnum DataSourceValue = DataSourceEnum.Mock;
    }

    public enum DataSourceEnum
    {
        // Not specified
        Unknown = 0,

        // Mock Dataset
        Mock = 1,

        // SQL Dataset
        SQL = 2
    }
}