using System;
using Tamir.SharpSsh;
using System.Threading;
using System.IO;

namespace sshfb
{
    /// <summary>
    /// Summary description for sharpSshTest.
    /// </summary>
    public class Program
    {
        static string host, user, pass;
        public static void Main()
        {
            PrintVersoin();
            Console.WriteLine();
            Console.WriteLine("1) Simple SSH session example using SshStream");
            Console.WriteLine();

        INPUT:
            int i = -1;
            Console.Write("Please enter your choice: ");
            try
            {
                i = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch
            {
                i = -1;
            }

            switch (i)
            {
                case 1:
                    SshStream();
                    break;

                default:
                    Console.Write("Bad input, ");
                    goto INPUT;
            }
        }

        /// <summary>
        /// Get input from the user
        /// </summary>
        public static void GetInput()
        {
            Console.Write("Remote Host: ");
            host = Console.ReadLine();
            Console.Write("User: ");
            user = Console.ReadLine();
            Console.Write("Password: ");
            pass = Console.ReadLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates the SshStream class
        /// </summary>
        public static void SshStream()
        {
            GetInput();

            try
            {
                
                SshShell sshShell = new SshShell(host, user);
                if (pass != null)
                    sshShell.Password = pass;
                
                sshShell.RedirectToConsole();
                Console.Write("Connecting...");
                sshShell.Connect();
                Console.WriteLine("OK");
                while (sshShell.ShellOpened)
                    Thread.Sleep(500);
                Console.Write("Disconnecting...");
                sshShell.Close();
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        static void PrintVersoin()
        {
            try
            {
                System.Reflection.Assembly asm
                    = System.Reflection.Assembly.GetAssembly(typeof(Tamir.SharpSsh.SshStream));
                Console.WriteLine("sharpSsh v" + asm.GetName().Version);
            }
            catch
            {
                Console.WriteLine("sharpSsh v1.0");
                
            }
        }

        

    }
    
}