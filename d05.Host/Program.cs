using d05.Nasa;
using Microsoft.Extensions.Configuration;

INasaClient<string,int> nasaClientOne;
INasaClient<int,int> nasaClientTwo;
INasaClient<bool,double> nasaClientThree;


if(args.Length == 2 && args[0] == "apod" && Int32.TryParse(args[1], out int count)) {
try{
var builder = new ConfigurationBuilder().AddJsonFile(System.IO.Directory.GetCurrentDirectory() + " /appsettings.json");
IConfiguration config = builder.Build();
ApodClient apodClient = new()
{
    ApiKey = config["ApiKey"]
};
var result = await apodClient.GetAsync(count);
foreach (var item in result)
{
    Console.WriteLine(item);
}
}
catch(Exception e){
   Console.WriteLine(e.Message);
}
}