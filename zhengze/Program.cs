using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace zhengze
{
    class Program
    {
        static void Main(string[] args)
        {
            string duigong = @"【唯品会】您的验证验证码52536";
            //var sIndex = duigong.IndexOf("于") + 1;
            //var eIndex = duigong.IndexOf("收到", sIndex);
            //var len = eIndex - sIndex ;
            //string duigong2 = duigong.Substring(sIndex, len);
            //Console.WriteLine(duigong2);

            
            string matchString = "【唯品会】您的{{yanzheng}}验证码{{yanzhengma}}";
            string sRegex = "({{)(.*?)(}})";
            Regex r = new Regex(sRegex);

            Program c = new Program();
            MatchEvaluator myEvaluator = new MatchEvaluator(c.RepalceCC);
            Console.WriteLine(matchString);
            string temString = r.Replace(matchString, myEvaluator);
            Console.WriteLine(temString);
            // replace {{/w+}} to #  
            // 然后我们根据matchString的顺序就可以得到数据顺序 , 然后照着顺序取出来
            string[] matchStringSplit = temString.Split('#');

            foreach(var s in matchStringSplit)
            {
                if(!string.IsNullOrEmpty(s))
                    duigong = duigong.Replace(s,"|");
                //Console.WriteLine(duigong);
            }
            Console.WriteLine(duigong);
            MatchCollection items = r.Matches(matchString);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            duigong = duigong.Trim('|');
            Console.WriteLine(duigong);
            string[] duigong3 = duigong.Split("|");
            for (int j=0; j < items.Count; j++)
            {
                Match gcm = items[j] as Match;
                dictionary[gcm.Groups[2].ToString()] = duigong3[j];
            }
            foreach(var item in dictionary)
            {
                Console.WriteLine(item);
            }
            //foreach(var item in items)
            //{
            //    Match gcm = item as Match;
            //    Console.WriteLine(gcm.Groups[2]);
            //}
            //foreach (MatchCollection item in r.Matches(matchString)) {
            //    Console.WriteLine(item.ToString());
            //}


            //Regex re = new Regex(@"[币|￥]\d+\.\d{2}"); 


            //Console.WriteLine("Hello World!");
        }
        public string RepalceCC(Match m)
        {
            
            return "#";
        }

        public string KeyWord(Match m)
        {
            GroupCollection gcm = m.Groups;
            var a = gcm[2];
            return a.ToString();
        }
    }
}
