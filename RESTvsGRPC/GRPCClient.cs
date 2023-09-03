﻿using Grpc.Core;
using ModelLibrary.GRPC;
using static ModelLibrary.GRPC.MeteoriteLandingsService;

namespace RESTvsGRPC
{
    public class GRPCClient
    {
        private readonly Channel channel;
        private readonly MeteoriteLandingsServiceClient client;

        public GRPCClient()
        {
            channel = new Channel("localhost:6000", ChannelCredentials.Insecure);
            client = new MeteoriteLandingsServiceClient(channel);
        }

        public async Task<string> GetSmallPayloadAsync()
        {
            return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
        }

        //public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
        //{
        //    List<MeteoriteLanding> meteoriteLandings = new List<MeteoriteLanding>();

        //    using var call = client.GetLargePayload(new EmptyRequest());
        //    while (await call.ResponseStream.MoveNext())
        //    {
        //        meteoriteLandings.Add(call.ResponseStream.Current);
        //    }

        //    return meteoriteLandings;
        //}

        public async Task<IList<MeteoriteLanding>> GetLargePayloadAsListAsync()
        {
            return (await client.GetLargePayloadAsListAsync(new EmptyRequest())).MeteoriteLandings;
        }

        public async Task<string> PostLargePayloadAsync(MeteoriteLandingList meteoriteLandings)
        {
            return (await client.PostLargePayloadAsync(meteoriteLandings)).Status;
        }
    }
}
