using PostSharp.Aspects;
using PostSharp.Serialization;
using System;

namespace EjemploPostSharp.Aspects
{
    [PSerializable]
    public class LoggingAdvice : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            WriteInLog("Log->Se va a ejecutar: '{0}'", args.Method.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            WriteInLog("Log -> Se ha ejecutado con éxito: '{0}'", args.Method.Name);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            WriteInLog("Log -> Ha finalizado: '{0}'", args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            WriteInLog("Log -> Ha lanzado una excepción: '{0}'", args.Method.Name);
        }

        private void WriteInLog(string message, object argument = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, argument);
            Console.ResetColor();
        }

    }
}
