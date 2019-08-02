using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class CA
    {
        const string FILENAME = "C:/Users/ben11/Desktop/remcheck/twoDarrayGrid.XML";



        public void run(int[,] map)
        {
            int[,] grid = map;

            string xml = "<Data></Data>";

            XDocument doc = XDocument.Parse(xml);
            XElement data = doc.Root;

            for (int row = 0; row <= grid.GetUpperBound(0); row++)
            {
                XElement xRow = new XElement("Row");
                data.Add(xRow);
                for (int col = 0; col <= grid.GetUpperBound(1); col++)
                {
                    XElement xCol = new XElement("Column", grid[row, col]);
                    xRow.Add(xCol);
                }
            }

            XElement music = new XElement("music");
            data.Add(music);
            XElement soundtrack = new XElement("GEVAs_main_sountrack");
            XElement RonWalking = new XElement("RonWalking");
            music.Add(soundtrack);
            music.Add(RonWalking);
            doc.Save(FILENAME);

            XDocument newDoc = XDocument.Load(FILENAME);
            int[][] newGrid = newDoc.Descendants("Row").Select(x => x.Elements("Column").Select(y => (int)y).ToArray()).ToArray();
            int[,] newArray = new int[newGrid.Length, newGrid[0].Length];

            for (int i = 0; i < newGrid.Length; i++)
            {
                int[] innerArray = newGrid[i];

                for (int j = 0; j < innerArray.Length; j++)

                {
                    newArray[i, j] = innerArray[j];
                }
            }

            for (int i = 0; i < newArray.GetLength(0); i++)
            {


                for (int j = 0; j < newArray.GetLength(1); j++)

                {
                    Console.Write(newArray[i, j]);
                }
                Console.WriteLine();
            }

            // string CancelUrl =newDoc.GetElementsByTagName("cbt:CancelUrl")[0].InnerText;
            //var result = newDoc.Root
            //.Descendants("music")
            //.FirstOrDefault()?.Value;
            //  Console.WriteLine(result.Length);

            XElement xMusic = newDoc.Descendants("music").First();
            String s = xMusic.FirstNode.ToString();
            Console.WriteLine(s);

            xMusic.FirstNode.Remove();
            s = xMusic.FirstNode.ToString();
            Console.WriteLine(s);
            Console.Read();


        }
    }
}








 