//using CareerCloud.gRPC.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using CareerCloud.gRPC.Protos;
//using School.gRPC.Protos;

namespace GRPCclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(logging =>
            {
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Debug);
            });
            using var channel = GrpcChannel.ForAddress("https://localhost:5001", 
                    new GrpcChannelOptions { LoggerFactory = loggerFactory });

            //var client = new Student.StudentClient(channel);
            //StudentReply reply = await client.GetStudentAsync(new StudentIDRequest { StudentID = 1 });
            //Console.WriteLine(reply.StudentID);

            var client = new ApplicantEducation.ApplicantEducationClient(channel);
            ApplicantEducationReply reply = await client.GetApplicantEducationAsync(new ApplicantEducationIdRequest { Id = "40FAA097-3A8C-E7A0-896C-1255EAC6A6D2" });
            ApplicantEducations replies = new ApplicantEducations();
            replies.AppEdus.Add(reply);
            await client.DeleteApplicantEducationAsync(replies);
            //var reply = await client.GetApplicantEducationsAsync(new Empty());
            //Console.WriteLine(reply.CurrentRate.ToDecimal());
        }
    }
}
