using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStandard
{
    /// <summary>
    ///     代码风格
    ///     <remarks>https://www.jetbrains.com/help/resharper/2019.2/Reference__Code_Style.html</remarks>
    /// </summary>
    internal class CodeStyle
    {
        /// <summary>
        ///     var的使用
        /// </summary>
        public class VarUsageInDeclarations
        {
            // 内置类型: 使用显示的类型
            // 简单类型: 使用var
            // 其他(一般指泛型): 使用var

            public void Method()
            {
                int i = 1;
                string s = "";

                var stringBuilder = new StringBuilder();

                var dictionary = new Dictionary<string, string>();

                Console.WriteLine($"{i}, {s}, {stringBuilder}, {dictionary}");

                // Prefer separate declarations for deconstructed variables
                // var (x, y) = GetTuple(); or
                // (var x, var y) = GetTuple();

                // Use 'var' keyword for discards
                // var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

                // 文档:
                // https://www.jetbrains.com/help/resharper/2019.2/Using_var_Keyword_in_Declarations.html
                // https://docs.microsoft.com/en-us/dotnet/csharp/discards
            }
        }

        /// <summary>
        ///     成员的限定
        ///     <remarks>在C#语法中没有Qualifier的说法, 使用的术语应该是access keyword</remarks>
        /// </summary>
        public class MembersQualification
        {
            // 立即成员的限定
            // 对哪些成员使用"this."限定符: 无 (包括字段, 属性, 事件, 方法)
            // 对声明在什么地方的成员使用限定符: 自身, 基类 (没有作用)
            // 静态成员的限定
            // 限定的名称使用: 声明改成员的类名 (没有作用)
            // 对哪些成员使用限定符: 无  (包括字段, 属性, 事件, 方法)

            public class BaseClass
            {
                protected static int staticMember;

                protected int baseMember;

                protected void BaseMethod(int baseMember)
                {
                    // this仅在这种情况使用
                    this.baseMember = baseMember;
                    staticMember = 1;
                }
            }

            public class DerivedClass : BaseClass
            {
                private int derivedMember;

                private void DerivedMethod(int a)
                {
                    Console.WriteLine(a);
                }

                public void Print()
                {
                    //this.baseMember = 1;
                    //base.baseMember = 2;
                    //this.BaseMethod(this.baseMember);
                    //base.BaseMethod(base.baseMember);
                    //this.DerivedMethod(this.derivedMember);
                    // BaseClass.staticMember = 1;
                    //BaseClass.staticMember = 1;
                    //DerivedClass.staticMember = 2;

                    baseMember = 1;
                    baseMember = 2;
                    BaseMethod(baseMember);
                    BaseMethod(baseMember);
                    derivedMember = 1;
                    DerivedMethod(derivedMember);
                    staticMember = 2;
                }
            }
        }

        /// <summary>
        ///     内置类型使用关键字还是CLR类名
        /// </summary>
        public class BuiltInTypes
        {
            // 局部变量, 成员, 参数: 关键字
            // 成员访问表达式: 关键字

            public void Method()
            {
                short i = 2;
                string s = string.Format("{0}", i);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        ///     引用限定与using指示符
        /// </summary>
        public class ReferenceQualificationAndUsingDirectives
        {
        }

        /// <summary>
        ///     修饰符
        /// </summary>
        public class Modifiers
        {
            // 对private的类型成员: 显式声明
            // 对internal的类型: 显式声明
            // 修饰符顺序: 保持默认

            private static readonly int a = 10;

            public void Method()
            {
                Console.WriteLine(a);
            }
        }

        /// <summary>
        ///     参数 是否使用命名参数
        /// </summary>
        public class Arguments
        {
            // 一律不使用命名参数 (ReSharper目前也提供功能显示参数名)
        }

        /// <summary>
        ///     圆括号的使用
        /// </summary>
        public class Parentheses
        {
            // 移除冗余的括号: 仅当优先级明显
            // 对优先级不明显的运算符加上括号: (保持默认)
        }

        /// <summary>
        ///     花括号的使用
        /// </summary>
        public class Braces
        {
            // 保持默认
            // if语句: 任一部分需要使用则全使用
            // for语句: 不强制使用
            // foreach语句: 不强制使用
            // while语句: 不强制使用
            // do-while语句: 强制使用
            // using语句: 强制使用
            // lock语句: 强制使用
            // fixed语句: 强制使用
            // 移除冗余: 是
        }

        /// <summary>
        ///     代码体 (使用代码块还是表达式?)
        /// </summary>
        public class CodeBody
        {
            // 保持默认
            // 方法与运算符: 代码块
            // 局部函数: 代码块
            // 构造器与析构器: 代码块
            // 属性, 索引器与事件: 表达式
            // 应用风格启发: 是
        }

        /// <summary>
        ///     特性
        /// </summary>
        public class Attributes
        {
            // 如何处理多个特性: 分开
        }
    }
}
