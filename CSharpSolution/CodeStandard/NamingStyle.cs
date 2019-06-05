// 名字空间使用UpperCamelCase

using System;

namespace CodeStandard
{
    // 类型使用UpperCamelCase
    internal struct ValueType
    {

    }

    internal class ReferenceType
    {

    }

    // 接口使用IUpperCamelCase
    internal interface IInterface
    {

    }

    // 类型参数使用TUpperCamelCase
    // ReSharper disable once UnusedTypeParameter
    internal class GenericClass<TInterface> where TInterface : IInterface
    {
        // 或者单独的T
        public T NewOne<T>() where T : class
        {
            return default(T);
        }
    }

    internal class NamingStyle
    {
        // 枚举类型 UpperCamelCase
        public enum Enum
        {
            // 枚举成员， UpperCamelCase
            EnumMember
        }

        // 属性使用UpperCamelCase
        public string Property { get; set; }

        // 方法使用UpperCamelCase
        public void Method()
        {

        }

        // 事件使用UpperCamelCase
        public event Action EventHandler
        {
            // ReSharper disable once ValueParameterNotUsed
            add { }
            // ReSharper disable once ValueParameterNotUsed
            remove { }
        }

        // 参数， 使用lowerCamelCase
        public void MethodOne(double parameter)
        {
            // 局部变量， 使用lowerCamelCase
            double localVariable = parameter;
            // 局部常量， 使用lowerCamelCase
            const double localConstant = Math.PI;
            localVariable += localConstant;
            Console.WriteLine(localConstant * localVariable);
        }

        public void MethodTwo()
        {
            LocalFunction();

            // 本地函数， UpperCamel
            void LocalFunction()
            {

            }
        }

        // field is never assigned (649)
        // field is never used  (169)
        #pragma warning disable 169
        #pragma warning disable 649
        // 私有字段， lowerCamelCase
        private int privateField;

        // 保护字段， lowerCamelCase
        protected int protectedField;
        protected internal int protectedInternalField;

        // 其他字段， UpperCamelCase
        public int PublicField;
        internal int InternalField;

        // 静态字段
        // 私有字段， lowerCamelCase
        private static int privateStaticField;

        // 保护字段， lowerCamelCase
        protected static int protectedStaticField;
        protected internal static int protectedInternalStaticField;

        // 其他字段， UpperCamelCase
        public static int PublicStaticField;
        internal static int InternalStaticField;

        // 常量
        // 私有字段， lowerCamelCase
        // ReSharper disable once UnusedMember.Local
        private const int privateConstField = 0;

        // 保护字段， lowerCamelCase
        protected const int protectedConstField = 0;
        protected internal const int protectedInternalConstField = 0;

        // 其他字段， UpperCamelCase
        public const int PublicConstField = 0;
        internal const int InternalConstField = 0;

        // 静态只读字段
        // 私有字段， lowerCamelCase
        private static readonly int privateStaticReadOnlyField;

        // 保护字段， lowerCamelCase
        protected static readonly int protectedStaticReadOnlyField;
        protected internal static readonly int protectedInternalStaticReadOnlyField;

        // 其他字段， UpperCamelCase
        public static readonly int PublicStaticReadOnlyField;
        internal static readonly int InternalStaticReadOnlyField;
        #pragma warning restore 649
        #pragma warning restore 169
    }
}
