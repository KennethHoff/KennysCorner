var builder = DistributedApplication.CreateBuilder(args: args);

builder.AddProject<Projects.KennysCorner_Api>("api");

builder.AddViteApp(name: "astro", workingDirectory: "../../../Frontend", packageManager: "pnpm")
    .WithExternalHttpEndpoints()
    .WithPnpmPackageInstallation();

builder.Build().Run();
