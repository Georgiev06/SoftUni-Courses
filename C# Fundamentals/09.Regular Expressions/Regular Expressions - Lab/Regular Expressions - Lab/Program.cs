using System;

namespace Regular_Expressions___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            [word]
            //            [A-Z]
            //[a-z]
            //[0 - 9]

            //\w - [A - Z][a - z][0 - 9]_
            //\W - opposite \w
            //\s - " "
            //\S - opposite \s
            //\d - 0 - 9
            //\D - opposite 0 - 9

            //\+\d * -> + 359885976002 a + b-> + 35988597600 +
            //\+\d + -> + 359885976002 a + b-> + 359885976002
            //\+\d ? -> + 359885976002 a + b-> + 3 +

            //\+\d{ 4} -> +4 digits
            //\+\d{ 1,4} -> +between 1 and 4 digits
            //\+\d{ 4,} -> +above(including) 4 digits

            //d{ 2}
            //            -(\w{ 3})-\d{ 4} -> ()->creates group
            //d{ 2}
            //            -(?:\w{ 3})-\d{ 4} -> (?:)->non capture group
            //(?< day >\d{ 2})-(?< month >\w{ 3})-(?< year >\d{ 4}) -(?< name >) - group name
            //(?< name >\d{ 2})-(\w{ 3})-\g < name > - \g < name > -reuse groups
            //(:?http | https):\/\/ ([A - Za - z0 - 9] +)(\.com) - https://regex101.com -> will not count https or http as a group
            //^[A - Z][a - z] +$ -> Stoyan->valid-> ^ should start / $ should end
            //  <(\w+)[^>]*>.*?<\/\1 > - < b > Regular Expressions </ b > - \1 copy first group
        }
    }
}
