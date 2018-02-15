namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.BankAccountId);

            builder.Property(x => x.Balance)
                .IsRequired(true);

            builder.Property(x => x.BankName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.SwiftCode)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Ignore(x => x.PaymentMethodId);
        }
    }
}
