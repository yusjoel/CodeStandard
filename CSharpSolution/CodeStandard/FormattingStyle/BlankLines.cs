// 这是一个文件头, 下面应该空一行
// 名字空间组之间不要空行
// 名字空间结束后, 下面应该空一行
// 名字空间外空行数: 1 (不应该有多个名字空间)
// 名字空间内空行数: 0

using Microsoft.CSharp;
using System;
using System.Text;

namespace CodeStandard.FormattingStyle
{
    internal class BlankLines
    {
        /// <summary>
        ///     通用规则
        ///     <para>
        ///         1. Region外空行数: 1<br />
        ///         2. Region内空行数: 1<br />
        ///         3. 单行注释前空行数: 0
        ///     </para>
        /// </summary>
        public class General
        {
            public void Method1()
            {
            }

            #region Around / Inside Region

            public void MethodInsideRegion()
            {
            }

            #endregion

            public void Method2()
            {
                int a = 0;
                // 注释前空行: 0 (不空行)
                Console.WriteLine(a);
            }
        }

        /// <summary>
        ///     声明相关的空行
        ///     <para>
        ///         类型外空行数: 1<br />
        ///         类型内空行数: 0<br />
        ///         紧随括号不要留空行: 是<br />
        ///     </para>
        /// </summary>
        public abstract class Declaration
        {
            /// <summary>
            ///     有注释的字段外空行数: 1
            /// </summary>
            private int documentedField;

            // 单行字段外的空行数: 1
            private int singleLineField1;

            private int singleLineField2;

            /// <summary>
            ///     属性(单行或非单行或自动或抽象)外的空行数: 1
            /// </summary>
            public int DocumentedProperty { get; set; }

            public int AutoProperty { get; set; }

            public abstract int AbstractProperty { get; }

            /// <summary>
            ///     事件(单行或非单行或自动或抽象)外的空行数: 1
            /// </summary>
            public event Action DocumentedCallback;

            public event Action AutoHandler;

            public abstract event Action AbstractCallback;

            // 声明与声明之间最大空行数: 1
            // 方法外的空行数: 1
            public void Method1()
            {
                var provider = new CSharpCodeProvider();
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(provider.FileExtension);
                stringBuilder.AppendLine(documentedField.ToString());
                stringBuilder.AppendLine(singleLineField1.ToString());
                stringBuilder.AppendLine(singleLineField2.ToString());
                Console.WriteLine(stringBuilder);
            }

            public void Method2()
            {
                documentedField = 1;
                singleLineField1 = 2;
                singleLineField2 = 3;

                DocumentedCallback?.Invoke();
                AutoHandler?.Invoke();
            }

            // 单行方法外的空行数: 1
            public abstract void Method3();

            public abstract void Method4();
        }

        /// <summary>
        ///     代码内的空行
        /// </summary>
        public class Code
        {
            public void Method()
            {
                // 代码间的最大空行数: 1
                // 紧随括号不要留空行: 是
                int a = 1;

                int b = 2;

                void LocalFunction1()
                {
                    // 本地函数外的空行: 1
                    // 单行本地函数外的空行: 1 (不存在这种情况)
                }

                LocalFunction1();

                // 跳转控制前的空行: 0
                // 跳转控制后的空行: 1
                int c = a + b;
                if (c > 0) return;

                int d = b - a;
                if (d < 0) throw new Exception();

                // 子代码块前的空行: 0
                // 子代码块后的空行: 0
                // 多行语句前的空行: 0
                // 多行语句后的空行: 0
                int e = a * b;
                if (e > 0)
                {
                    e = e + 2;
                    Console.WriteLine(e);
                }
                int f = a / b;
                for (int i = 0; i < f; i++)
                {
                    Console.WriteLine("i = {0}, f = {1}, a = {2}, b = {3}",
                        i, f,
                        a, b);
                    Console.WriteLine(i);
                }
            }
        }
    }
}
