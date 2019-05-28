using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Test_2
{
    class File
    {
        public string Name;
        public string Size;
        public string Extention;

         protected virtual void Parse(string text)
        {
            SetSize(text);
            SetName(text);
            SetExtention(text);
        }
        private void SetSize(string text)
        {
            int startIndex = text.IndexOf("(");
            int endIndex = text.IndexOf(")");
            Size = text.Substring(startIndex + 1, endIndex - 1 - startIndex);
        }
        private void SetName(string text)
        {
            int startIndex = text.IndexOf(":");
            int endIndex = text.IndexOf("(");
            Name = text.Substring(startIndex + 1, endIndex - 1 - startIndex);
        }
        private void SetExtention(string text)
        {
            int startIndex = text.IndexOf(".");
            int endIndex = text.IndexOf("(");
            Extention = text.Substring(startIndex + 1, endIndex - 1 - startIndex);
        }

    }
    class TextFiles : File
    {
        public string Content;

        public TextFiles(string text)
        {
            Parse(text);
        }

        protected override void Parse(string text)
        {
            base.Parse(text);

            // 
        }
    }
    class Movies : File
    {

        public string Resolution;
        public string Length;
        public Movies(string text)
        {
            Parse(text);
        }

        protected override void Parse(string text)
        {
            base.Parse(text);

            // 
        }
    }
    class Images : File
    {
        public string Resolution;
        public Images(string text)
        {
            Parse(text);
        }

        protected override void Parse(string text)
        {
            base.Parse(text);

            // 
        }

    }
    class StringParse
    {
        public string[] ArrString { get; set; }


        public File[] ArrInput(string input)
        {
            string[] arrString = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            File[] arrFiles = new File[arrString.Length];
            int found = 0;
            for (int i = 0; i < arrString.Length; i++)
            {
                if (arrString[i].StartsWith("Text:"))
                {
                    found = arrString[i].IndexOf(":");
                    arrFiles[i] = new TextFiles(arrString[i].Substring(found + 1));

                }
                else if (arrString[i].StartsWith("Image:"))
                {
                    found = arrString[i].IndexOf(":");
                    arrFiles[i] = new Images(arrString[i].Substring(found + 1));
                }
                else if (arrString[i].StartsWith("Movie:"))
                {
                    found = arrString[i].IndexOf(":");
                    arrFiles[i] = new Movies(arrString[i].Substring(found + 1));
                }

            }


            return arrFiles;
        }





    }
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text: file.txt(6B); Some string content
                            Image: img.bmp(19MB); 1920х1080
                            Text:data.txt(12B); Another string
                            Text:data1.txt(7B); Yet another string
                             Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            StringParse stringInput = new StringParse();
            
        }
    }
}
