using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Flight_Simulation
{
    class FileHandler
    {
        FileStream stream;
        StreamReader sr;
        StreamWriter sw;

        public List<string> ReadData(string fileName)
        {
            List<string> rawData = new List<string>();

            try
            {
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(stream);
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    rawData.Add(line);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show(dnfe.Message);
            }
            finally
            {
                stream.Flush();
                sr.Close();
                stream.Close();
            }

            return rawData;
        }

        public void WriteData(string fileName, string dataToWrite)
        {
            try
            {
                stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(stream);
                sw.WriteLine(dataToWrite);
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show(dnfe.Message);
            }
            finally
            {
                sw.Close();
                stream.Close();
            }
        }
    }
}