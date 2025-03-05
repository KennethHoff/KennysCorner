var builder = DistributedApplication.CreateBuilder(args: args);

var psqlAdminPassword = builder.AddParameter("psqlAdminPassword");
var psql = builder.AddPostgres("psql", port: 54321, password: psqlAdminPassword);

var api = builder.AddProject<Projects.KennysCorner_Api>("api").WithReference(psql);

builder
    .AddViteApp(name: "astro", workingDirectory: "../../../Frontend", packageManager: "pnpm")
    .WithReference(api)
    .WithExternalHttpEndpoints()
    .WithPnpmPackageInstallation();

builder.Build().Run();
