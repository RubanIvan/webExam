using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExam.Models
{

    public static class Rnd
    {
        static Random R = new Random(DateTime.Now.Millisecond);

        static Rnd()
        {
            for (int i = 0; i < 500; i++)
            {
                R.Next();
            }
        }

        public static int Next(int Max)
        {
            return R.Next(Max);
        }

        public static int Next()
        {
            return R.Next();
        }

        public static int Next(int Min, int Max)
        {
            return R.Next(Min, Max);
        }
    }


    public class word
    {
        public string en { get; set; }
        public string ru { get; set; }
    }

    public class TestModel
    {
        public List<word> word { get; set; }
        public string title { get; set; }
    }

    public class RunModel
    {
        public string en { get; set; }
        public int answer { get; set; }
        public List<string> ru { get; set; }
        

    }

}