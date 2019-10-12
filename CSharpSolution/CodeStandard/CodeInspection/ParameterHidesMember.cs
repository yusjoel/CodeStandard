using System;

namespace CodeStandard.CodeInspection
{
    internal class ParameterHidesMember
    {
        // 参数名和成员名相同
        // ReSharper默认对这种情况进行警告
        // 原因是对参数进行使用, 但是之后将参数删除, 代码也能编译过并且行为不正确
        // 这里改成不提示
        // 原因在于如果参数和成员是同一个东西, 那么就要为参数重新起一个名字, 常见的如加_前缀, 加a前缀等等, 都是不符合命名规范的
        // 另外, 如果参数和成员是同一个东西, 那么对于参数的使用应该有且只能有一个, 就是对成员的赋值
        // 如果参数和成员不是同一个东西, 那么本身就不应该有相同的命名
        // https://www.jetbrains.com/help/resharper/2019.2/ParameterHidesMember.html

        private int member;

        public void Foo(int member)
        {
            this.member = member;

            // Bar(member)
            Bar();
        }

        private void Bar()
        {
            Console.WriteLine(member);
        }
    }
}
