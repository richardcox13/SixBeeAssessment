using Microsoft.AspNetCore.Identity;

namespace SixBeeHealthTech.Data.Seeding;

public static class IdentitySeeder {
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider) {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Define the admin user details
        const string adminEmail = "admin@example.com";
        const string adminPassword = "Admin@123";

        // Check if the admin user already exists, otherwise create
        var userExist = await userManager.FindByEmailAsync(adminEmail);
        if (userExist == null) {
            var adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            // Create the admin user
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (!result.Succeeded) {
                throw new Exception("Failed to create the admin user: " + String.Join(", ", result.Errors));
            }
        }
    }
}
