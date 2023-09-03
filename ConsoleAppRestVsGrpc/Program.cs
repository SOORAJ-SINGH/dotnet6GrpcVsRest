// See https://aka.ms/new-console-template for more information
using ConsoleAppRestVsGrpc;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var sw = new Stopwatch();
sw.Start();
var restClient = new RESTClient();
await restClient.GetLargePayloadAsync();
sw.Stop();

Console.WriteLine($"Elapsed time for RestClient: GetLargePayloadAsync {sw.ElapsedMilliseconds} ms");

sw.Restart();

var grpcClient = new GRPCClient();
await grpcClient.GetLargePayloadAsListAsync();
sw.Stop();

Console.WriteLine($"Elapsed time for GRPCClient:GetLargePayloadAsync {sw.ElapsedMilliseconds} ms");


sw.Restart();
await restClient.GetSmallPayloadAsync();
sw.Stop();

Console.WriteLine($"Elapsed time for RestClient GetSmallPayloadAsync: {sw.ElapsedMilliseconds} ms");

sw.Restart();

await grpcClient.GetSmallPayloadAsync();
sw.Stop();

Console.WriteLine($"Elapsed time for GRPCClient GetSmallPayloadAsync: {sw.ElapsedMilliseconds} ms");



