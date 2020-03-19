﻿using System;

namespace CommandDotNet
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CommandAttribute : Attribute, INameAndDescription
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Usage { get; set; }

        public string ExtendedHelpText { get; set; }
    }
}