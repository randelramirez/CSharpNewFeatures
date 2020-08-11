using System;

namespace SwitchPatternMatchingTuples
{
    public enum JavaScriptFramework
    {
        React,
        Angular,
        Vue,
        NextJs,
        Svelte
    }

    public enum ServerSide
    {
        AspNet,
        Php,
        NodeJs,
        Deno,
        RubyOnRails
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"JS: {JavaScriptFramework.React}, ServerSide: {ServerSide.AspNet}, " +
                $"Result: {HaveYouTriedThisCombination(JavaScriptFramework.React,ServerSide.AspNet)}");

            Console.WriteLine($"JS: {JavaScriptFramework.Angular}, ServerSide: {ServerSide.AspNet}, " +
                $"Result: {HaveYouTriedThisCombination(JavaScriptFramework.Angular, ServerSide.AspNet)}");

            // throws Exception
            Console.WriteLine($"JS: {JavaScriptFramework.Svelte}, ServerSide: {ServerSide.AspNet}, " +
              $"Result: {HaveYouTriedThisCombination(JavaScriptFramework.Svelte, ServerSide.AspNet)}");

            Console.ReadKey();
        }

        static bool HaveYouTriedThisCombination(JavaScriptFramework js, ServerSide serverSide)
        {
            // Wrapped the two parameters as a Tuple
            return (js, serverSide) switch
            {
                (JavaScriptFramework.React, ServerSide.AspNet) => true,
                (JavaScriptFramework.Angular, ServerSide.AspNet) => true,
                (JavaScriptFramework.Vue, ServerSide.AspNet) => false,
                (JavaScriptFramework.React, ServerSide.Php) => false,
                (JavaScriptFramework.Angular, ServerSide.Php) => false,
                (JavaScriptFramework.Vue, ServerSide.Php) => false,
                (JavaScriptFramework.React, ServerSide.NodeJs) => true,
                (JavaScriptFramework.Angular, ServerSide.NodeJs) => false,
                (JavaScriptFramework.Vue, ServerSide.NodeJs) => false,
                (JavaScriptFramework.React, ServerSide.Deno) => true,
                (JavaScriptFramework.Angular, ServerSide.Deno) => true,
                (JavaScriptFramework.Vue, ServerSide.Deno) => false,
                (JavaScriptFramework.React, ServerSide.RubyOnRails) => false,
                (JavaScriptFramework.Angular, ServerSide.RubyOnRails) => false,
                (JavaScriptFramework.Vue, ServerSide.RubyOnRails) => false,
                _ => throw new Exception("Unexpected Combination")
            };
        }
    }
}
