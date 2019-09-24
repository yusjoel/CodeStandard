using System;

namespace CodeStandard.FormattingStyle
{
    // 大括号的布局
    // 都使用At next line (BSD style), 也就是大括号在下一行
    // 命名空间的声明

    // 命名空间内部需要缩进
    internal class BracesLayout
    {
        // 类型的声明

        private int property;

        public int Property
        {
            // 属性的声明
            get
            {
                // 访问器的声明
                Notify(property);
                return property;
            }

            set
            {
                Notify(property);
                property = value;
            }
        }

        public void Method()
        {
            // 方法的声明

            Action lambda = () =>
            {
                // Lambda表达式的声明
            };

            lambda();
        }

        private void Notify(int i)
        {
            Console.WriteLine(i);
        }

        public void Method2()
        {
            int a = 0;
            switch (a)
            {
                case 0:
                {
                    // case下的代码块
                    Console.WriteLine(a);
                    break;
                }
            }

            var array = new[]
            {
                // 数据或者对象的初始化器
                1, 2, 3
            };

            if (a > 0)
                // 允许括号后跟随注释: no
                // 其他情况
                foreach (int i in array)
                    Console.WriteLine(i);
        }

        // 括号内为空的情况: 下一行
        public void EmptyBracesFormatting()
        {
        }
    }
}
