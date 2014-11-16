using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Build.Framework;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;


namespace LoggingManager
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public LoggingInterceptionBehavior()
        {
        }
        public IMethodReturn Invoke(IMethodInvocation input,
   GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                if (!(result.Exception.GetType().ToString() == "LoggingManager.SuperException"))
                {
                    string message = String.Format(
                       "Method {0} of {1} threw exception {2} at {3} with arguments:",
                       input.MethodBase, input.Target, result.Exception.Message,
                       DateTime.Now.ToLongTimeString());

                    message += "\n";
                    message += Serialization(input.Arguments);
                    result.Exception = new SuperException(message, result.Exception);
                   // SuperException.Except.Add((SuperException)result.Exception);

                }
            }
            return result;
        }
        string Serialization(IParameterCollection arguments)
        {
            for (int i = 0; i < arguments.Count; i++)
            {

                XmlSerializer writer = new XmlSerializer(arguments[i].GetType());

                FileStream stream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + String.Format("\\{0}", i), FileMode.Create);
                writer.Serialize(stream, arguments[i]);

                stream.Close();
            }
            string message = "";
            for (int i = 0; i < arguments.Count; i++)
            {
                StreamReader read = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + String.Format("\\{0}", i));
                message += String.Format("argument {0} : \n {1} \n", i + 1, read.ReadToEnd());
                read.Close();
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + String.Format("\\{0}", i));
            }
            return message;


        }
        private IMethodReturn CheckForILogger(IMethodInvocation input)
        {
            if (input.MethodBase.DeclaringType == typeof(ILogger)
                 && input.MethodBase.Name == "WriteLogMessage")
            {
                WriteLog(input.Arguments["message"].ToString());
                return input.CreateMethodReturn(null);
            }
            return null;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
        }
    }
}