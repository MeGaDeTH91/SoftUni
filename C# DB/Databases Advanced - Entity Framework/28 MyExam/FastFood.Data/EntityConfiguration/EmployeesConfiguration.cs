namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(x => x.Age)
                .IsRequired(true);

            builder.Property(x => x.PositionId)
                .IsRequired(true);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId);
        }
    }
}
