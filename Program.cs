
namespace comp123_bonus3_fan_yang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a file name: ");
                string fileName = Console.ReadLine();
                writeFile(fileName);
                readFile(fileName);
                double average = computeAverage(fileName);
                Console.WriteLine("The average is: " + average);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found or could not be read.");
            }
            catch (FormatException)
            {
                Console.WriteLine("File contains invalid numbers.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("The list of numbers is empty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void writeFile(string fileName)
        {
            List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }
        static void readFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName); 
            string line = reader.ReadLine();               
            Console.WriteLine(line);                       
            line = reader.ReadLine();                       
            while (line != null)                             
            {
                Console.WriteLine(line);                     
                line = reader.ReadLine();                     
            }
            reader.Close();
        }
        static double computeAverage(string fileName)
        {
            List<int> numbers = new List<int>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int number;
                    bool isParsed = int.TryParse(line, out number);
                    if (isParsed)
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
            }
  
            double sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum / numbers.Count;
        }
    }
}
