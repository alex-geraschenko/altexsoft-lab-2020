using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-1":
                        {
                            Console.WriteLine("Считать по указанному в пути текстовый файл и удалить (предварительно сохранив оригинальный файл) в нем указанный в консоли символ/слово, в случае, если указанного слова в тексте нет вывести соответсвующее сообщение.");
                            FirstTask();
                            break;
                        }
                    case "-2":
                        {
                            Console.WriteLine("Считывает текстовый файл и вывести на экран количество слов в тексте, а также вывести каждое 10-е слово через запятую");
                            SecondTask("");
                            break;
                        }
                    case "-3":
                        {
                            Console.WriteLine("Вывести 3-е предложение в тексте. При чем буквы слов должны быть в обратном порядке.");
                            ThirdTask("");
                            break;
                        }
                    case "-4":
                        {
                            Console.WriteLine("Вывести имена папок по указанному пути в консоли. У каждой папки должен быть идентификатор, по которому пользователь сможет находить нужную папку и видеть все файлы, которые у нее внутри. Имена папок и файлов должны быть отсортированы в алфавитном порядке.");
                            FourthTask("");
                            break;
                        }
                    default:
                        {
                            MakeYourChoose();
                            break;
                        }
                }
            }
            else
            {
                MakeYourChoose();
            }

            Console.ReadLine();
        }


        static void MakeYourChoose()
        {
            Console.Clear();
            Console.WriteLine("What task to do:");
            Console.WriteLine("1 - Считать по указанному в пути текстовый файл и удалить (предварительно сохранив оригинальный файл) в нем указанный в консоли символ/слово, в случае, если указанного слова в тексте нет вывести соответсвующее сообщение.");
            Console.WriteLine("2 - Считывает текстовый файл и вывести на экран количество слов в тексте, а также вывести каждое 10-е слово через запятую");
            Console.WriteLine("3 - Вывести 3-е предложение в тексте. При чем буквы слов должны быть в обратном порядке.");
            Console.WriteLine("4 - Вывести имена папок по указанному пути в консоли. У каждой папки должен быть идентификатор, по которому пользователь сможет находить нужную папку и видеть все файлы, которые у нее внутри. Имена папок и файлов должны быть отсортированы в алфавитном порядке.");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Enter a number from 1 to 5: ");
            checkInputmethod(Console.ReadLine());
        }

        static void checkInputmethod(String s)
        {
            switch (s)
            {
                case "1":
                    {
                        Console.WriteLine("Считать по указанному в пути текстовый файл и удалить (предварительно сохранив оригинальный файл) в нем указанный в консоли символ/слово, в случае, если указанного слова в тексте нет вывести соответсвующее сообщение.");
                        FirstTask();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Считывает текстовый файл и вывести на экран количество слов в тексте, а также вывести каждое 10-е слово через запятую");
                        SecondTask("");
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Вывести 3-е предложение в тексте. При чем буквы слов должны быть в обратном порядке.");
                        ThirdTask("");
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Вывести имена папок по указанному пути в консоли. У каждой папки должен быть идентификатор, по которому пользователь сможет находить нужную папку и видеть все файлы, которые у нее внутри. Имена папок и файлов должны быть отсортированы в алфавитном порядке.");
                        FourthTask("");
                        break;
                    }
                case "5":
                    {
                        System.Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a number from 1 to 5: ");
                        checkInputmethod(Console.ReadLine());
                        break;
                    }
            }
        }

        private static void FirstTask()
        {
            Console.WriteLine("Input the path to the file(Example c:\\text.txt):");
            string path = Console.ReadLine();
            var exist = File.Exists(path);
            if (!exist)
            {
                Console.WriteLine("Sorry file not exist.");
                FirstTask();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Original text:");
                Console.WriteLine(ReadTextFile(path));
                Console.WriteLine();

                Console.WriteLine("Input word or symbol for search and delete in file:");
                string word = Console.ReadLine();
                string text = ReadTextFile(path);
                if (text.IndexOf(word) < 0)
                {
                    Console.WriteLine("Word or symbol not found");
                    Console.ReadLine();
                }
                else
                {
                    var fileName = Path.GetFileName(path);
                    var dir = Path.GetFullPath(path).Replace(fileName,"");
                    var origName = dir + "Original_" + fileName;
                    File.Copy(path, origName, true);
                    Console.WriteLine();
                    if (File.Exists(origName))
                        Console.WriteLine("Create dublicate file: " + origName + " compleate succesfull.");
                    else
                        Console.WriteLine("Can't create dublicate of file: " + origName);
                    text = text.Replace(word, "");
                    SaveFile(path, text);
                    Console.WriteLine();
                    Console.WriteLine("New text:");
                    Console.WriteLine(ReadTextFile(path));
                    Console.ReadLine();
                }
                MakeYourChoose();
            }

        }

        private static void SecondTask(string path)
        {
            if (path == String.Empty)
                path = "text.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found. Input the path to the file:");
                path = Console.ReadLine();
                SecondTask(path);
            }
            else
            {
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                string text = ReadTextFile(path);
                var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(String.Format("In text {0} words", words.Length));
                for(int i=9; i<words.Length; i += 10)
                {
                    Console.WriteLine((i + 1).ToString() + "th word - " + words[i]);
                }
                Console.ReadLine();
                MakeYourChoose();
            }
        }

        private static void ThirdTask(string path)
        {
            if (path == "")
                path = "text.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found. Input the path to the file:");
                path = Console.ReadLine();
                ThirdTask(path);
            }
            else
            {
                string text = ReadTextFile(path);
                var sentences = text.Split(".");
                var tmp = sentences[2];
                var wordsInThirdSentence = tmp.Split(" ");
                string result = "";
                foreach (var word in wordsInThirdSentence)
                {
                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        result = result + word[i];
                    }
                    result = result + " ";
                }
                Console.WriteLine(result);
                Console.ReadLine();
                MakeYourChoose();
            }
        }

        private static void FourthTask(string path)
        {
            if (path == String.Empty)
            {
                Console.WriteLine("Input the path(Example c:\\1\\):");
                path = Console.ReadLine();
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory not found.");
                FourthTask("");
            }
            else
            {
                string[] allFiles = Directory.GetFiles(path);
                string[] allFolder = Directory.GetDirectories(path);

                Array.Sort(allFiles);
                Array.Sort(allFolder);

                List<Item> items = new List<Item>();
                DirectoryInfo di = Directory.GetParent(path);
                if (di!=null)
                    items.Add(new Item(0, ItemType.Folder, di.FullName));
                else
                {
                    items.Add(new Item(0, ItemType.Folder, path));
                }

                foreach (var folder in allFolder)
                {
                    Item item = new Item(items.Count+1, ItemType.Folder, folder);
                    items.Add(item);
                }
                foreach (var file in allFiles)
                {
                    Item item = new Item(items.Count + 1, ItemType.File, file);
                    items.Add(item);
                }

                Console.WriteLine("ID - Type - Name");
                foreach (Item item in items) {
                    Console.WriteLine(String.Format("{0} - {1} - {2}", item.index, item.type, item.name));
                }
                ChooseItem(items);
            }
        }

        private static void ChooseItem(List<Item> items)
        {
            Console.WriteLine("Choose item and input ID:");
            var tmp = Console.ReadLine();
            int id=-1;
            try
            {
                id = int.Parse(tmp);
            }catch(Exception ex)
            {
                Console.WriteLine("Please enter a number from 0 to " + (items.Count+1).ToString());
                ChooseItem(items);
            }
            if (id >-1 && id < items.Count)
            {
                Item item = items.Where(i => i.index == id).ToArray()[0];
               
                if (item.type== ItemType.File)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(item.name);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    ChooseItem(items);
                }
                else
                {
                    FourthTask(item.name);
                }
            }
            else
            {
                Console.WriteLine("Please enter a number from 0 to " + (items.Count - 1).ToString());
                ChooseItem(items);
            }
        }

        private static string ReadTextFile(string path)
        {
            string result = "";
            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        private static void SaveFile(string path, string text)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
    }
}
