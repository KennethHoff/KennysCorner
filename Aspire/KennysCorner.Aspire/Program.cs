var builder = DistributedApplication.CreateBuilder(args: args);

builder.AddViteApp(name: "astro", workingDirectory: "../../kennys-corner", packageManager: "pnpm")
    .WithExternalHttpEndpoints()
    .WithPnpmPackageInstallation();

builder.Build().Run();
