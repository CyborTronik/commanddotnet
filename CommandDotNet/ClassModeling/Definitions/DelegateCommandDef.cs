using System;
using System.Collections.Generic;
using System.Reflection;
using CommandDotNet.Execution;
using CommandDotNet.Extensions;

namespace CommandDotNet.ClassModeling.Definitions
{
    /// <summary>This can be used for methods passed into </summary>
    internal class DelegateCommandDef : ICommandDef
    {
        private readonly Delegate _delegate;

        public string Name { get; }
        public string SourcePath => _delegate.Method.FullName(includeNamespace: true);
        public Type CommandHostClassType { get; }
        public ICustomAttributeProvider CustomAttributes => _delegate.Method;
        public bool IsExecutable => true;
        public bool HasInterceptor => false;
        public IReadOnlyCollection<ICommandDef> SubCommands { get; } = new List<ICommandDef>().AsReadOnly();
        public IMethodDef? InterceptorMethodDef { get; }
        public IMethodDef InvokeMethodDef { get; }

        public DelegateCommandDef(string name, Delegate handlerDelegate, AppConfig appConfig)
        {
            _delegate = handlerDelegate;
            
            Name = name;
            InvokeMethodDef = new MethodDef(handlerDelegate.Method, appConfig);
            CommandHostClassType = _delegate.Method.DeclaringType;
        }

        public override string ToString()
        {
            return $"Delegate:{SourcePath} > {Name}";
        }
    }
}