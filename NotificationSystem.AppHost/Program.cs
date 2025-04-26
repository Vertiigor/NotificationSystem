var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PostService>("postservice");

builder.AddProject<Projects.SubscriptionService>("subscriptionservice");

builder.AddProject<Projects.NotificationService>("notificationservice");

builder.Build().Run();
