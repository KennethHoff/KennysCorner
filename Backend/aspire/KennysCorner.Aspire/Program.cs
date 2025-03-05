var builder = DistributedApplication.CreateBuilder(args: args);

var psql = builder.AddPostgres("postgres");
var db = psql.AddDatabase("kennys-corner");

var api = builder.AddProject<Projects.KennysCorner_Api>("api")
    .WithReference(db);

builder.AddViteApp(name: "astro", workingDirectory: "../../../Frontend", packageManager: "pnpm")
    .WithReference(api)
    .WithExternalHttpEndpoints()
    .WithPnpmPackageInstallation();

builder.Build().Run();
