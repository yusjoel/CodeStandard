using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeStandard.FormattingStyle
{
    /// <summary>
    ///     折行与自动换行
    /// </summary>
    internal class LineBreakAndWrapping
    {
        public class General
        {
            public void Foo(bool b)
            {
                // 保持已存在的折行: 是 (?)
                var dayOfWeek = b ? DayOfWeek.Friday : DayOfWeek.Monday;

                // 对过长的代码自动折行: 是
                // 超过多少字符自动折行: 140
                string log = string.Format("{0:yyyMMddhhmmss} - {1} - {2} - {3}: {4} - {5}", DateTime.Now, "Error",
                    typeof(LineBreakAndWrapping), nameof(Foo), "Invalid parameter b ", b);

                // 偏好在逗号前折行: 否
                Console.WriteLine("{0}, {1}, {2}",
                    DateTime.Now,
                    dayOfWeek,
                    log);

                // 对else if语句特殊处理: 是
                if (b)
                {
                    //
                }
                else if (dayOfWeek > DayOfWeek.Friday)
                {
                    //
                }

                // 文件结尾加一个空行: 是
            }
        }

        /// <summary>
        ///     特性的排列
        /// </summary>
        public class ArrangementOfAttributes
        {
            // 超过多少字符自动折行: 38
            // 保持已存在的排列: 否
            // 与类在同一行: 否
            // 与方法在同一行: 否
            // 与属性/索引器/事件在同一行: 否
            // 与访问器在同一行: 否
            // 与字段在同一行: 否

            [Serializable]
            public class Type
            {
                [NonSerialized]
                public int Field = 0;

                [DebuggerHidden]
                public int Property
                {
                    [DebuggerHidden]
                    get;
                    private set;
                }

                [Conditional("DEBUG")]
                public void Method()
                {
                    Property = 1;
                    Console.WriteLine(Field + Property);
                }
            }
        }

        /// <summary>
        ///     方法签名的排列
        /// </summary>
        public class ArrangementOfMethodSignatures
        {
            // 形式参数的折行方式: 简单折行 (保持原有折行方式), 其他选项包括, 如果是多行或者过长则折行, 每个参数都折行
            public void Method1(int p1, int p2, int p3)
            {
            }

            // 单行最多可以有多少个参数: 7 (一个方法最好少于或者等于7个参数)
            public void Method2(int p1, int p2, int p3, int p4, int p5, int p6, int p7)
            {
            }

            // 保持括号的原有排列: 否
            // 在(前折行: 否
            // 在(后折行: 否
            // 在)后折行: 否
            public void Method3(int p1, int p2,
                int p3, int p4)
            {
            }
        }

        /// <summary>
        ///     表达式化成员的排列
        ///     保留原有的排列: 否
        ///     什么情况下把方法表达式写在一行: 原来是一行
        ///     什么情况下把属性表达式写在一行: 原来是一行
        ///     什么情况下把属性访问器表达式写在一行: 原来是一行
        ///     在=>前折行: 否
        /// </summary>
        public class ArrangementOfExpressionBodiedMembers
        {
            private int a;

            public int Property1 => 1;

            public int Property2
            {
                get => a + 1;
                set => a = value;
            }

            public int Method()
            {
                return 1;
            }
        }

        /// <summary>
        ///     类型参数, 约束和基类的排列
        /// </summary>
        public class ArrangementOfTypes
        {
            // 允许类型约束写在一行: 是
            public void Method1<T>() where T : new()
            {
                var t = new T();
                Console.WriteLine(t);
            }

            // 从第一个约束开始折行: 否
            // 多个约束的折行方式: 简单
            // 从<前开始折行: 否
            public void Method2<T1, T2>() where T1 : new()
                where T2 : new()
            {
                var t1 = new T1();
                var t2 = new T2();
                Console.WriteLine(t1 + t2.ToString());
            }

            public class BaseClass
            {
            }

            public interface IInterface1
            {
            }

            public interface IInterface2
            {
            }

            // 从:前开始折行:否
            // 折行方式: 简单
            public class C : BaseClass, IInterface1,
                IInterface2
            {
            }
        }

        /// <summary>
        ///     申明代码块的排列
        ///     保持原有排列: 否
        /// </summary>
        public class ArrangementOfDeclarationBlocks
        {
            private int x;

            // 抽象/自动的属性/索引器/事件写在一行: 是
            public int AutoProperty { get; set; }

            // 简单的属性/索引器/事件写在一行: 否
            // 简单的访问器写在一行: 否 (实际上会自动表达式化)
            public int SimpleProperty
            {
                get => x + 1;
                set => x = value;
            }

            // 简单的方法写在一行: 否
            public int Method()
            {
                return 1;
            }
        }

        /// <summary>
        ///     枚举类型的排列
        ///     保持原有排列: 否
        ///     每行最多存在多少个枚举成员: 3 (无意义)
        ///     简单的枚举定义是否写在一行: 否 (无意义)
        ///     折行方式: 每个成员都折行
        /// </summary>
        public class ArrangementOfEnumerations
        {
            public enum Enum1
            {
                A,

                B,

                C
            }
        }

        /// <summary>
        ///     代码的排列
        /// </summary>
        public class ArrangementOfStatements
        {
            public void Method()
            {
                int a = 5;
                if (a > 5)
                    Console.WriteLine(a);
                else
                    // else新开一行: 是
                    Console.WriteLine(-a);

                do
                {
                    a++;
                    // while新开一行: 否
                } while (a < 40);

                try
                {
                    int b = 100 / a;
                    Console.WriteLine(b);
                }
                catch (Exception e)
                {
                    // catch新开一行: 是
                    Console.WriteLine(e);
                }
                finally
                {
                    // finally新开一行: 是
                    a = -1;
                }

                // for语句头的折行方式: 简单
                for (int i = 0; i < a; i++)
                {
                    int j = i * i;
                    Console.WriteLine(j);
                }

                // 多个定义的折行方式: 简单 (不建议这样定义多个变量)
                int m = 1, n = 2;
                Console.WriteLine(m + n);
            }
        }

        /// <summary>
        ///     内嵌语句的排列
        ///     保持原有排列: 否
        /// </summary>
        public class ArrangementOfEmbeddedStatements
        {
            public void Method(bool condition, DayOfWeek dayOfWeek)
            {
                // 简单的内嵌语句放在一行: 否
                if (condition)
                    Console.WriteLine("1");

                switch (dayOfWeek)
                {
                    // 简单的case语句放在一行: 否
                    case DayOfWeek.Friday:
                        return;
                }
            }
        }

        /// <summary>
        ///     内嵌语句块的排列
        ///     保持原有排列: 否
        /// </summary>
        public class ArrangementOfEmbeddedBlocks
        {
            public void Method(bool condition)
            {
                // 简单的内嵌语句块放在一行: 否 (会自动去除括号)
                if (condition)
                    Console.WriteLine("1");

                // 简单的匿名方法放在一行: 否
                EventHandler callback = delegate
                {
                };

                callback.Invoke(null, null);
            }
        }

        /// <summary>
        ///     switch表达式的排列 (C# 8.0功能)
        ///     保持原有排列: 否
        /// </summary>
        public class ArrangementOfSwitchExpressions
        {
        }

        /// <summary>
        ///     初始化器的排列
        ///     保持原有排列: 否
        /// </summary>
        public class ArrangementOfInitializers
        {
            public void Method()
            {
                // 简单的数组, 对象, 集合初始化放在一行: 是
                // 数字一行最多多少个元素: 10
                // 数组折行方式: 简单
                var array1 = new[] {1, 2, 3};
                var array2 = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12
                };

                // 对象, 集合在一行最多放多少元素: 4 (不起作用)
                // 对象, 集合初始化器的折行方式: 每个元素都折行
                var dictionary = new Dictionary<string, string>
                {
                    ["Name"] = "John",
                    ["Age"] = "20"
                };

                Console.WriteLine($"{array1}, {array2}, {dictionary}");
            }
        }

        /// <summary>
        ///     调用的排列
        /// </summary>
        public class ArrangementOfInvocations
        {
            public void Method()
            {
                int p1 = 1, p2 = 1, p3 = 1, p4 = 1, p5 = 1, p6 = 1, p7 = 1;
                var arrangementOfMethodSignatures = new ArrangementOfMethodSignatures();

                // 参数的折行: 简单
                arrangementOfMethodSignatures.Method1(p1, p2, p3);

                // 允许写在一行的最大参数: 7 (不应该超过7个)
                arrangementOfMethodSignatures.Method2(p1, p2, p3, p4, p5, p6, p7);

                // 保持括号的排列: 否
                // 在(前折行: 否
                // 在(后折行: 否
                // 在)前折行: 否
                arrangementOfMethodSignatures.Method3(p1, p2,
                    p3, p4);
            }
        }

        /// <summary>
        ///     成员访问表达式的排列
        /// </summary>
        public class ArrangementOfMemberAccessExpressions
        {
            public ArrangementOfMemberAccessExpressions GetChild()
            {
                return this;
            }

            public void Method()
            {
                // 在.后折行: 是
                // 折行方式: 简单
                GetChild().GetChild().GetChild()
                    .GetChild().GetChild();
            }
        }

        /// <summary>
        ///     二元表达式的排列
        /// </summary>
        public class ArrangementOfBinaryExpressions
        {
            public void Method()
            {
                // 在操作符前折行: 是
                // 折行方式: 简单
                int p1 = 1, p2 = 2, p3 = 3, p4 = 4;
                int sum = p1 + p2
                    + p3 + p4;

                Console.WriteLine(sum);

                // 强制对if语句的条件折行: 否
                // 强制对while语句的条件折行: 否
                // 强制对do语句的条件折行: 否
            }
        }

        /// <summary>
        ///     三元表达式的排列
        /// </summary>
        public class ArrangementOfTernaryExpressions
        {
            public void Method(bool condition, bool error, bool warning)
            {
                // 在?,:前折行: 是
                // 折行方式: 简单
                int returnThisIfTrue = 123;
                int returnThisIfFalse = 456;
                int a = condition
                    ? returnThisIfTrue
                    : returnThisIfFalse;

                // 多层的三元表达式的排列: 按照现有风格进行折行
                int b, red = 1, yellow = 2, green = 3;
                b = error ? red :
                    warning ? yellow :
                    green;

                int c = error
                    ? red
                    : warning
                        ? yellow
                        : green;

                Console.WriteLine($"{a}, {b}, {c}");
            }
        }

        /// <summary>
        ///     LINQ语句的排列
        /// </summary>
        public class ArrangementOfLinq
        {
            public void Method()
            {
                var list = new List<int>
                {
                    1,
                    2,
                    3
                };

                // 折行方式: 总是折行
                // 如果是多行表达式在=后折行:否
                // into开新行: 是
                var result1 = from x in list
                    where x < 10
                    select x;

                var result2 = from x in list
                    where x < 10
                    select x
                    into j
                    where j > 0
                    select j;

                Console.WriteLine($"{result1}, {result2}");
            }
        }

        /// <summary>
        ///     内插字符串的排列
        /// </summary>
        public class ArrangementOfInterpolatedStrings
        {
            public void Method(string sourceFileName, string destFileName)
            {
                // 折行方式: 不折行
                Console.WriteLine($"Copy {sourceFileName} to {destFileName}");
                File.Copy(sourceFileName, destFileName);
            }
        }
    }
}
