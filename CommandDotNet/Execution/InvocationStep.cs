using System;

namespace CommandDotNet.Execution
{
    public class InvocationStep
    {
        /// <summary>
        /// The instance of the class containing the invocation method.<br/>
        /// Populated during <see cref="MiddlewareStages.BindValues"/>
        /// </summary>
        public object? Instance { get; set; }

        /// <summary>
        /// The command the invocation will fulfill.<br/>
        /// Populated during <see cref="MiddlewareStages.ParseInput"/>
        /// </summary>
        public Command Command { get; }

        /// <summary>
        /// The <see cref="IInvocation"/> to be invoked for the command<br/>
        /// Populated during <see cref="MiddlewareStages.ParseInput"/>
        /// </summary>
        public IInvocation Invocation { get; }

        public InvocationStep(Command command, IInvocation invocation)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            Invocation = invocation ?? throw new ArgumentNullException(nameof(invocation));
        }
    }
}