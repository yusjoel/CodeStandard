using System;
using System.IO;

namespace CodeStandard.FormattingStyle
{
    /// <summary>
    ///     缩进
    /// </summary>
    internal class Indents
    {
        #region Nested Statements (嵌套语句)

        /// <summary>
        ///     嵌套语句的缩进
        /// </summary>
        public void NestedStatements()
        {
            // 嵌套的using语句: 不缩进
            using (var streamReader = new StreamReader(File.OpenRead("a.txt")))
            using (var streamWriter = new StreamWriter(File.OpenWrite("b.txt")))
            {
                streamWriter.Write(streamReader.ReadLine());
            }

            // 嵌套的fixed语句, (不要使用)

            // 嵌套的lock语句: 不缩进
            string a = "";
            string b = "";
            lock (a)
            lock (b)
            {
                // nothing
            }

            // 嵌套的for语句: 不缩进
            for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                Console.WriteLine(i + j);

            // 嵌套的foreach语句: 不缩进
            int[] array1 = { };
            int[] array2 = { };
            foreach (int i in array1)
            foreach (int j in array2)
                Console.WriteLine(i + j);

            // 嵌套的while语句
            while (string.IsNullOrEmpty(a))
            while (string.IsNullOrEmpty(b))
                Console.WriteLine(a + b);
        }

        #endregion

        #region Parenthesis (括号)

        /// <summary>
        ///     方法声明中括号内的缩进: BSD/K&amp;R style
        /// </summary>
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public void DeclareMethod(
            int a,
            int b
        )
        {
            // 方法调用中括号内的缩进: BSD/K&amp;R style
            DeclareMethod(
                1,
                2
            );
        }

        /// <summary>
        ///     if/while/for语句中的括号内缩进: BSD/K&amp;R style
        /// </summary>
        public void Method1()
        {
            int a = 1;
            int b = -1;
            if (
                a > 0 ||
                b < 0
            ) { }
        }

        /// <summary>
        ///     尖括号内缩进: BSD/K&amp;R style
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public void DeclareGenericMethod<
            // ReSharper disable once UnusedTypeParameter
            T1,
            // ReSharper disable once UnusedTypeParameter
            T2
        >() where T1 : class where T2 : struct
        {
            DeclareGenericMethod<
                Indents,
                int
            >();
        }

        #endregion

        #region Preprocessor Directives (预处理指示符)

        /// <summary>
        ///     预处理指示符: Out Indent (跟随上一级缩进)
        /// </summary>
        public void PreprocessorDirectives()
        {
        #if DEBUG
            Console.WriteLine("Debug");
            int a = 0;
            if (a > 0)
            {
            #if X86
                Console.WriteLine("X86");
            #else
                Console.WriteLine("X64");
            #endif
            }
        #elif RELEASE
            Console.WriteLine("Release");
        #else
            Console.WriteLine("Default");
        #endif
        }

        // Region: Indent as usual (跟随内容缩进)

        /// <summary>
        ///     Other preprocessor directives: Indent as usual (跟随内容缩进)
        /// </summary>
        public void Method2()
        {
            #pragma warning disable 168
            int unusedLocalVariable;
            #pragma warning restore 168
        }

        #endregion

        #region Other Indent (其他缩进)

        public void Method3(DayOfWeek dayOfWeek)
        {
            // switch下的case是否缩进: yes
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("一");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("二");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }

        /// <summary>
        ///     类型约束是否缩进: yes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        // ReSharper disable once UnusedTypeParameter
        public void TypeConstraints<T>()
            where T : class, new()
        {
            // nothing
        }

        // 顶行写的注释不要缩进: no

        #endregion
    }
}
