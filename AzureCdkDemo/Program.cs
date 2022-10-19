using System;

using Constructs;

using HashiCorp.Cdktf;



namespace AzureCdkDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            App app = new App();
            new MainStack(app, "AzureCdktDemo");
            app.Synth();
            Console.WriteLine("App synth complete");
        }
    }
}