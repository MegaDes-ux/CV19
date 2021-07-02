using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CV19Console
{
    class Program
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        
        //метод для асинхронного скачивания

        private static async Task<Stream> GetDataStream() //формируем поток
        {
            var client = new HttpClient();  
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead); //делаем запрос и httpclient заберет только заголовки, без тела!
            return await response.Content.ReadAsStreamAsync();  //объект response вернет поток, который можно читать побайтно
        }

        private static IEnumerable<string> GetDataLines() //разбиваем поток на строки
            //в месте вызова GetDataLines можно будет прервать чтение в любой момент, не дожидаясь окончания чтения потока
            //делаем это для того, чтобы не грузить разом весь массив в память! экономим ресурсы!
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);  //читаем по строкам

            while (!data_reader.EndOfStream)
            {
                var line =  data_reader.ReadLine();  //считываем строку
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;  //возвращаем её как результат
            }
        }

        private static DateTime[] GetDates() => GetDataLines()  //получает даты данных
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();
        static void Main(string[] args)
        {
            //var client = new HttpClient();

            //var response = client.GetAsync(data_url).Result;

            //var csv_str = response.Content.ReadAsStringAsync().Result;

            //foreach (var data_line in GetDataLines())
            //    Console.WriteLine(data_line);

            var dates = GetDates();

            Console.WriteLine(string.Join("\r\n", dates));

            Console.ReadLine();
        }
    }
}
