using Megyek;

var cities = new List<City>();
var lines = File.ReadAllLines("telepules.txt");

foreach (var line in lines)
{
    var data = line.Split(" ");
    var city = new City();
    city.County = data[1];
    city.Name = data[6];
    city.North = decimal.Parse(data[2].Replace('.', ','));
    city.Population = int.Parse(data[5]);

    cities.Add(city);
}

var counties = cities.GroupBy(c => c.County);
var secondLowestPopulationCounty = counties.Select(c => new {
    County = c.Key,
    Population = c.Sum(city => city.Population)
}).OrderBy(c => c.Population).Skip(1).First();
Console.WriteLine($"Második legalacsonyabb lakosságú megye: {secondLowestPopulationCounty.County}, lakosság: {secondLowestPopulationCounty.Population}");

var northestCity = cities.OrderByDescending(c => c.North).First();
Console.WriteLine($"Legalacsonyabb lakosságú megye: {northestCity.Name}, észak: {northestCity.North}");