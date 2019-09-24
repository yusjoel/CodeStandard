using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace CodeStandard.FormattingStyle
{
    /// <summary>
    ///     空格
    /// </summary>
    public class Spaces
    {
        /// <summary>
        ///     是否保留已存在的格式
        /// </summary>
        public class PreserveExistingFormatting
        {
            // 多余的空格: 全部移除
        }

        /// <summary>
        ///     语句中圆括号前是否留空格
        /// </summary>
        public class BeforeParenthesesInStatements
        {
            // if语句的括号前: 是
            // while语句的括号前: 是
            // catch语句的括号前: 是
            // switch语句的括号前: 是
            // for语句的括号前: 是
            // foreach语句的括号前: 是
            // using语句的括号前: 是
            // lock语句的括号前: 是
            // fixed语句的括号前: 是

            public void Method(bool b)
            {
                if (b)
                    Console.WriteLine("OK");
            }
        }

        /// <summary>
        ///     其他情况下的圆括号前是否留空格
        /// </summary>
        public class BeforeOtherParentheses
        {
            // 方法的调用与声明: 否
            // typeof与括号之间: 否
            // default与括号之间: 否
            // checked, unchecked与括号之间: 否
            // sizeof与括号之间: 否
            // nameof与括号之间: 否
            // 其他关键字与表达式之间: 是
            // 掐关键字与类型之间: 是
            public void Method(bool condition, Exception e)
            {
                if (condition)
                    return;

                // 特殊关键字与括号之间
                Console.WriteLine(typeof(BeforeOtherParentheses));
                Console.WriteLine(nameof(Method));

                // 其他关键字与括号之间
                if (e != null)
                    throw (ArgumentException) e;

                // 方法的调用与声明
                Method(true, null);
            }
        }

        /// <summary>
        ///     语句中的圆括号内两侧是否留空
        /// </summary>
        public class WithinParenthesesInStatements
        {
            // if语句的括号前: 否
            // while语句的括号前: 否
            // catch语句的括号前: 否
            // switch语句的括号前: 否
            // for语句的括号前: 否
            // foreach语句的括号前: 否
            // using语句的括号前: 否
            // lock语句的括号前: 否
            // fixed语句的括号前: 否

            public void Method()
            {
                try
                {
                    int i = 0;
                    while (i < 10)
                        i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        ///     其他情况下的圆括号内两侧是否留空
        /// </summary>
        public class WithOtherParentheses
        {
            // 提升优先级: 否
            // 类型强转: 否
            // 方法的调用与申明: 否
            // typeof与括号之间: 否
            // default与括号之间: 否
            // checked, unchecked与括号之间: 否
            // sizeof与括号之间: 否
            // nameof与括号之间: 否

            public void Method()
            {
                long a = 2 * (3 + 4);
                int b = checked(1000 * 1000);
                int i = (int) a + b;
                Console.WriteLine($"i = {i}, sizeof i = {sizeof(int)}");
            }
        }

        /// <summary>
        ///     数组的方括号周围是否留空格
        /// </summary>
        public class AroundArrayBrackets
        {
            // 一维数组的方括号前: 否
            // 多维数组的方括号前: 否
            // 一维数组的方括号内: 否
            // 多维数组的方括号内: 否
            // 空格的多维数组的方括号内: 否

            public void Method()
            {
                int[] a = { 1, 2, 3 };
                var b = new int[2][];
                var c = new int[3, 3];
                for (int i = 0; i < a.Length; i++)
                    Console.WriteLine(a[i]);
                Console.WriteLine(b);
                Console.WriteLine(c);
            }
        }

        /// <summary>
        ///     尖括号的周围是否留空格
        /// </summary>
        public class AroundAngleBrackets
        {
            // 类型形参/实参前: 否
            // 类型形参/实参内: 否

            private void Method1<T1, T2>() where T1 : new() where T2 : new()
            {
                var t1 = new T1();
                var t2 = default(T2);
                Console.WriteLine(t1);
                Console.WriteLine(t2);
            }

            public void Method()
            {
                Method1<object, object>();
            }
        }

        /// <summary>
        ///     花括号周围是否留空格
        /// </summary>
        public class AroundBraces
        {
            // 单行的访问器前: 是
            // 单行的访问器内: 是
            // 单行的访问器之间: 是 (指get;set;之间)
            // 空的花括号内: 是
            // 单行的方法内: 是 (不存在这种情况)
            // 单行的匿名方法内: 是 (不存在这种情况)
            // 单行的表达式内: 是

            public int Property { get; set; }

            public void Method()
            {
                int[] a = { };
                int[] b = { 1, 2, 3 };
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }

        /// <summary>
        ///     二元运算符周围是否留空格
        /// </summary>
        public class AroundBinaryOperators
        {
            // 赋值运算符: 是 (=, +=, -=)
            // 逻辑运算符: 是 (&&, ||)
            // 等价运算符: 是 (==, !=)
            // 关系运算符: 是 (>, >=, <, <=)
            // 位运算符: 是 (&, |)
            // 加减运算符: 是 (+, -)
            // 乘除运算符: 是 (*, /, %)
            // 位移运算符: 是 (>>, <<)
            // 空合并运算符: 是 (??)
            // 不安全的指针运算符: 否 (->)
        }

        /// <summary>
        ///     一元操作符后是否留空格
        /// </summary>
        public class AfterUnaryOperators
        {
            // 取反操作符: 否
            // 负号: 否
            // 正号: 否
            // 不安全的取地址操作符: 否 (&)
            // 不安全的星号操作符: 否 (*)
            // 自增/自减前后: 否
        }

        /// <summary>
        ///     三元操作符
        /// </summary>
        public class InTernaryOperator
        {
            // ?前: 是
            // ?后: 是
            // :前: 是
            // :后: 是
            public string Method(bool condition)
            {
                return condition ? "OK" : "NO";
            }
        }

        /// <summary>
        ///     逗号与分号周围是否留空格
        /// </summary>
        public class AroundCommaAndSemicolon
        {
            // 逗号前: 否
            // 逗号后: 前
            // for语句中的分号前: 否
            // for语句中的分号后: 是
            // 分号前: 否

            public void Method(int p1, int p2, int p3)
            {
                for (int i = p1; i < p2; i += p3)
                    Console.WriteLine(i);
            }
        }

        /// <summary>
        ///     冒号周围是否留空格
        /// </summary>
        public class AroundColon
        {
            // 用于基类的冒号前: 是
            // 用于基类的冒号后: 是
            // 用于约束的冒号前: 是
            // 用于约束的冒号后: 是
            // case的冒号前: 否
            // case的冒号后: 是
            // 其他冒号前: 否
            // 其他冒号后: 是

            public class BaseClass
            {
            }

            public class C<T> : BaseClass where T : class, new()
            {
                public T Method(int i)
                {
                    T t;
                    switch (i)
                    {
                        case 2:
                            t = new T();
                            break;
                        default:
                            t = null;
                            break;
                    }

                    return t;
                }
            }
        }

        /// <summary>
        ///     特性周围是否留空格
        /// </summary>
        public class Attributes
        {
            // 特性之间: 是
            // 特性括号内的两侧: 否
            // 所有特性后: 是

            public void Method([NotNull] [ItemNotNull] IList<string> items)
            {
            }
        }

        /// <summary>
        ///     其他
        /// </summary>
        public class Other
        {
            // 类型转换括号后: 是
            // .的周围: 否
            // Lambda箭头周围: 是 (没有作用, 应该折行)
            // 空标记前: 否
            // 命名空间别名指示符周围: 是
            // 行尾的注释前: 是 (不要使用行尾注释)
            // operator关键字后: 是

            public void Method(object a)
            {
                string s = (string) a;
                Console.WriteLine(s?.ToLower());
            }

            public static bool operator <(Other a, Other b)
            {
                return false;
            }

            public static bool operator >(Other a, Other b)
            {
                return false;
            }
        }
    }
}
