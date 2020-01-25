﻿using Hangfire;
using Hangfire.Logging.LogProviders;
using Hangfire.Mongo;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;

namespace HangfireMongo
{
    class Program
    {
        private const int JobCount = 100;

        public static void Main()
        {
            var migrationOptions = new MongoStorageOptions
            {
                MigrationOptions = new MongoMigrationOptions
                {
                    Strategy = MongoMigrationStrategy.Migrate,
                    BackupStrategy = MongoBackupStrategy.None
                }
            };

            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", conventionPack, t => true);

            GlobalConfiguration.Configuration.UseLogProvider(new ColouredConsoleLogProvider());
            JobStorage.Current = new MongoStorage(
                MongoClientSettings.FromConnectionString("mongodb://localhost"),
                "Mongo-Hangfire-Sample-NETCore",
                migrationOptions);

            using (new BackgroundJobServer())
            {
                for (var i = 0; i < JobCount; i++)
                {
                    var jobId = i;
                    BackgroundJob.Enqueue(() => Console.WriteLine($"Fire-and-forget ({jobId})"));
                }

                Console.WriteLine($"{JobCount} job(s) has been enqued. They will be executed shortly!");
                Console.WriteLine();
                Console.WriteLine("If you close this application before they are executed, ");
                Console.WriteLine("they will be executed the next time you run this sample.");
                Console.WriteLine();
                Console.WriteLine("Press [enter] to exit...");

                Console.Read();
            }
        }
    }
}
