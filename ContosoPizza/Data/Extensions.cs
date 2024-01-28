namespace ContosoPizza.Data;

public static class Extensions
{
 public static void CreateDbIfNotExists(this IHost host)
 {
 // The CreateDbIfNotExists method is defined as an extension of IHost.
  {
   using (var scope = host.Services.CreateScope())
   {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PizzaContext>(); //A reference to the PizzaContext service is created.
    context.Database.EnsureCreated();
    // EnsureCreated ensures that the database exists.
    // https://learn.microsoft.com/en-us/ef/core/managing-schemas/ensure-created#ensurecreated
    DbInitializer.Initialize(context); // The DbIntializer.Initialize method is called. The PizzaContext object is passed as a parameter.
   }
  }
 }
}