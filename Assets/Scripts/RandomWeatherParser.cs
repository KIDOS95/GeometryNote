using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;



    public static class RandomWeatherParser
    {
        /// <summary>
        /// <para>
        /// Свойство для получения случайного числа из влажности в городах Украины
        /// </para>
        /// <para>
        /// Закономерность: Значение зависит от времени года и крутится около 50-70
        /// </para>
        /// </summary>
        public static int Value
        {
            get
            {
                var rng = new Random();
                HTMLDoc.LoadHtml(GetRequest(CityUrl)); // Подгружаем страницу с относительно случайным прогнозом погоды.
                int columnID = rng.Next(1, 8); // Выбираем случайную влажность воздуха в течении дня.
                //Берём узел, в котором хранится влажность воздуха сегодня.
                var wetNode = HTMLDoc.DocumentNode.SelectSingleNode($"//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[{columnID}]");
                return int.Parse(wetNode.InnerText); // Парсим в целое число и возвращаем
            }
        }
        private static string CityUrl
        {
            get
            {
                var rng = new Random();
                HTMLDoc.LoadHtml(GetRequest("https://sinoptik.ua/украина")); // подгружаем страницу с крупными городами Украины
                // Получаем координаты случайного города в списке
                int listID = rng.Next(1, 6);
                int itemID = rng.Next(1, 5);
                // Получаем имя города
                string city = HTMLDoc.DocumentNode.SelectSingleNode($"//*[@id='content']/div/div[3]/div[1]/ul[{listID}]/li[{itemID}]/a")
                                           .InnerText.Replace(' ', '-'); // Не забываем убрать пробелы, на этом сайте вместо них "-"
                return "https://sinoptik.ua/погода-" + city.ToLower(); // Возвращаем ссылку на страницу со случайным городом.
            }
        }
        private static readonly HtmlAgilityPack.HtmlDocument HTMLDoc = new HtmlDocument(); // Инит документа
        private static string GetRequest(string url) // Получаем нашу страницу
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = false;//Запрещаем автоматический редирект
                httpWebRequest.Method = "GET";          //Можно не указывать, по умолчанию используется GET.
                httpWebRequest.Referer = "http://google.com"; // Реферер. Тут можно указать любой URL
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }

